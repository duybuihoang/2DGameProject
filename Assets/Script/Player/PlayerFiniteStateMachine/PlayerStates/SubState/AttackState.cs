using DuyBui.Weapon.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerAbilityState
{
    private Weapon weapon;

    public AttackState(Player player,
        PlayerStateMachine stateMachine, 
        PlayerData playerData,
        string animBoolName,
        Weapon weapon
        
        ) : base(player, stateMachine, playerData, animBoolName)
    {
        this.weapon = weapon;
        weapon.onExit += ExitHandler;
    }

    public override void Enter()
    {
        base.Enter();
        weapon.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    private void ExitHandler()
    {
        AnimationFinishTrigger();
        isAbilityDone = true;
    }


}
