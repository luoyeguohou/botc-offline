using FairyGUI;

namespace Main
{
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
            Msg.Bind(MsgID.AfterRolesChange,UpdateView);
        }

        public override void Dispose()
        {
            Msg.UnBind(MsgID.AfterRolesChange, UpdateView);
            base.Dispose();
        }

        public void Init()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            int playerNum = Util.Count(pComp.players,p=>!p.isTraveller);
            int townsfolkNum = Consts.roleNums[playerNum - 5, 0];
            int outSiderNum = Consts.roleNums[playerNum - 5, 1];
            int minionNum = Consts.roleNums[playerNum - 5, 2];
            int demonNum = Consts.roleNums[playerNum - 5, 3];
            m_cont.m_txtTitle.SetVar("num1", townsfolkNum.ToString());
            m_cont.m_txtTitle.SetVar("num2", outSiderNum.ToString());
            m_cont.m_txtTitle.SetVar("num3", minionNum.ToString());
            m_cont.m_txtTitle.SetVar("num4", demonNum.ToString());
            m_cont.m_txtTitle.FlushVars();
            UpdateView();
        }

        private void AddTownsfolk()
        {
            Msg.Dispatch(MsgID.AddRandomTownsfolkRole);
        }
        private void AddMinion()
        {
            Msg.Dispatch(MsgID.AddRandomMinionRole);
        }
        private void AddOutSider()
        {
            Msg.Dispatch(MsgID.AddRandomOutSiderRole);
        }
        private void AddDemon()
        {
            Msg.Dispatch(MsgID.AddRandomDemonRole);
        }
        private void AddSpecific()
        {
            m_cont.m_choosingSpecific.selectedIndex = 1;
        }

        private void Confirm()
        {
            m_cont.m_choosingSpecific.selectedIndex = 0;
            if (m_cont.m_lstSpecific.selectedIndex == -1) return;
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            string role = Cfg.rolesByScript[csComp.curr][m_cont.m_lstSpecific.selectedIndex];
            Msg.Dispatch(MsgID.AddSpecificRole,new object[] { role});
        }

        private void UpdateView(object[] p = null)
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            m_cont.m_lstCharacter.numItems = ripComp.roles.Count;
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            m_cont.m_lstSpecific.numItems = Cfg.rolesByScript[csComp.curr].Count;
        }

        private void InPlayIR(int index, GObject g)
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            RoleCfg cfg = Cfg.roles[ripComp.roles[index]];
            UI_Character ui = (UI_Character)g;
            InitView(ui, cfg);
            ui.onClick.Clear();
            ui.onClick.Add(() => Msg.Dispatch(MsgID.DeleteRole, new object[] { cfg.id }));
        }

        private void NotInPlayIR(int index, GObject g)
        {
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            RoleCfg cfg = Cfg.roles[Cfg.rolesByScript[csComp.curr][index]];
            UI_Character ui = (UI_Character)g;
            InitView(ui, cfg);
        }

        private void InitView(UI_Character ui, RoleCfg cfg)
        {
            ui.m_txtName.text = cfg.GetName();
            ui.m_txtCont.text = cfg.GetAbility();
            ui.m_img.url = "ui://Main/" + cfg.id;
        }

        private void NextStep()
        {
            Msg.Dispatch(MsgID.ConfirmRole);
            Dispose();
        }
    }
}

