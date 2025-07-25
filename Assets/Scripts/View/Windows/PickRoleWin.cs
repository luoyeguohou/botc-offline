using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main {
    public partial class UI_PickRoleWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
        }

        Player p;
        public void Init(Player p)
        {
            this.p = p;
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            m_cont.m_lstRole.itemRenderer = RoleIR;
            m_cont.m_lstRole.numItems = Cfg.rolesByScript[csComp.curr].Count;
        }

        public void InitTraveller(Player p)
        {
            this.p = p;
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            m_cont.m_lstRole.itemRenderer = TravellerIR;
            m_cont.m_lstRole.numItems = Cfg.travellers.Count;
        }

        public void InitTipRoles(Player p)
        {
            this.p = p;
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            m_cont.m_lstRole.itemRenderer = TipRolesIR;
            m_cont.m_lstRole.numItems = Cfg.rolesByScript[csComp.curr].Count;
        }

        private void RoleIR(int index, GObject g)
        {
            UI_Player ui = (UI_Player)g;
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            string role = Cfg.rolesByScript[csComp.curr][index];
            ui.InitByRole(role);
            ui.onClick.Add(() =>
            {
                Msg.Dispatch(MsgID.ChangePlayersRole, new object[] { p, role });
                Dispose();
            });
        }

        private void TravellerIR(int index, GObject g)
        {
            UI_Player ui = (UI_Player)g;
            string role = Cfg.travellers[index];
            ui.InitByRole(role);
            ui.onClick.Add(() =>
            {
                Msg.Dispatch(MsgID.ChangePlayersRole, new object[] { p, role });
                Dispose();
            });
        }

        private void TipRolesIR(int index, GObject g)
        {
            UI_Player ui = (UI_Player)g;
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            string role = Cfg.rolesByScript[csComp.curr][index];
            ui.InitByRole(role);
            ui.onClick.Add(() =>
            {
                Msg.Dispatch(MsgID.ChangeTipRole, new object[] { p, role });
                Dispose();
            });
        }
    }
}
