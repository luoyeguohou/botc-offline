using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class Cfg
{
    public static List<string> supportLanguages = new() { "chinese", "english" };
    public static string language = "english";

    public static Dictionary<string, RoleCfg> roles = new();
    public static Dictionary<string, List<string>> rolesByScript = new();
    public static List<string> travellers= new();
    public static Dictionary<string, ScriptCfg> scripts = new();
    public static Dictionary<string, TipCfg> tips = new();
    public static Dictionary<string, List<TipCfg>> tipsByRole = new();

    public static void Init()
    {
        language = PlayerPrefs.GetString("language", "english");
        string tipText = Resources.Load<TextAsset>("ExcelCfg/design").text;
        string rolesText = Resources.Load<TextAsset>("ExcelCfg/roles").text;
        string scriptsText = Resources.Load<TextAsset>("ExcelCfg/editions").text;
        string rolesChineseText = Resources.Load<TextAsset>("ExcelCfg/roles-chinese").text;
        string scriptsChineseText = Resources.Load<TextAsset>("ExcelCfg/editions-chinese").text;
        JsonData tipJson = JsonMapper.ToObject(tipText);
        JsonData rolesJd = JsonMapper.ToObject(rolesText);
        JsonData rolesChineseJd = JsonMapper.ToObject(rolesChineseText);
        JsonData scriptsJd = JsonMapper.ToObject(scriptsText);
        JsonData scriptsChineseJd = JsonMapper.ToObject(scriptsChineseText);
        JsonData scripts2Jd = JsonMapper.ToObject(PlayerPrefs.GetString("scripts", "[]"));
        int cnt = 0;
        int town = 0;
        int outs = 0;
        int minions = 0;
        int demon = 0;
        List<string> townsfolk = new();
        foreach (JsonData d in rolesJd)
        {
            RoleCfg cfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(RoleCfg)) as RoleCfg;
            roles[cfg.id] = cfg;
            if (!rolesByScript.ContainsKey(cfg.edition)) rolesByScript[cfg.edition] = new();
            rolesByScript[cfg.edition].Add(cfg.id);

            RoleI18NCfg rCfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(RoleI18NCfg)) as RoleI18NCfg;
            cfg.i18NCfgs["english"] = rCfg;

            if (cfg.team == "traveler")
            {
                travellers.Add(cfg.id);
            }

            if (cfg.edition == "")
            {
                cnt++;
                if (cfg.team == "townsfolk") {
                        town++;
                    townsfolk.Add(cfg.id);
                }
                if (cfg.team == "outsider") {

                    outs++; }
                if (cfg.team == "minion") { 
                    minions++; }
                if (cfg.team == "demon"){
                      Debug.Log(cfg.id);
                    demon++;
                }
            }
        }
        Debug.Log(town);
        Debug.Log(outs);
        Debug.Log(minions);
        Debug.Log(demon);
        Debug.Log(cnt);
        townsfolk.Sort();
        //foreach (var item in townsfolk)
        //{
        //    Debug.Log(item);
        //}
        foreach (JsonData d in rolesChineseJd)
        {
            RoleI18NCfg rCfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(RoleI18NCfg)) as RoleI18NCfg;
            roles[rCfg.id].i18NCfgs["chinese"] = rCfg;
        }
        foreach (JsonData d in scriptsJd)
        {
            ScriptCfg cfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(ScriptCfg)) as ScriptCfg;
            cfg.createByUsers = false;
            scripts[cfg.id] = cfg;

            if (cfg.roles.Length != 0)
            {
                rolesByScript[cfg.id] = new(cfg.roles);
            }

            ScriptI18NCfg rCfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(ScriptI18NCfg)) as ScriptI18NCfg;
            cfg.i18NCfgs["english"] = rCfg;
        }
        foreach (JsonData d in scriptsChineseJd)
        {
            ScriptI18NCfg rCfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(ScriptI18NCfg)) as ScriptI18NCfg;
            scripts[rCfg.id].i18NCfgs["chinese"] = rCfg;
        }
        foreach (JsonData d in scripts2Jd)
        {
            ScriptCfg cfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(ScriptCfg)) as ScriptCfg;
            cfg.createByUsers = true;
            scripts[cfg.id] = cfg;
            if (cfg.roles.Length != 0)
            {
                rolesByScript[cfg.id] = new(cfg.roles);
            }
            cfg.i18NCfgs["chinese"] = new()
            {
                id = cfg.id,
                name = cfg.name,
            };
            cfg.i18NCfgs["english"] = new()
            {
                id = cfg.id,
                name = cfg.name,
            };

        }

        foreach (JsonData d in tipJson["tipCfg"])
        {
            TipCfg cfg = JsonUtility.FromJson(d.ToJson().ToString(), typeof(TipCfg)) as TipCfg;
            tips[cfg.id] = cfg;
            if (!tipsByRole.ContainsKey(cfg.role))
                tipsByRole[cfg.role] = new();
            tipsByRole[cfg.role].Add(cfg);
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