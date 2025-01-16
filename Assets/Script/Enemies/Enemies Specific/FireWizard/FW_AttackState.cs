using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class FW_AttackState : RangedAttackState
    {
        private FireWizard enemy;
        public FW_AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, FireWizard enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
        {
            this.enemy = enemy;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (isAnimationFinish)
            {
                 stateMachine.ChangeState(enemy.idleState);   
            }
        }
    }
}
