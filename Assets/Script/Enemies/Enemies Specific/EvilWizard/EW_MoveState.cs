using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class EW_MoveState : MoveState
    {
        private EvilWizard enemy;
        public EW_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, EvilWizard enemy) : base(entity, stateMachine, animBoolName, stateData)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isPlayerInAttackRange)
            {
                stateMachine.ChangeState(enemy.attackState);

            }
            else if (!isPlayerInDetectedRange)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }
    }
}
