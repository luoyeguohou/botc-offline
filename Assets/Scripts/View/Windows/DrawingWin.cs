using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
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

        private void Look()
        {
            m_cont.m_state.selectedIndex = 1;
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            int index = (pComp.drawingFromIdx + (pComp.clockWise ? 1 : -1) * pComp.howMangDrawed + pComp.players.Count) % pComp.players.Count;
            Player p = pComp.players[index];
            RoleCfg cfg = Cfg.roles[p.role];
            m_cont.m_txtCont.SetVar("name", cfg.GetName()).SetVar("cont", cfg.GetAbility()).FlushVars();
            m_cont.m_imgCharacter.url = "ui://Main/" + cfg.id;
        }
        private void Finish()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            pComp.howMangDrawed++;
            int index = (pComp.drawingFromIdx + (pComp.clockWise ? 1 : -1) * pComp.howMangDrawed + pComp.players.Count) % pComp.players.Count;
            while (true)
            {
                if (pComp.players[index].isTraveller)
                {
                    pComp.howMangDrawed++;
                    index = (pComp.drawingFromIdx + (pComp.clockWise ? 1 : -1) * pComp.howMangDrawed + pComp.players.Count) % pComp.players.Count;
                }
                else
                {
                    break;
                }
            }
            if (pComp.howMangDrawed == pComp.players.Count)
            {
                m_cont.m_state.selectedIndex = 2;
            }
            else
            {
                m_cont.m_state.selectedIndex = 0;
                ChangeText();
            }
        }
        private void End()
        {
            Dispose();
            Msg.Dispatch(MsgID.AfterDrawRole);
        }

        private void ChangeText()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            m_cont.m_txtTitle.SetVar("name", pComp.players[(pComp.drawingFromIdx + (pComp.clockWise ? 1 : -1) * pComp.howMangDrawed + pComp.players.Count) % pComp.players.Count].name);
            m_cont.m_txtTitle.SetVar("name2", pComp.players[(pComp.drawingFromIdx + (pComp.clockWise ? 1 : -1) * pComp.howMangDrawed + pComp.players.Count) % pComp.players.Count].name);
            m_cont.m_txtTitle.FlushVars();
        }
    }
}
