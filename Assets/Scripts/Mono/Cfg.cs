using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Cfg
{
    public static List<string> supportLanguages = new() { "chinese", "english" };
    public static string language = "chinese";

    public static Dictionary<string, RoleCfg> roles = new();
    public static Dictionary<string, List<string >> rolesByScript = new();
    public static Dictionary<string, ScriptCfg> scripts = new();

    public static void Init()
    {
        string rolesText = Resources.Load<TextAsset>("ExcelCfg/roles").text;
        string scriptsText = Resources.Load<TextAsset>("ExcelCfg/editions").text;
        JsonData rolesJd = JsonMapper.ToObject(rolesText);
        JsonData scriptsJd = JsonMapper.ToObject(scriptsText);
        JsonData scripts2Jd = JsonMapper.ToObject(PlayerPrefs.GetString("scripts","[]"));
        foreach (JsonData d in rolesJd)
        {
            RoleCfg cfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(RoleCfg)) as RoleCfg;
            roles[cfg.id] = cfg;
            Debug.Log(cfg.ability);
            if (!rolesByScript.ContainsKey(cfg.edition)) rolesByScript[cfg.edition] = new();
            rolesByScript[cfg.edition].Add(cfg.id);
        }
        foreach (JsonData d in scriptsJd)
        {
            ScriptCfg cfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(ScriptCfg)) as ScriptCfg;
            cfg.createByUsers = false;
            scripts[cfg.id] = cfg;

            Debug.Log(cfg.description);
            if (cfg.roles.Length != 0) {
                rolesByScript[cfg.id] = new(cfg.roles);
            }
        }
        Debug.Log(PlayerPrefs.GetString("scripts", "[]"));
        foreach (JsonData d in scripts2Jd)
        {
            Debug.Log(d);
            Debug.Log(d.ToJson());
            Debug.Log(d.ToJson().ToString());
            ScriptCfg cfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(ScriptCfg)) as ScriptCfg;
            cfg.createByUsers = true;
            scripts[cfg.id] = cfg;
            Debug.Log(cfg.description);
            if (cfg.roles.Length != 0)
            {
                rolesByScript[cfg.id] = new(cfg.roles);
            }
        }


    }

    public static void Save() {
        List<ScriptCfg> scriptsTemp = new ();
        foreach (var item in scripts)
        {
            if (item.Value.createByUsers) {
                scriptsTemp.Add(item.Value);
            }
        }
        PlayerPrefs.SetString("scripts", JsonMapper.ToJson(scriptsTemp.ToArray()));
    }
}