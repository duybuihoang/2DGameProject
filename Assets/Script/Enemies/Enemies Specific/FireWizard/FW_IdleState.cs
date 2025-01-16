using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class FW_IdleState : IdleState
    {
        private FireWizard enemy;
        public FW_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, FireWizard enemy) : base(entity, stateMachine, animBoolName, stateData)
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
            if (isPlayerInDetectedRange && isIdleTimeOver)
            {
                stateMachine.ChangeState(enemy.moveState);
            }
        }

    }
}
