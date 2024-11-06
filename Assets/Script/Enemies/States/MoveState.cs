using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class MoveState : State
    {
        protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private Movement movement;

        protected D_MoveState stateData;

        protected bool isRoamingOver;
        protected float randomRoamingTime;

        protected Vector2 roamingDirection;


        public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
        {
            this.stateData = stateData;
        }

        public override void Enter()
        {
            base.Enter();

            roamingDirection = entity.GetRoamingPosition();
            if(roamingDirection.x * Movement.FacingDirection < 0f)
            {
                Movement?.Flip();
            }

            Movement?.SetVelocity(roamingDirection, stateData.movementSpeed);
            isRoamingOver = false;
            SetRandomRoamingTime();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            Movement?.SetVelocity(roamingDirection, stateData.movementSpeed);

            if (Time.time >= startTime + randomRoamingTime)
            {
                isRoamingOver = true;
            }
        }

        private void SetRandomRoamingTime()
        {
            randomRoamingTime = Random.Range(stateData.minRoamingTime, stateData.maxRoamingTime);
        }
    }
}
