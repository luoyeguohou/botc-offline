using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyECS;
using System;

public class RoleSys : ISystem
{
    public override void OnAddToEngine()
    {
        Msg.Bind(MsgID.AddSpecificRole, AddSpecificRole);
        Msg.Bind(MsgID.DeleteRole, DeleteRole);
        Msg.Bind(MsgID.AddRandomTownsfolkRole, AddRandomTownsfolkRole);
        Msg.Bind(MsgID.AddRandomOutSiderRole, AddRandomOutSiderRole);
        Msg.Bind(MsgID.AddRandomMinionRole, AddRandomMinionRole);
        Msg.Bind(MsgID.AddRandomDemonRole, AddRandomDemonRole);
        Msg.Bind(MsgID.AfterPlayerRoleChanged, AfterPlayerRoleChanged);
        Msg.Bind(MsgID.DispatchRole, DispatchRole);
        Msg.Bind(MsgID.ChangePlayersRole, ChangePlayersRole);
        Msg.Bind(MsgID.AddTipRole, AddTipRole);
        Msg.Bind(MsgID.DeleteTipRole, DeleteTipRole);
        Msg.Bind(MsgID.ChangeTipRole, ChangeTipRole);
    }
    public override void OnRemoveFromEngine()
    {
        Msg.UnBind(MsgID.AddSpecificRole, AddSpecificRole);
        Msg.UnBind(MsgID.DeleteRole, DeleteRole);
        Msg.UnBind(MsgID.AddRandomTownsfolkRole, AddRandomTownsfolkRole);
        Msg.UnBind(MsgID.AddRandomOutSiderRole, AddRandomOutSiderRole);
        Msg.UnBind(MsgID.AddRandomMinionRole, AddRandomMinionRole);
        Msg.UnBind(MsgID.AddRandomDemonRole, AddRandomDemonRole);
        Msg.UnBind(MsgID.AfterPlayerRoleChanged, AfterPlayerRoleChanged);
        Msg.UnBind(MsgID.DispatchRole, DispatchRole);
        Msg.UnBind(MsgID.ChangePlayersRole, ChangePlayersRole);
        Msg.UnBind(MsgID.AddTipRole, AddTipRole);
        Msg.UnBind(MsgID.DeleteTipRole, DeleteTipRole);
        Msg.UnBind(MsgID.ChangeTipRole, ChangeTipRole);
    }


    private void AddSpecificRole(object[] p = null)
    {
        string role = (string)p[0];
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        ripComp.townsfolkNotInPlay.Remove(role);
        ripComp.outSiderNotInPlay.Remove(role);
        ripComp.minionNotInPlay.Remove(role);
        ripComp.demonNotInPlay.Remove(role);
        ripComp.roles.Add(role);
        Msg.Dispatch(MsgID.AfterRolesChange);
    }
    private void DeleteRole(object[] p = null)
    {
        string role = (string)p[0];
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        ripComp.roles.Remove(role);
        RoleCfg cfg = Cfg.roles[role];
        if (cfg.team == "townsfolk")
            ripComp.townsfolkNotInPlay.Add(cfg.id);
        if (cfg.team == "outsider")
            ripComp.outSiderNotInPlay.Add(cfg.id);
        if (cfg.team == "minion")
            ripComp.minionNotInPlay.Add(cfg.id);
        if (cfg.team == "demon")
            ripComp.demonNotInPlay.Add(cfg.id);
        Msg.Dispatch(MsgID.AfterRolesChange);
    }
    private void AddRandomTownsfolkRole(object[] p = null)
    {
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        Util.Shuffle(ripComp.townsfolkNotInPlay, new System.Random());
        ripComp.roles.Add(ripComp.townsfolkNotInPlay.Shift());
        Msg.Dispatch(MsgID.AfterRolesChange);
    }
    private void AddRandomMinionRole(object[] p = null)
    {
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        Util.Shuffle(ripComp.minionNotInPlay, new System.Random());
        ripComp.roles.Add(ripComp.minionNotInPlay.Shift());
        Msg.Dispatch(MsgID.AfterRolesChange);
    }
    private void AddRandomOutSiderRole(object[] p = null)
    {
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        Util.Shuffle(ripComp.outSiderNotInPlay, new System.Random());
        ripComp.roles.Add(ripComp.outSiderNotInPlay.Shift());
        Msg.Dispatch(MsgID.AfterRolesChange);
    }
    private void AddRandomDemonRole(object[] p = null)
    {
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        Util.Shuffle(ripComp.demonNotInPlay, new System.Random());
        ripComp.roles.Add(ripComp.demonNotInPlay.Shift());
        Msg.Dispatch(MsgID.AfterRolesChange);
    }

