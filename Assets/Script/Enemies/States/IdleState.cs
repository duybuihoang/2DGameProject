using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class IdleState : State
    {
        protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private Movement movement;
        protected Stats Stats { get => stats ?? core.GetCoreComponent(ref stats); }
        private Stats stats;

        protected D_IdleState stateData;

        protected bool isIdleTimeOver;
        protected bool isPlayerInDetectedRange;

        protected float idleTime;

        protected float summonTime;


        public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
        {
            this.stateData = stateData;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isPlayerInDetectedRange = entity.CheckPlayerInDetectedRange();
        }

        public override void Enter()
        {
            base.Enter();

            Movement.SetVelocityZero();
            isIdleTimeOver = false;
            SetRandomIdleTime();
            
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(Time.time >= startTime + idleTime)
            {
                isIdleTimeOver = true;
            }
        }
        public override void Exit()
        {
            base.Exit();
        }

        private void SetRandomIdleTime()
        {
            idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
        }
    }
}
