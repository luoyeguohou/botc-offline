using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main
{
    public partial class UI_ScriptWin : FairyWindow
    {
        public override void ConstructFromResource()
        {
            base.ConstructFromResource();
            m_cont.m_lstScripts.itemRenderer = ItemIR;
            m_cont.m_btnCreateScript.onClick.Add(() => EditScript(""));
            m_cont.m_btnClose.onClick.Add(Dispose);
            m_cont.m_btnFromJson.onClick.Add(FromJson);
            Msg.Bind(MsgID.AfterScriptChanged, UpdateScriptView);
        }

        public override void Dispose()
        {
            Msg.UnBind(MsgID.AfterScriptChanged, UpdateScriptView);
            base.Dispose();
        }

        public void Init()
        {
            UpdateScriptView();
        }

        private void FromJson()
        {
            //todo
        }

        private void UpdateScriptView(object[] p = null)
        {
            m_cont.m_lstScripts.numItems = Cfg.scripts.Count;
        }

        private void ItemIR(int index, GObject g)
        {
            string id = new List<string>(Cfg.scripts.Keys)[index];
            UI_ScriptItem ui = (UI_ScriptItem)g;
            ScriptCfg cfg = Cfg.scripts[id];
            ui.m_custom.selectedIndex = cfg.createByUsers ? 1 : 0;
            ui.m_txtName.text = cfg.GetName();
            ui.m_btnPick.onClick.Add(() =>
            {
                Msg.Dispatch(MsgID.PickScript, new object[] { id });
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

        private void EditScript(string name)
        {
            FGUIUtil.CreateWindow<UI_CreateScriptWin>("CreateScriptWin").Init(name); ;
        }

        private void DeleteScript(string id)
        {
            Msg.Dispatch(MsgID.DeleteScript, new object[] { id });
        }

        
    }
}
