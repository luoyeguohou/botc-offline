using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyECS;
using LitJson;

public class GameSys : ISystem
{
    public override void OnAddToEngine()
    {
        Msg.Bind(MsgID.AfterTipRoleChanged, SaveGame);
        Msg.Bind(MsgID.AfterPlayerInfoChanged, SaveGame);
        Msg.Bind(MsgID.LoadGame,LoadGame);
    }

    public override void OnRemoveFromEngine()
    {
        Msg.UnBind(MsgID.LoadGame,LoadGame);
        Msg.UnBind(MsgID.AfterTipRoleChanged, SaveGame);
        Msg.UnBind(MsgID.AfterPlayerInfoChanged, SaveGame);
    }

    private void SaveGame(object[] p = null) {
        Game g = new Game();
        PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
        g.players = pComp.players;
        g.tipPlayers = ripComp.rolesForTipping;
        g.rolesInPlay = ripComp.roles;
        g.remindTokens = ripComp.remindTokens;
        g.firstNightOrder = ripComp.firstNightOrder;
        g.secondNightOrder = ripComp.otherNightOrder;
        g.currScript = csComp.curr;
        PlayerPrefs.SetString("game", JsonMapper.ToJson(g));
    }

    private void LoadGame(object[] p = null)
    {
        string gameStr = PlayerPrefs.GetString("game", "");
        if (gameStr == "")
        {
            if (Cfg.language == "chinese")
                FGUIUtil.ShowMsg("没有游戏记录！！！");
            else
                FGUIUtil.ShowMsg("No game record！！！");
            return;
        }
        Game game = JsonMapper.ToObject<Game>(gameStr);

        PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        CurrScriptComp csComp = World.e.sharedConfig.GetComp<CurrScriptComp>();
        pComp.players = game.players;

        ripComp.rolesForTipping = game.tipPlayers;
        ripComp.roles = game.rolesInPlay;
        ripComp.remindTokens = game.remindTokens;
        ripComp.firstNightOrder = game.firstNightOrder;
        ripComp.otherNightOrder = game.secondNightOrder;
        csComp.curr = game.currScript;

        Msg.Dispatch(MsgID.AfterLoadGame);
    }
}

public class Game {
    public List<Player> players;
    public List<Player> tipPlayers;
    public List<string> rolesInPlay;
    public List<string> remindTokens;
    public List<string> firstNightOrder;
    public List<string> secondNightOrder;
    public string currScript;
}
