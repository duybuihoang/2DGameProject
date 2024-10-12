using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseMovementState
{
    public IdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        Movement?.CheckIfShouldFlip(mousePos,inputX);

        if (!isExistingState)
        {
            if(input != Vector2.zero)
            {
                stateMachine.ChangeState(player.moveState);
            }
        }    
    }
}
