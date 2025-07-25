using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace Main {
    public partial class UI_ShowSomethingWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_btnFinish.onClick.Add(OnClickFinish);
            m_cont.m_btnSelectWords.onClick.Add(OnClickSelectWords);
            m_cont.m_btnAddCahracter.onClick.Add(AddShowingCharacter);
            m_cont.m_btnMinusCahracter.onClick.Add(MinusShowingCharacter);
            m_cont.m_lstShowingCharacter.itemRenderer = ShowingCharacterIR;
            m_cont.m_lstSpecific.itemRenderer = CharacterIR;
            m_cont.m_btnConfirm.onClick.Add(OnClickConfirm);
            m_cont.m_lstShowingWords.itemRenderer = ShowingWordIR;
        }

        public void Init()
        {
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            m_cont.m_lstSpecific.numItems = Cfg.rolesByScript[csComp.curr].Count;
        }

        private void OnClickFinish()
        {
            Dispose();
        }
        private void OnClickSelectWords()
        {
            m_cont.m_selectWord.selectedIndex = 1;
            m_cont.m_lstShowingWords.numItems = (Cfg.language == "english" ? Consts.showingWords : Consts.showingChineseWords).Length;
        }
        private readonly List<string> showingRoles = new();
        public int nowChoosingWhich;

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

        private void UpdateShowingCharacter()
        {
            m_cont.m_lstShowingCharacter.numItems = showingRoles.Count;
        }

        private void ShowingWordIR(int index, GObject g)
        {
            g.text = (Cfg.language == "english" ? Consts.showingWords : Consts.showingChineseWords)[index];
            g.onClick.Clear();
            g.onClick.Add(() =>
            {
                m_cont.m_txtText.text = (Cfg.language == "english" ? Consts.showingWords : Consts.showingChineseWords)[index];
                m_cont.m_selectWord.selectedIndex = 0;
            });
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
                ui.m_txtCont.text = cfg.GetAbility();
                ui.m_txtName.text = cfg.GetName();
                ui.m_img.url = "ui://Main/" + cfg.id;
            }

            ui.onClick.Clear();
            ui.onClick.Add(() =>
            {
                nowChoosingWhich = index;
                m_cont.m_selectCharacter.selectedIndex = 1;
            });
        }

        private void CharacterIR(int index, GObject g)
        {
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
            UI_Character ui = (UI_Character)g;
            List<string> roles = Cfg.rolesByScript[csComp.curr];
            RoleCfg cfg = Cfg.roles[roles[index]];
            ui.m_txtName.text = cfg.GetName();
            ui.m_txtCont.text = cfg.GetAbility();
            ui.m_img.url = "ui://Main/" + cfg.id;
            ui.m_inPlay.selectedIndex = ripComp.roles.Contains(roles[index]) ? 1 : 0;
        }

        private void OnClickConfirm()
        {
            CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
            if (m_cont.m_lstSpecific.selectedIndex == -1) return;
            List<string> roles = Cfg.rolesByScript[csComp.curr];
            RoleCfg cfg = Cfg.roles[roles[m_cont.m_lstSpecific.selectedIndex]];
            showingRoles[nowChoosingWhich] = cfg.id;
            UpdateShowingCharacter();
            m_cont.m_selectCharacter.selectedIndex = 0;
        }
    }
}
