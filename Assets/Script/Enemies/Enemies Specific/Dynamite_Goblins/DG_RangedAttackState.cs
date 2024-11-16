using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class DG_RangedAttackState : RangedAttackState
    {
        private DynamiteGoblin enemy;
        public DG_RangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, DynamiteGoblin enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
        {
            this.enemy = enemy;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationFinish)
            {
                if (!isPlayerInAttackRange)
                {
                    stateMachine.ChangeState(enemy.idleState);
                }
            }
        }
    }
}
