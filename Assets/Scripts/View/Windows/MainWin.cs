using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using System.Linq;
using System.Reflection;

namespace Main
{
    public partial class UI_MainWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_btnShowSth.onClick.Add(ShowWords);
            m_cont.m_btnAddState.onClick.Add(OnClickAddState);
            m_cont.m_btnBackDealPlayers.onClick.Add(OnClickBackDealWithPlayers);
            m_cont.m_lstStates.itemRenderer = StateIR;
            m_cont.m_lstStateWords.itemRenderer = StateWordIR;
            m_cont.m_btnDead.onClick.Add(OnClickDead);
            m_cont.m_btnFinish.onClick.Add(OnClickFinish);
            m_cont.m_btnSelectWords.onClick.Add(OnClickSelectWords);
            m_cont.m_btnConfirm.onClick.Add(OnClickConfirm);
            m_cont.m_lstSpecific.itemRenderer = CharacterIR;
            m_cont.m_lstShowingWords.itemRenderer = ShowingWordIR;
            m_cont.m_btnFirstNight.onClick.Add(OnClickNight);
            m_cont.m_lstNightCharacter.itemRenderer = NightCharacterIR;
            m_cont.m_btnAdd30s.onClick.Add(OnClick30s);
            m_cont.m_btnAdd60s.onClick.Add(OnClick60s);
            m_cont.m_btnReset.onClick.Add(Reset);
            m_cont.m_btnAddCahracter.onClick.Add(AddShowingCharacter);
            m_cont.m_btnMinusCahracter.onClick.Add(MinusShowingCharacter);
            m_cont.m_lstShowingCharacter.itemRenderer = ShowingCharacterIR;
        }

        readonly List<UI_Player> players = new();

        public void Init()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            Vector2 midPos = new(m_cont.width / 2, m_cont.height / 2);
            int radius = 650;
            for (int i = 0; i < pComp.players.Count; i++)
            {
                GComponent gcom = UIPackage.CreateObject("Main", "Player").asCom;
                gcom.SetPivot(0.5f, 0.5f, true);
                gcom.scale = new Vector2(0.7f, 0.7f);
                UI_Player u = (UI_Player)gcom;
                Player p = pComp.players[i];
                u.m_state.selectedIndex = 1;
                u.m_txtName.text = p.name;
                u.m_img.url = "ui://Main/" + p.role;
                m_cont.m_emp.AddChild(u);
                u.position = new Vector3(midPos.x + radius * Mathf.Sin(2 * i * Mathf.PI / pComp.players.Count)
               , midPos.y - radius * Mathf.Cos(2 * i * Mathf.PI / pComp.players.Count));
                RoleCfg cfg = Cfg.roles[p.role];
                u.m_txtCharacter.text = cfg.name;
                u.onClick.Add(() =>
                {
                    DealWithPlayer(p);
                });
                players.Add(u);
            }
            UpdateNightListView();
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            m_cont.m_lstSpecific.numItems = Cfg.rolesByScript[csComp.curr].Count;
        }

        private void UpdatePlayerView()
        {
            PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
            for (int i = 0; i < players.Count; i++)
            {
                players[i].UpdateStateView(pComp.players[i]);
            }
        }
        private void DealWithPlayer(Player p)
        {
            m_cont.m_dealWithPlayer.selectedIndex = 1;
            currPlayer = p;
            m_cont.m_dead.selectedIndex = p.dead ? 1 : 0;
            UpadteStateWordView();
            UpadteStateView();
        }
        private void OnClickDead()
        {
            currPlayer.dead = !currPlayer.dead;
            m_cont.m_dead.selectedIndex = currPlayer.dead ? 1 : 0;
            UpdatePlayerView();
        }
        Player currPlayer;
        private void OnClickAddState()
        {
            currPlayer.states.Add(m_cont.m_txtState.text);
            UpadteStateView();
            UpdatePlayerView();
        }
        private void OnClickBackDealWithPlayers()
        {
            m_cont.m_dealWithPlayer.selectedIndex = 0;
        }
        private void StateIR(int index, GObject g)
        {
            UI_State ui = (UI_State)g;
            ui.m_txtCont.text = currPlayer.states[index];
            ui.onClick.Clear();
            ui.onClick.Add(() =>
            {
                currPlayer.states.RemoveAt(index);
                UpadteStateView();
                UpdatePlayerView();
            });
        }
        private void StateWordIR(int index, GObject g)
        {
            g.text = Consts.words[index];
            g.onClick.Clear();
            g.onClick.Add(() =>
            {
                m_cont.m_txtState.text = Consts.words[index];
            });
        }
        private void UpadteStateView()
        {
            m_cont.m_lstStates.numItems = currPlayer.states.Count;
        }
        private void UpadteStateWordView()
        {
            m_cont.m_lstStateWords.numItems = Consts.words.Length;
        }

        private void ShowWords()
        {
            m_cont.m_state.selectedIndex = 1;
            UpdateShowingCharacter();
        }


        private void OnClickFinish()
        {
            m_cont.m_state.selectedIndex = 0;
        }
        private void OnClickSelectWords()
        {
            m_cont.m_selectWords.selectedIndex = 1;
            m_cont.m_lstShowingWords.numItems = Consts.showingWords.Length;
        }

        private void ShowingWordIR(int index, GObject g)
        {
            g.text = Consts.showingWords[index];
            g.onClick.Clear();
            g.onClick.Add(() =>
            {
                m_cont.m_txtText.text = Consts.showingWords[index];
                m_cont.m_selectWords.selectedIndex = 0;
            });
        }

        public int nowChoosingWhich;

        private void OnClickConfirm()
        {
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            List<string> roles = Cfg.rolesByScript[csComp.curr];
            RoleCfg cfg = Cfg.roles[roles[m_cont.m_lstSpecific.selectedIndex]];
            showingRoles[nowChoosingWhich] = cfg.id;
            UpdateShowingCharacter();
            m_cont.m_selectCharacter.selectedIndex = 0;
        }

        private readonly List<string> showingRoles = new();

        private void UpdateShowingCharacter()
        {
            m_cont.m_lstShowingCharacter.numItems = showingRoles.Count;
        }
        private void ShowingCharacterIR(int index, GObject g)
        {
            UI_Character ui = (UI_Character)g;
            if (showingRoles[index] == "")
            {
                ui.m_txtCont.text = "";
                ui.m_txtName.text = "";
                ui.m_img.url = "";
            }
            else
            {
                RoleCfg cfg = Cfg.roles[showingRoles[index]];
                ui.m_txtCont.text = cfg.ability;
                ui.m_txtName.text = cfg.name;
                ui.m_img.url = "ui://Main/" + cfg.id;
            }

            ui.onClick.Clear();
            ui.onClick.Add(() =>
            {
                nowChoosingWhich = index;
                m_cont.m_selectCharacter.selectedIndex = 1;
            });
        }
        private void AddShowingCharacter()
        {
            showingRoles.Add("");
            UpdateShowingCharacter();
        }
        private void MinusShowingCharacter()
        {
            if (showingRoles.Count == 0) return;
            showingRoles.RemoveAt(showingRoles.Count - 1);
            UpdateShowingCharacter();
        }

        private void CharacterIR(int index, GObject g)
        {
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            UI_Character ui = (UI_Character)g;
            List<string> roles = Cfg.rolesByScript[csComp.curr];
            RoleCfg cfg = Cfg.roles[roles[index]];
            ui.m_txtName.text = cfg.name;
            ui.m_txtCont.text = cfg.ability;
            ui.m_img.url = "ui://Main/" + cfg.id;
            ui.m_inPlay.selectedIndex = ripComp.roles.Contains(roles[index]) ? 1 : 0;
        }

        private void NightCharacterIR(int index, GObject g)
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            string role;
            if (m_cont.m_firstNight.selectedIndex == 0)
            {
                role = ripComp.otherNightOrder[index];
            }
            else
            {
                role = ripComp.firstNightOrder[index];
            }
            RoleCfg cfg = Cfg.roles[role];
            UI_Character ui = (UI_Character)g;
            ui.m_txtName.text = cfg.name;
            ui.m_txtCont.text = cfg.ability;
            ui.m_img.url = "ui://Main/" + cfg.id;
        }
        private void OnClickNight()
        {
            m_cont.m_firstNight.selectedIndex = m_cont.m_firstNight.selectedIndex == 1 ? 0 : 1;
            UpdateNightListView();
        }

        private void UpdateNightListView()
        {
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            if (m_cont.m_firstNight.selectedIndex == 0)
            {
                m_cont.m_lstNightCharacter.numItems = ripComp.otherNightOrder.Count;
            }
            else
            {
                m_cont.m_lstNightCharacter.numItems = ripComp.firstNightOrder.Count;
            }
        }

        float count = 0;
        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (count > 0)
            {
                count -= Time.deltaTime;
                if (count <= 0)
                {
                    count = 0;
                    EcsUtil.PlaySound("countdown");
                    m_cont.m_txtCounter.text = "";
                }
                else
                {
                    m_cont.m_txtCounter.text = ((int)count).ToString() + "s";
                }
            }
        }

        private void OnClick30s()
        {
            count += 30;
        }

        private void OnClick60s()
        {
            count += 60;
        }

        private void Reset()
        {
            count = 0;
            m_cont.m_txtCounter.text = "";
        }
    }
}
