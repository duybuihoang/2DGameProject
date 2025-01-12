using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class KG_MeleeAttackState : MeleeAttackState
    {
        private KingGoblin enemy;

        public KG_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData, KingGoblin enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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
