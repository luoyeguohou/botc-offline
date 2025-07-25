using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyECS;

public class ScriptSys : ISystem
{
    public override void OnAddToEngine()
    {
        Msg.Bind(MsgID.UploadScript, UploadScript);
        Msg.Bind(MsgID.PickScript, PickScript);
        Msg.Bind(MsgID.DeleteScript, DeleteScript);
    }

    public override void OnRemoveFromEngine()
    {
        Msg.UnBind(MsgID.UploadScript, UploadScript);
        Msg.UnBind(MsgID.PickScript, PickScript);
        Msg.UnBind(MsgID.DeleteScript, DeleteScript);
    }

    private void UploadScript(object[] p) 
    {
        string name = (string)p[0];
        string[] roles = (string[])p[1];
        ScriptCfg cfg = new()
        {
            author = "",
            description = "",
            level = "",
            name = name,
            createByUsers = true,
            id = name,
            roles = roles,
        };
        cfg.i18NCfgs["chinese"] = new ScriptI18NCfg(name, name);
        cfg.i18NCfgs["english"] = new ScriptI18NCfg(name, name);
        //add
        Cfg.scripts[cfg.id] = cfg;
        Cfg.rolesByScript[cfg.id] = new(cfg.roles);
        // save
        Cfg.Save();
        Msg.Dispatch(MsgID.AfterScriptChanged);
    }

    private void DeleteScript(object[] p)
    {
        string id = (string)p[0];
        Cfg.scripts.Remove(id);
        Cfg.rolesByScript.Remove(id);
        // save
        Cfg.Save();
        Msg.Dispatch(MsgID.AfterScriptChanged);
    }

    private void PickScript(object[] p) {
        string id = (string)p[0];
        CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
        csComp.curr = id;
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        foreach (var role in Cfg.rolesByScript[id])
        {
            if (Cfg.roles[role].team == "townsfolk")
                ripComp.townsfolkNotInPlay.Add(role);
            if (Cfg.roles[role].team == "outsider")
                ripComp.outSiderNotInPlay.Add(role);
            if (Cfg.roles[role].team == "minion")
                ripComp.minionNotInPlay.Add(role);
            if (Cfg.roles[role].team == "demon")
                ripComp.demonNotInPlay.Add(role);
        }
        Msg.Dispatch(MsgID.AfterPickScript);
    }
}
