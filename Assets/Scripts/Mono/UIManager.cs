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
        UIPackage.AddPackage("UI/Main");
        MainBinder.BindAll();
        FGUIUtil.CreateWindow<UI_MainWin>("MainWin").Init();
    }
}
