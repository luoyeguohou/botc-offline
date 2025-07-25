public enum MsgID
{
    PickScript,
    UploadScript,
    DeleteScript,
    AfterScriptChanged,
    AfterPickScript,

    AddPlayer,
    DeletePlayer,
    ChangeSeat,
    MoveToSeat,
    ChangeTraveller,
    AfterPlayerNumChanged,
    AfterChangeSeat,

    AddSpecificRole,
    DeleteRole,
    AddRandomTownsfolkRole,
    AddRandomOutSiderRole,
    AddRandomMinionRole,
    AddRandomDemonRole,
    ConfirmRole, 
    DispatchRole,
    ChangePlayersRole,
    AfterRolesChange,
    AfterDrawRole,

    AddTipRole,
    DeleteTipRole,
    ChangeTipRole,
    AfterTipRoleChanged,

    ChangeAlignment,
    ChangeDeadVote,
    ChangeDead,
    AfterPlayerInfoChanged,
    AfterPlayerRoleChanged,
    AddRemindTokens,
    RemoveRemindTokens,

    LoadGame,
    AfterLoadGame,
}
