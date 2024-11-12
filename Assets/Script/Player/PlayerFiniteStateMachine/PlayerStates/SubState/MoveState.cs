using DuyBui.Weapon.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class MoveState : BaseMovementState
{
    public MoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, Weapon weapon) : base(player, stateMachine, playerData, animBoolName, weapon)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Movement?.SetVelocity(input, playerData.movementVelocity);

        if (!isExistingState)
        {
            if (input == Vector2.zero)
            {
                stateMachine.ChangeState(player.idleState);
            }    
        }
    }



}
