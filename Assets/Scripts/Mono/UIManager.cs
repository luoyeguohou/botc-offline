using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

public class UIManager 
{
    public static void Init()
    {
        UIPackage.RemoveAllPackages();
        string fileContent = Resources.Load<TextAsset>(Cfg.language).text;
        FairyGUI.Utils.XML xml = new(fileContent);
        UIPackage.SetStringsSource(xml);
        //UIConfig.defaultFont = "Font2";
        UIPackage.AddPackage("UI/Main");
        //UIConfig.buttonSound = (NAudioClip)UIPackage.GetItemAssetByURL("ui://Main/buttonEff");
        MainBinder.BindAll();
        FGUIUtil.CreateWindow<UI_NewMainWin>("NewMainWin").Init();
    }

    public static List<FairyWindow> windows = new();

    public static FairyWindow GetCurrWindow()
    {
        if (windows.Count == 0) return null;
        return windows[^1];
    }

    //public static bool IsCurrMainWin()
    //{
    //    FairyWindow win = GetCurrWindow();
    //    if (win == null) return false;
    //    return win is UI_MainWin;
    //}

    public static bool HasType<T>() where T : FairyWindow
    {
        foreach (FairyWindow win in windows)
            if (win.GetType() == typeof(T)) return true;
        return false;
    }
    public static T GetType<T>() where T : FairyWindow
    {
        foreach (FairyWindow win in windows)
            if (win.GetType() == typeof(T)) return (T)win;
        return null;
    }
}
