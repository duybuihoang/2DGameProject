using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class EW_IdleState : IdleState
    {
        private EvilWizard enemy;
        public EW_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, EvilWizard enemy) : base(entity, stateMachine, animBoolName, stateData)
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
            if (isPlayerInDetectedRange)
            {
                stateMachine.ChangeState(enemy.moveState);
            }
        }
    }
}
