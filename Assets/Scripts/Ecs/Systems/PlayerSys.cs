using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyECS;

public class PlayerSys : ISystem
{
    public override void OnAddToEngine()
    {
        Msg.Bind(MsgID.AddPlayer, AddPlayer);
        Msg.Bind(MsgID.DeletePlayer, DeletePlayer);
        Msg.Bind(MsgID.ChangeSeat, ChangeSeat);
        Msg.Bind(MsgID.MoveToSeat, MoveToSeat);
        Msg.Bind(MsgID.ChangeTraveller, ChangeTraveller);
        Msg.Bind(MsgID.ChangeAlignment, ChangeAlignment);
        Msg.Bind(MsgID.ChangeDeadVote, ChangeDeadVote);
        Msg.Bind(MsgID.ChangeDead, ChangeDead);
        Msg.Bind(MsgID.AddRemindTokens, AddRemindTokens);
        Msg.Bind(MsgID.RemoveRemindTokens, RemoveRemindTokens);
    }

    public override void OnRemoveFromEngine()
    {
        Msg.UnBind(MsgID.AddPlayer, AddPlayer);
        Msg.UnBind(MsgID.DeletePlayer, DeletePlayer);
        Msg.UnBind(MsgID.ChangeSeat, ChangeSeat);
        Msg.UnBind(MsgID.MoveToSeat, MoveToSeat);
        Msg.UnBind(MsgID.ChangeTraveller, ChangeTraveller);
        Msg.UnBind(MsgID.ChangeAlignment, ChangeAlignment);
        Msg.UnBind(MsgID.ChangeDeadVote, ChangeDeadVote);
        Msg.UnBind(MsgID.ChangeDead, ChangeDead);
        Msg.UnBind(MsgID.AddRemindTokens, AddRemindTokens);
        Msg.UnBind(MsgID.RemoveRemindTokens, RemoveRemindTokens);
    }

    private void AddPlayer(object[] p = null)
    {
        PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
        Player player = new() { name = "" };
        pComp.players.Add(player);
        Msg.Dispatch(MsgID.AfterPlayerNumChanged);
    }
    private void DeletePlayer(object[] p = null) {
        Player player = (Player)p[0];
        PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
        pComp.players.Remove(player);
        Msg.Dispatch(MsgID.AfterPlayerNumChanged);

    }
    private void ChangeSeat(object[] p = null) {
        Player p1 = (Player)p[0];
        Player p2 = (Player)p[1];
        PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
        int index1 = pComp.players.IndexOf(p1);
        int index2 = pComp.players.IndexOf(p2);
        (pComp.players[index1], pComp.players[index2]) = (pComp.players[index2], pComp.players[index1]);
        Msg.Dispatch(MsgID.AfterChangeSeat);
    }

    private void MoveToSeat(object[] p = null)
    {
        Player player = (Player)p[0];
        int index = (int)p[1];
        Debug.Log("MoveToSeat " + index);
        PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
        int oriIndex = pComp.players.IndexOf(player);
        pComp.players.Remove(player);
        pComp.players.Insert(index + (oriIndex < index ? -1 : 0), player);
        Msg.Dispatch(MsgID.AfterChangeSeat);
    }

    private void ChangeTraveller(object[] p = null)
    {
        Player player = (Player)p[0];
        player.isTraveller = !player.isTraveller;
        Msg.Dispatch(MsgID.AfterPlayerInfoChanged);
    }

    private void ChangeAlignment(object[] p = null)
    { 
        Player player = (Player)p[0];
        player.isGood = !player.isGood;
        Msg.Dispatch(MsgID.AfterPlayerInfoChanged);
    }

    private void ChangeDeadVote(object[] p = null)
    {
        Player player = (Player)p[0];
        player.hasDeadVote = !player.hasDeadVote;
        Msg.Dispatch(MsgID.AfterPlayerInfoChanged);
    }

    private void ChangeDead(object[] p = null)
    {
        Player player = (Player)p[0];
        player.dead = !player.dead;
        Msg.Dispatch(MsgID.AfterPlayerInfoChanged);
    }

    private void AddRemindTokens(object[] p = null)
    {
        Player player = (Player)p[0];
        string remindToken = (string)p[1];
        player.states.Add(remindToken);
        Msg.Dispatch(MsgID.AfterPlayerInfoChanged);
    }

    private void RemoveRemindTokens(object[] p = null)
    {
        Player player = (Player)p[0];
        string remindToken = (string)p[1];
        player.states.Remove(remindToken);
        Msg.Dispatch(MsgID.AfterPlayerInfoChanged);
    }
}
