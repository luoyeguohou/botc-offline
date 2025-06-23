using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main {
    public partial class UI_DrawingWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_btnLook.onClick.Add(Look);
            m_cont.m_btnFinish.onClick.Add(Finish);
            m_cont.m_btnStartGame.onClick.Add(End);
        }

        public void Init()
        {
            ChangeText();
        }

        private void Look() {
            m_cont.m_state.selectedIndex = 1;
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            Player p = pComp.players[(pComp.drawingFromIdx + (pComp.clockWise ? 1 : -1) * pComp.howMangDrawed + pComp.players.Count) % pComp.players.Count];
            p.role = ripComp.roles[pComp.howMangDrawed];
            RoleCfg cfg = Cfg.roles[p.role];
            m_cont.m_txtCont.SetVar("name", cfg.name).SetVar("cont",cfg.ability).FlushVars();
            m_cont.m_imgCharacter.url = "ui://Main/" + cfg.id;
        }
        private void Finish() {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            pComp.howMangDrawed++;
            if (pComp.howMangDrawed == pComp.players.Count)
            {
                m_cont.m_state.selectedIndex = 2;
            }
            else {
                m_cont.m_state.selectedIndex = 0;
                ChangeText();
            }
        }
        private void End() {
            FGUIUtil.CreateWindow<UI_MainWin>("MainWin").Init();
            Dispose();
        }

        private void ChangeText() {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            m_cont.m_txtTitle.SetVar("name",pComp.players[(pComp.drawingFromIdx + (pComp.clockWise?1:-1)* pComp.howMangDrawed + pComp.players.Count) % pComp.players.Count].name);
            m_cont.m_txtTitle.SetVar("name2",pComp.players[(pComp.drawingFromIdx + (pComp.clockWise?1:-1)* pComp.howMangDrawed + pComp.players.Count) % pComp.players.Count].name);
            m_cont.m_txtTitle.FlushVars();
        }
    }
}
