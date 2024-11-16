using DuyBui.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class DG_MoveState : MoveState
    {
        private DynamiteGoblin enemy;

        public DG_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, DynamiteGoblin enemy) : base(entity, stateMachine, animBoolName, stateData)
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
            else if (isRoamingOver && !isPlayerInDetectedRange)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }
    }
}
