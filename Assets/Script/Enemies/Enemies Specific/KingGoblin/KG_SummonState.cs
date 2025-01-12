using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class KG_SummonState : SummonState
    {
        private KingGoblin enemy;

        public KG_SummonState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_SummonState stateData, KingGoblin enemy) : base(entity, stateMachine, animBoolName, stateData)
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

            if (isAnimationFinish)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }
    }
}
