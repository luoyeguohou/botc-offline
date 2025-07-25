using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using FairyGUI;

namespace Main {
    public partial class UI_CreateScriptWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_btnBack.onClick.Add(Dispose);
            m_cont.m_btnConfirm.onClick.Add(AddScript);
            m_cont.m_lstCharacter.itemRenderer = CharacterIR;
        }

        public void Init(string name)
        {
            m_cont.m_lstCharacter.numItems = Cfg.roles.Keys.Count;
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
        }

        private void CharacterIR(int index, GObject g)
        {
            UI_Character ui = (UI_Character)g;
            RoleCfg cfg = new List<RoleCfg>(Cfg.roles.Values)[index];
            ui.m_txtName.text = cfg.GetName();
            ui.m_txtCont.text = cfg.GetAbility();
            ui.m_img.url = "ui://Main/" + cfg.id;
        }

        private void AddScript()
        {
            if (m_cont.m_txtScriptName.text == "") return;
            List<string> roles = new();
            foreach (int index in m_cont.m_lstCharacter.GetSelection())
            {
                roles.Add(new List<RoleCfg>(Cfg.roles.Values)[index].id);
            }
            Msg.Dispatch(MsgID.UploadScript, new object[] { m_cont.m_txtScriptName.text, roles.ToArray() });
            Dispose();
        }
    }
}
