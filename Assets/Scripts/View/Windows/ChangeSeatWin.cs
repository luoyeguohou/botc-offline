using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace Main
{
    public partial class UI_ChangeSeatWin : FairyWindow
    {
        public void InitChangeSeat(Player p)
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            Vector2 midPos = new(m_cont.width / 2, m_cont.height / 2);
            int radius = 650;
            for (int i = 0; i < pComp.players.Count; i++)
            {
                Player player = pComp.players[i];
                UI_Player ui = GenNewPlayerUI();
                ui.position = new Vector3(midPos.x + radius * Mathf.Sin(2 * i * Mathf.PI / pComp.players.Count) * 1.1f
           , midPos.y - radius * Mathf.Cos(2 * i * Mathf.PI / pComp.players.Count) * 0.96f);
                ui.Init(player);
                ui.m_outline.selectedIndex = player == p ? 1 : 0;
                ui.onClick.Add(() =>
                {
                    Msg.Dispatch(MsgID.ChangeSeat, new object[] { p, player });
                    Dispose();
                });
            }
        }

        public void InitMoveToSeat(Player p)
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            Vector2 midPos = new(m_cont.width / 2, m_cont.height / 2);
            int radius = 650;
            for (int i = 0; i < pComp.players.Count; i++)
            {
                // player
                Player player = pComp.players[i];
                UI_Player ui = GenNewPlayerUI();
                ui.position = new Vector3(midPos.x + radius * Mathf.Sin(2 * i * Mathf.PI / pComp.players.Count) * 1.1f
           , midPos.y - radius * Mathf.Cos(2 * i * Mathf.PI / pComp.players.Count) * 0.96f);
                ui.Init(player);
                ui.m_outline.selectedIndex = player == p ? 1 : 0;

                // button
                GButton btn = GenNewButtonUI();
                btn.position = new Vector3(midPos.x + radius * Mathf.Sin(2 * (i + 0.5f) * Mathf.PI / pComp.players.Count) * 1.1f
           , midPos.y - radius * Mathf.Cos(2 * (i + 0.5f) * Mathf.PI / pComp.players.Count) * 0.96f);
                int index = i;
                btn.onClick.Add(() =>
                {
                    Msg.Dispatch(MsgID.MoveToSeat, new object[] { p, index + 1 });
                    Dispose();
                });
            }
        }

        private UI_Player GenNewPlayerUI()
        {
            GComponent gcom = UIPackage.CreateObject("Main", "Player").asCom;
            m_cont.m_emp.AddChild(gcom);
            gcom.SetPivot(0.5f, 0.5f, true);
            gcom.scale = new Vector2(0.7f, 0.7f);
            return (UI_Player)gcom;
        }

        private GButton GenNewButtonUI()
        {
            GComponent gcom = UIPackage.CreateObject("Main", "BtnCircle").asCom;
            m_cont.m_emp.AddChild(gcom);
            gcom.SetPivot(0.5f, 0.5f, true);
            return (GButton)gcom;
        }
    }
}