    private void AfterPlayerRoleChanged(object[] p = null)
    {
        string role = (string)p[0];
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        // set night order
        RoleCfg cfg = Cfg.roles[role];
        if (cfg.firstNight != 0) ripComp.firstNightOrder.Add(role);
        if (cfg.otherNight != 0) ripComp.otherNightOrder.Add(role);
        ripComp.firstNightOrder.Sort((s1, s2) => Cfg.roles[s1].firstNight - Cfg.roles[s2].firstNight);
        ripComp.otherNightOrder.Sort((s1, s2) => Cfg.roles[s1].otherNight - Cfg.roles[s2].otherNight);

        // remind tokens
        if (!ripComp.remindTokens.Contains("demon"))
            ripComp.remindTokens.Add("demon");
        if (Cfg.tipsByRole.ContainsKey(role))
        {
            foreach (var roleCfg in Cfg.tipsByRole[role])
            {
                if (!ripComp.remindTokens.Contains(roleCfg.id))
                    ripComp.remindTokens.Add(roleCfg.id);
            }
        }
    }

    private void DispatchRole(object[] p = null)
    {
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
        int playerNum = Util.Count(pComp.players, p => !p.isTraveller);
        if (playerNum != ripComp.roles.Count) return;

        List<string> rolesInPlay = new List<string>(ripComp.roles);
        Util.Shuffle(rolesInPlay, new System.Random());
        foreach (var player in pComp.players)
        {
            if (player.isTraveller) continue;
            player.role = rolesInPlay.Shift();
            RoleCfg cfg = Cfg.roles[player.role];
            player.isGood = cfg.team == "townsfolk" || cfg.team == "outsider";
            Msg.Dispatch(MsgID.AfterPlayerRoleChanged,new object[] { player.role });
        }
        Msg.Dispatch(MsgID.AfterPlayerInfoChanged);
    }
    private void ChangePlayersRole(object[] p = null)
    {
        Player player = (Player)p[0];
        string role = (string)p[1];
        PlayerComp pComp = World.e.sharedConfig.GetComp<PlayerComp>();
        if (Util.Any(pComp.players, p => p.role == role))
        {
            Player player2 = Util.Find(pComp.players, p => p.role == role);
            (player.role, player2.role) = (player2.role, player.role);
        }
        else
        {
            player.role = role;
        }
        Msg.Dispatch(MsgID.AfterPlayerInfoChanged);
        Msg.Dispatch(MsgID.AfterPlayerRoleChanged,new object[] { role});

    }
    private void AddTipRole(object[] p = null)
    {
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        Player player = new()
        {
            name = "",
            role = "",
            dead = false,
            states = new(),
            isRealPlayer = false,
        };
        ripComp.rolesForTipping.Add(player);
        Msg.Dispatch(MsgID.AfterTipRoleChanged);
    }
    private void DeleteTipRole(object[] p = null)
    {
        Player player = (Player)p[0];
        RolesInPlayComp ripComp = World.e.sharedConfig.GetComp<RolesInPlayComp>();
        ripComp.rolesForTipping.Remove(player);
        Msg.Dispatch(MsgID.AfterTipRoleChanged);
    }
    private void ChangeTipRole(object[] p = null)
    {
        Player player = (Player)p[0];
        string role = (string)p[1];
        player.role = role;
        Msg.Dispatch(MsgID.AfterTipRoleChanged);
    }
}
