using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace Main
{
    public partial class UI_Player : GComponent
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_lstState.itemRenderer = ItemIR;
            m_txtInputName.onFocusOut.Add(AfterChangeText);
            m_txtInputName.onClick.Add((EventContext e) => e.StopPropagation());
            Msg.Bind(MsgID.AfterPlayerInfoChanged, UpdateView);
        }

        public override void Dispose()
        {
            Msg.UnBind(MsgID.AfterPlayerInfoChanged, UpdateView);
            base.Dispose();
        }

        private void UpdateView(object[] p = null)
        {
            if (this.p == null) return;
            if (this.p.name != "")
            {
                m_txtInputName.text = this.p.name;
            }
            m_hasRole.selectedIndex = this.p.role == "" ? 0 : 1;
            if (this.p.role != "")
            {
                m_img.url = "ui://Main/" + this.p.role;
                RoleCfg cfg = Cfg.roles[this.p.role];
                m_txtCharacter.text = cfg.GetName();
            }
            m_isRealPlayer.selectedIndex = this.p.isRealPlayer ? 1 : 0;
            m_isGood.selectedIndex = this.p.isGood ? 1 : 0;
            m_hasDeadVote.selectedIndex = this.p.hasDeadVote ? 1 : 0;
            m_lstState.numItems = this.p.states.Count;
            m_dead.selectedIndex = this.p.dead ? 1 : 0;
        }

        private Player p;
        public void Init(Player p)
        {
            this.p = p;
            UpdateView();
        }

        public void InitByRole(string role)
        {
            m_isRealPlayer.selectedIndex = 0;
            m_hasRole.selectedIndex = 1;
            m_img.url = "ui://Main/" + role;
            RoleCfg cfg = Cfg.roles[role];
            m_txtCharacter.text = cfg.GetName();
        }

        private void AfterChangeText()
        {
            p.name = m_txtInputName.text;
            Msg.Dispatch(MsgID.AfterPlayerInfoChanged);
        }

        private void ItemIR(int index, GObject g)
        {
            UI_State ui = (UI_State)g;
            TipCfg cfg = Cfg.tips[p.states[index]];
            ui.m_txtCont.text = cfg.GetText();
            ui.m_img.url = "ui://Main/" + cfg.role;
        }
    }
}
