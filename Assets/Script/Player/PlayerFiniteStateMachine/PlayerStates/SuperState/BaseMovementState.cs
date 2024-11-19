using DuyBui.CoreSystem;
using DuyBui.Weapon.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovementState : PlayerState
{
    protected Vector2 input;
    protected Vector2 mousePos;
    protected float inputX;

    private Weapon weapon;

    protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;

    private bool rollInput;


    public BaseMovementState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, Weapon weapon) : base(player, stateMachine, playerData, animBoolName)
    {
        this.weapon = weapon;
    }

    public override void Enter()
    {
        base.Enter();
        player.rollState.ResetCanDash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();


        input = player.InputHandler.RawMovementInput;
        inputX = player.InputHandler.inputX;
        mousePos = player.InputHandler.MouseInput;
        rollInput = player.InputHandler.RollInput;

        if(!weapon.isAttacking)
        {
            Movement?.CheckIfShouldFlip(mousePos);
        }

        if(rollInput && player.rollState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.rollState);
        }
    }

}
