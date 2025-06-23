using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TinyECS;

public class CurrScriptComp : IComponent
{
    public string curr;
}

public class RolesInPlayComp : IComponent
{
    public List<string> roles = new();
    public List<string> townsfolkNotInPlay = new();
    public List<string> outSiderNotInPlay = new();
    public List<string> minionNotInPlay = new();
    public List<string> demonNotInPlay = new();
    public List<string> firstNightOrder = new();
    public List<string> otherNightOrder = new();
}

public class Player
{
    public string name;
    public string role;
    public bool dead;
    public List<string> states = new();
}

public class PlayerComp : IComponent
{
    public List<Player> players = new();
    public int drawingFromIdx;
    public int howMangDrawed;
    public bool clockWise;
}

public class NameComp : IComponent 
{
    public List<string> names = new();
}
