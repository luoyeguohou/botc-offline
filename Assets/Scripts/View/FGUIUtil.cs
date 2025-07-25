using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;
using System;
using System.Threading.Tasks;
using UnityEngine.UIElements;

public class FGUIUtil
{
    public static void SetWorldPos(GObject g, Vector3 pos)
    {
        g.position = g.parent.GlobalToLocal(pos);
    }
    public static Vector3 GetWorldPos(GObject g)
    {
        return g.LocalToGlobal(new Vector3());
    }

    public static void SetSamePos(GObject follower, GObject aim)
    {
        SetWorldPos(follower, GetWorldPos(aim));
    }

    public static T CreateWindow<T>(string name) where T : FairyWindow
    {
        GComponent gcom = UIPackage.CreateObject("Main", name).asCom;
        GRoot.inst.AddChild(gcom);
        gcom.MakeFullScreen();
        return (T)gcom;
    }

    public static void ClearHint(GObject g)
    {
        g.onRollOver.Clear();
        g.onRollOut.Clear();
    }

    
    public static Task<bool> PlayCoinAni()
    {
        var tcs = new TaskCompletionSource<bool>();
        GComponent gcom = UIPackage.CreateObject("Main", "CoinAni").asCom;
        GRoot.inst.AddChild(gcom);
        gcom.MakeFullScreen();
        gcom.GetTransition("idle").Play(() => {
            gcom.Dispose();
            tcs.SetResult(true);
        });
        return tcs.Task;
    }

    public static void ShowMsg(string msg)
    {
        try
        {
            UI_HintMessage win = (UI_HintMessage)UIPackage.CreateObject("Main", "HintMessage").asCom;
            win.touchable = false;
            GRoot.inst.AddChild(win);
            win.Center();
            win.Init(msg);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
