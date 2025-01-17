using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class EW_MeleeAttackState : MeleeAttackState
    {
        private EvilWizard enemy;
        public EW_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, EvilWizard enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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
