using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    protected bool isAbilityDone;

    private Movement movement;
    protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }

    public override void Enter()
    {
        base.Enter();
        isAbilityDone = false;  
    }

    public override void Exit()
    {
        base.Exit();
        isAbilityDone = true;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAbilityDone)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

}
