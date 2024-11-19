using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DashState : PlayerAbilityState
{
    public DashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }
}

