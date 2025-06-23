using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace Main
{
    public partial class UI_PutPlayNameWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_btnAddPlayer.onClick.Add(AddPlayer);
            m_cont.m_btnRemovePlayer.onClick.Add(RemovePlayer);
            m_cont.m_btnStartGame.onClick.Add(StartGame);
            m_cont.m_lstNames.itemRenderer = NameIR;
        }

        public void Init()
        {
            NameComp nComp = World.e.sharedConfig.GetComp<NameComp>();
            string s = PlayerPrefs.GetString("names", "");
            if (s != "")
            {
                string[] names = s.Split(",");
                nComp.names = new(names);
            }
            UpdateNameView();
        }

        private void NameIR(int index, GObject g)
        {
            NameComp nComp = World.e.sharedConfig.GetComp<NameComp>();
            UI_NameAndDelete btn = (UI_NameAndDelete)g;
            btn.m_btnName.title = nComp.names[index];
            btn.m_btnName.onClick.Clear();
            btn.m_btnName.onClick.Add(() =>
            {
                for (int i = 0; i < uis.Count; i++)
                {
                    if (uis[i].m_txtInputName.text == "")
                    {
                        uis[i].m_txtInputName.text = nComp.names[index];
                        break;
                    }
                }
            });
            btn.m_btnDelete.onClick.Clear();
            btn.m_btnDelete.onClick.Add(() =>
            {
                nComp.names.RemoveAt(index);
                UpdateNameView();
                string s = "";
                for (int i = 0; i < nComp.names.Count; i++)
                {
                    s += nComp.names[i] + (i != nComp.names.Count - 1 ? "," : "");
                }
                PlayerPrefs.SetString("names", s);
            });
        }
        private void UpdateNameView()
        {
            NameComp nComp = World.e.sharedConfig.GetComp<NameComp>();
            m_cont.m_lstNames.numItems = nComp.names.Count;
        }
        private void SaveName()
        {
            NameComp nComp = World.e.sharedConfig.GetComp<NameComp>();
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            foreach (Player p in pComp.players)
            {
                if (!nComp.names.Contains(p.name))
                    nComp.names.Add(p.name);
            }
            string s = "";
            for (int i = 0; i < nComp.names.Count; i++)
            {
                s += nComp.names[i] + (i != nComp.names.Count - 1 ? "," : "");
            }
            PlayerPrefs.SetString("names", s);
        }

        private void AddPlayer()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            Player p = new Player();
            p.name = "";
            pComp.players.Add(p);
            UpdateView();
        }
        private void RemovePlayer()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            if (pComp.players.Count == 0) return;
            pComp.players.RemoveAt(pComp.players.Count - 1);
            UpdateView();
        }
        private readonly List<UI_Player> uis = new();
        private void UpdateView()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            for (int i = 0; i < Mathf.Min(pComp.players.Count, uis.Count); i++)
            {
                pComp.players[i].name = uis[i].m_txtInputName.text;
            }
            if (pComp.players.Count > uis.Count)
            {
                for (int i = 0; i < pComp.players.Count - uis.Count; i++)
                {
                    GComponent gcom = UIPackage.CreateObject("Main", "Player").asCom;
                    m_cont.AddChild(gcom);
                    gcom.SetPivot(0.5f, 0.5f, true);
                    gcom.scale = new Vector2(0.7f, 0.7f);
                    uis.Add((UI_Player)gcom);
                }
            }
            else if (pComp.players.Count < uis.Count)
            {
                for (int i = 0; i < uis.Count - pComp.players.Count; i++)
                {
                    UI_Player ui = uis.Shift();
                    ui.Dispose();
                }
            }

            for (int i = 0; i < pComp.players.Count; i++)
            {
                SetUIView(uis[i], i, pComp.players[i], pComp.players.Count);
            }
        }

        private void SetUIView(UI_Player ui, int index, Player p, int playerCnt)
        {
            Vector2 midPos = new Vector2(m_cont.width / 2, m_cont.height / 2);

            int radius = 650;

            ui.m_state.selectedIndex = 0;
            ui.m_txtInputName.text = p.name;

            ui.position = new Vector3(midPos.x + radius * Mathf.Sin(2 * index * Mathf.PI / playerCnt)
                , midPos.y - radius * Mathf.Cos(2 * index * Mathf.PI / playerCnt));
            ui.m_txtInputName.text = p.name;
        }

        private void StartGame()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            if (pComp.players.Count < 5 || pComp.players.Count > 15) return;
            // save name
            for (int i = 0; i < uis.Count; i++)
            {
                pComp.players[i].name = uis[i].m_txtInputName.text;
            }
            SaveName();
            // next window
            FGUIUtil.CreateWindow<UI_PutCharacterWin>("PutCharacterWin").Init();
            Dispose();
        }
    }
}
