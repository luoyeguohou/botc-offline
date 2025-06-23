using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main {
    public partial class UI_PutCharacterWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_btnTownsfolk.onClick.Add(AddTownsfolk);
            m_cont.m_btnOutsider.onClick.Add(AddOutSider);
            m_cont.m_btnMinion.onClick.Add(AddMinion);
            m_cont.m_btnDemon.onClick.Add(AddDemon);
            m_cont.m_btnSpecific.onClick.Add(AddSpecific);
            m_cont.m_btnConfirm.onClick.Add(Confirm);
            m_cont.m_btnFinish.onClick.Add(NextStep);
            m_cont.m_lstCharacter.itemRenderer = InPlayIR;
            m_cont.m_lstSpecific.itemRenderer = NotInPlayIR;
        }

        public void Init() { 
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            int townsfolkNum = Consts.roleNums[pComp.players.Count - 5,0];
            int outSiderNum = Consts.roleNums[pComp.players.Count - 5,1];
            int minionNum = Consts.roleNums[pComp.players.Count - 5,2];
            int demonNum = Consts.roleNums[pComp.players.Count - 5,3];
            m_cont.m_txtTitle.SetVar("num1", townsfolkNum.ToString());
            m_cont.m_txtTitle.SetVar("num2", outSiderNum.ToString());
            m_cont.m_txtTitle.SetVar("num3", minionNum.ToString());
            m_cont.m_txtTitle.SetVar("num4", demonNum.ToString());
            m_cont.m_txtTitle.FlushVars();
            UpdateInPlayView();
        }

        private void AddTownsfolk()
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            Util.Shuffle(ripComp.townsfolkNotInPlay, new System.Random());
            ripComp.roles.Add(ripComp.townsfolkNotInPlay.Shift());
            UpdateInPlayView();
        }
        private void AddMinion() {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            Util.Shuffle(ripComp.minionNotInPlay, new System.Random());
            ripComp.roles.Add(ripComp.minionNotInPlay.Shift());
            UpdateInPlayView();
        }
        private void AddOutSider()
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            Util.Shuffle(ripComp.outSiderNotInPlay, new System.Random());
            ripComp.roles.Add(ripComp.outSiderNotInPlay.Shift());
            UpdateInPlayView();
        }
        private void AddDemon()
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            Util.Shuffle(ripComp.demonNotInPlay, new System.Random());
            ripComp.roles.Add(ripComp.demonNotInPlay.Shift());
            UpdateInPlayView();
        }
        private void AddSpecific()
        {
            UpdateNotInPlayView();
            m_cont.m_choosingSpecific.selectedIndex = 1;
        }

        private void Confirm() {
            m_cont.m_choosingSpecific.selectedIndex = 0;
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            if (m_cont.m_lstSpecific.selectedIndex == -1) {
                UpdateInPlayView();
                return;
            }
            string role = Cfg.rolesByScript[csComp.curr][m_cont.m_lstSpecific.selectedIndex];
            ripComp.townsfolkNotInPlay.Remove(role);
            ripComp.outSiderNotInPlay.Remove(role);
            ripComp.minionNotInPlay.Remove(role);
            ripComp.demonNotInPlay.Remove(role);
            ripComp.roles.Add(role);
            UpdateInPlayView();
        }

        private void UpdateInPlayView() {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            m_cont.m_lstCharacter.numItems = ripComp.roles.Count;
        }
        private void UpdateNotInPlayView()
        {
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            m_cont.m_lstSpecific.numItems = Cfg.rolesByScript[csComp.curr].Count;
        }

        private void InPlayIR(int index,GObject g) { 
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            RoleCfg cfg = Cfg.roles[ripComp.roles[index]];
            UI_Character ui = (UI_Character)g;
            InitView(ui, cfg);
            ui.onClick.Clear();
            ui.onClick.Add(() => {
                ripComp.roles.Remove(cfg.id);
                if (cfg.team == "townsfolk")
                    ripComp.townsfolkNotInPlay.Add(cfg.id);
                if (cfg.team == "outsider")
                    ripComp.outSiderNotInPlay.Add(cfg.id);
                if (cfg.team == "minion")
                    ripComp.minionNotInPlay.Add(cfg.id);
                if (cfg.team == "demon")
                    ripComp.demonNotInPlay.Add(cfg.id);
                UpdateInPlayView();
            });
        }

        private void NotInPlayIR(int index, GObject g)
        {
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            RoleCfg cfg = Cfg.roles[Cfg.rolesByScript[csComp.curr][index]];
            UI_Character ui = (UI_Character)g;
            InitView(ui, cfg);
        }

        private void InitView(UI_Character ui, RoleCfg cfg) {
            ui.m_txtName.text = cfg.name;
            ui.m_txtCont.text = cfg.ability;
            ui.m_img.url = "ui://Main/"+cfg.id;
        }

        private void NextStep() {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            if (ripComp.roles.Count != pComp.players.Count)
                return;
            // set night order
            ripComp.firstNightOrder = Util.Filter(ripComp.roles, r => Cfg.roles[r].firstNight!=0);
            ripComp.otherNightOrder = Util.Filter(ripComp.roles, r => Cfg.roles[r].otherNight != 0);
            ripComp.firstNightOrder.Sort((s1, s2) => {
                return Cfg.roles[s1].firstNight - Cfg.roles[s2].firstNight;                
            });
             ripComp.otherNightOrder.Sort((s1, s2) => {
                return Cfg.roles[s1].otherNight - Cfg.roles[s2].otherNight;                
            });

            // next window
            FGUIUtil.CreateWindow<UI_ChooseWhoDrawFirstWin>("ChooseWhoDrawFirstWin").Init();
            Dispose();
        }
    }
}

