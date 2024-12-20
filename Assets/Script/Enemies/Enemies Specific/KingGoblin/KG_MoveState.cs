using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class KG_MoveState : MoveState
    {
        private KingGoblin enemy;

        public KG_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, KingGoblin enemy) : base(entity, stateMachine, animBoolName, stateData)
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
