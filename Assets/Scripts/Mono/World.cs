using TinyECS;

public class World
{
    public static Engine e;
    public static void Init()
    {
        e = new Engine();
        // add comp to sharedConfig
        e.sharedConfig.AddComp(new CurrScriptComp());
        e.sharedConfig.AddComp(new RolesInPlayComp());
        e.sharedConfig.AddComp(new PlayerComp());
        e.sharedConfig.AddComp(new NameComp());

        // add system
        e.AddSystem(new ScriptSys());
        e.AddSystem(new PlayerSys());
        e.AddSystem(new RoleSys());
        e.AddSystem(new GameSys());
    }
}
