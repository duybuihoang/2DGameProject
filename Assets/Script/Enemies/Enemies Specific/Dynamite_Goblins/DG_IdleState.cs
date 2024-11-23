using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class DG_IdleState : IdleState
    {
        private DynamiteGoblin enemy;
        public DG_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, DynamiteGoblin enemy) : base(entity, stateMachine, animBoolName, stateData)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
            Movement?.SetVelocityZero();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isIdleTimeOver || isPlayerInDetectedRange)
            {
                stateMachine.ChangeState(enemy.moveState);
            }
        }
    }
}
