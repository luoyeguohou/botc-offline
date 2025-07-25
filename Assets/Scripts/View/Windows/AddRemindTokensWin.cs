using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;

namespace Main
{
    public partial class UI_AddRemindTokensWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_lstStates.itemRenderer = StateIR;
            m_cont.m_btnConfirm.onClick.Add(OnClickConfirm);

        }
        private Player p;

        public void Init(Player p)
        {
            this.p = p;
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            m_cont.m_lstStates.numItems = ripComp.remindTokens.Count;
        }

        private void StateIR(int index, GObject g)
        {
            UI_State ui = (UI_State)g;
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            TipCfg cfg = Cfg.tips[ripComp.remindTokens[index]];
            ui.m_txtCont.text = cfg.GetText();
            ui.m_img.url = "ui://Main/" + cfg.role;
        }

        private void OnClickConfirm()
        {
            if (m_cont.m_lstStates.selectedIndex == -1) return;
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            Msg.Dispatch(MsgID.AddRemindTokens, new object[] { p, ripComp.remindTokens[m_cont.m_lstStates.selectedIndex] });
            Dispose();
        }
    }
}
