using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consts : MonoBehaviour
{
    public static readonly int[,] roleNums = new int[,] {
           {3,0,1,1},
           {3,1,1,1},
           {5,0,1,1},
           {5,1,1,1},
           {5,2,1,1},
           {7,0,2,1},
           {7,1,2,1,},
           {7,2,2,1},
           {9,0,3,1},
           {9,1,3,1},
           {9,2,3,1},
        };
    public static readonly string[] words = {
        "Master",
        "Is the Drunk",
        "Drunk",
        "Die",
        "Protected",
        "Poisoned",
        "Is Demon",
        "Used",
        "Executed",
        "Good",
        "Evil",
        "Vote",
        "Negative vote",
        "Alive",
        "No death today",
        "Decoy",
        "FT's Decoy",
        "Invest's Decoy",
        "Invest's Minion",
        "Lib's Decoy",
        "Lib's Outsider",
        "Washer's Townsfolk",
        "Washer's Decoy",
        "Nominate Evil",
        "Nominate Good",
    };
    public static readonly string[] showingWords = {
        "This is the demon",
        "These characters are not in play",
        "This ability targeted you",
        "You are",
        "This player is",
        "You have this ability",
        "These characters are in play",
        "These are your minions",
        "Did you vote today?",
        "Your choice?",
        "Use your ability now?",
        "Did you nominate today?",
    };

    public static readonly string[] showingChineseWords = {
        "这个是恶魔",
        "这些角色不在场",
        "这个能力选中了你",
        "你是",
        "这个玩家是",
        "你有这个能力",
        "这些角色在场",
        "这些人是你的爪牙",
        "你今天投票了么？",
        "你的选择是？",
        "你用你的能力吗?",
        "你今天提名了吗?",
    };
}