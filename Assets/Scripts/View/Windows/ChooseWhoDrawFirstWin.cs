using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main {
    public partial class UI_ChooseWhoDrawFirstWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_btnDirection.onClick.Add(ChangeDirection);
            m_cont.m_btnStart.onClick.Add(NextStep);
        }

        public void Init()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            string[] names = new string[Util.Count(pComp.players,p=>!p.isTraveller)];
            int currIdx = 0;
            foreach (var player in pComp.players)
            {
                if (player.isTraveller) continue;
                names[currIdx++] = player.name;
            }
            m_cont.m_comboBox.items = names;
            m_cont.m_comboBox.ApplyListChange();
        }

        private void ChangeDirection() {
            m_cont.m_direction.selectedIndex = m_cont.m_direction.selectedIndex == 0 ? 1 : 0;
        }

        private void NextStep() { 
            // set roles
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            pComp.howMangDrawed = 0;
            pComp.clockWise = m_cont.m_direction.selectedIndex == 0;
            for (int i = 0; i < pComp.players.Count; i++) {
                if (pComp.players[i].name == m_cont.m_comboBox.text) {
                    pComp.drawingFromIdx = i;
                }
            }
            FGUIUtil.CreateWindow<UI_DrawingWin>("DrawingWin").Init();
            Dispose();
        }
    }
}
