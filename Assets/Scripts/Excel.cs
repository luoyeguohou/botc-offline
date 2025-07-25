using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class ScriptI18NCfg
{
    public string id;
    public string name;
    public ScriptI18NCfg() { }

    public ScriptI18NCfg(string id, string name)
    {
        this.id = id;
        this.name = name;
    }
}
public class ScriptCfg {
    public string id;
    public string name;
    public string author;
    public string description;
    public string level;
    public bool isOfficial;
    public string[] roles;
    public bool createByUsers;
    public bool fromJson;
    public Dictionary<string, ScriptI18NCfg> i18NCfgs = new();

    public string GetName() {
        return i18NCfgs[Cfg.language].name;
    }

}

public class RoleI18NCfg {
    public string id;
    public string name;
    public string ability;
}

public class RoleCfg {
    public string id;
    public string name;
    public string edition;
    public string team;
    public int firstNight;
    public string firstNightReminder;
    public int otherNight;
    public string otherNightReminder;
    public bool setup;
    public string ability;
    public Dictionary<string, RoleI18NCfg> i18NCfgs = new();
    public string GetName()
    {
        return i18NCfgs[Cfg.language].name;
    }
    public string GetAbility()
    {
        return i18NCfgs[Cfg.language].ability;
    }
}

public class TipCfg {
    public string id;
    public string role;
    public string chinese;
    public string english;
    public string GetText()
    {
        return Cfg.language == "english"? english:chinese;
    }
}