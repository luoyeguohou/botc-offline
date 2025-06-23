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
        }
        Player p;
        public void UpdateStateView(Player p)
        {
            this.p = p;
            m_lstState.numItems = p.states.Count;
            m_dead.selectedIndex = p.dead ? 1 : 0;
        }
        private void ItemIR(int index, GObject g)
        {
            UI_State ui = (UI_State)g;
            ui.m_txtCont.text = p.states[index];
        }
    }
}
