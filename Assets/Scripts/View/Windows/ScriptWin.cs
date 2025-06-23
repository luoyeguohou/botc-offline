using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public partial class UI_ScriptWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_lstScripts.itemRenderer = ItemIR;
            m_cont.m_btnCreateScript.onClick.Add(() => EditScript(""));
            m_cont.m_btnBack1.onClick.Add(() => m_cont.m_createScript.selectedIndex = 0);
            m_cont.m_btnConfirm.onClick.Add(AddScript);
            m_cont.m_lstCharacter.itemRenderer = CharacterIR;
        }

        public void Init()
        {
            UpdateScriptView();
            m_cont.m_lstCharacter.numItems = Cfg.roles.Keys.Count;
        }

        private void UpdateScriptView()
        {
            m_cont.m_lstScripts.numItems = Cfg.scripts.Count;
        }

        private void ItemIR(int index, GObject g)
        {
            string id = new List<string>(Cfg.scripts.Keys)[index];
            UI_ScriptItem ui = (UI_ScriptItem)g;
            ScriptCfg cfg = Cfg.scripts[id];
            ui.m_custom.selectedIndex = cfg.createByUsers ? 1 : 0;
            ui.m_txtName.text = cfg.name;
            ui.m_btnPick.onClick.Add(() =>
            {
                CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
                csComp.curr = id;
                RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
                foreach (var id in Cfg.rolesByScript[id])
                {
                    if (Cfg.roles[id].team == "townsfolk")
                        ripComp.townsfolkNotInPlay.Add(id);
                    if (Cfg.roles[id].team == "outsider")
                        ripComp.outSiderNotInPlay.Add(id);
                    if (Cfg.roles[id].team == "minion")
                        ripComp.minionNotInPlay.Add(id);
                    if (Cfg.roles[id].team == "demon")
                        ripComp.demonNotInPlay.Add(id);
                }
                FGUIUtil.CreateWindow<UI_PutPlayNameWin>("PutPlayNameWin").Init();
                Dispose();
            });
            ui.m_btnEdit.onClick.Add(() =>
            {
                EditScript(cfg.id);
            });
            ui.m_btnDelete.onClick.Add(() =>
            {
                DeleteScript(cfg.id);
            });
        }

        private void CharacterIR(int index, GObject g)
        {
            UI_Character ui = (UI_Character)g;
            RoleCfg cfg = new List<RoleCfg>(Cfg.roles.Values)[index];
            ui.m_txtName.text = cfg.name;
            ui.m_txtCont.text = cfg.ability;
            ui.m_img.url = "ui://Main/" + cfg.id;
        }

        private void EditScript(string name)
        {
            m_cont.m_createScript.selectedIndex = 1;
            m_cont.m_txtScriptName.text = name;
            if (Cfg.scripts.ContainsKey(name))
            {
                m_cont.m_lstCharacter.ClearSelection();
                foreach (string roleID in Cfg.rolesByScript[name])
                {
                    m_cont.m_lstCharacter.AddSelection(new List<string>(Cfg.roles.Keys).IndexOf(roleID), false);
                }
            }
            else
            {
                m_cont.m_lstCharacter.ClearSelection();
            }
            UpdateScriptView();
        }
        private void AddScript()
        {
            m_cont.m_createScript.selectedIndex = 0;
            ScriptCfg cfg = new();
            cfg.author = "";
            cfg.description = "";
            cfg.level = "";
            cfg.name = m_cont.m_txtScriptName.text;
            cfg.createByUsers = true;
            cfg.id = m_cont.m_txtScriptName.text;
            List<string> roles = new();
            foreach (int index in m_cont.m_lstCharacter.GetSelection())
            {
                roles.Add(new List<RoleCfg>(Cfg.roles.Values)[index].id);
            }
            cfg.roles = roles.ToArray();
            //add
            Cfg.scripts[cfg.id] = cfg;
            Cfg.rolesByScript[cfg.id] = new(cfg.roles);
            // save
            Cfg.Save();
            UpdateScriptView();
        }
        private void DeleteScript(string id)
        {
            Cfg.scripts.Remove(id);
            Cfg.rolesByScript.Remove(id);
            // save
            Cfg.Save();
            //delete
            UpdateScriptView();
        }

    }
}
