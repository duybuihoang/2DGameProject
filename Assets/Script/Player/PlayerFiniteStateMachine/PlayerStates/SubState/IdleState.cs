using DuyBui.Weapon.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseMovementState
{
    public IdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, Weapon weapon) : base(player, stateMachine, playerData, animBoolName, weapon)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

    }

    public override void Enter()
    {
        base.Enter();
        Movement?.SetVelocityZero();

    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExistingState)
        {
            if(input != Vector2.zero)
            {
                stateMachine.ChangeState(player.moveState);
            }
        }    
    }
}
