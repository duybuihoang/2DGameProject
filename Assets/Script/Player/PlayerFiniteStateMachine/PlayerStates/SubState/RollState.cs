using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RollState : PlayerAbilityState
{
    public bool canRoll { get; private set; }
    private float lastRollTime;

    private Vector2 lastAIPos;
    private Vector2 rollDirection;



    public RollState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public bool CheckIfCanDash()
    {
        return canRoll && Time.time >= lastRollTime + playerData.rollCooldown;
    }

    public void ResetCanDash() => canRoll = true;
    private void PlaceAfterImage()
    {
        //        PlayerAfterImagePool.Instance.GetFromPool();
        lastAIPos = player.transform.position;
    }

    private void CheckIfShouldPlaceAfterImage()
    {
        if (Vector2.Distance(player.transform.position, lastAIPos) >= playerData.distBetweenAfterImages)
        {
            PlaceAfterImage();
        }
    }
    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseRollInput();
        canRoll = false;
        //TODO: make mouse input to screen point and calculate direction vector
        rollDirection = (Camera.main.ScreenToWorldPoint(player.InputHandler.MouseInput  ) - player.transform.position).normalized;
    }

    public override void Exit()
    {
        base.Exit();
    }



    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExistingState)
        {
            Movement?.SetVelocity(rollDirection, playerData.rollVelocity);
            //CheckIfShouldPlaceAfterImage();

            if(Time.time >= startTime + playerData.rollTime)
            {
                //player.RB.drag = 0f;
                isAbilityDone = true;
                lastRollTime = Time.time;
            }

        }
    }
}

