public class ScriptCfg {
    public string id;
    public string name;
    public string author;
    public string description;
    public string level;
    public bool isOfficial;
    public string[] roles;
    public bool createByUsers;
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
}