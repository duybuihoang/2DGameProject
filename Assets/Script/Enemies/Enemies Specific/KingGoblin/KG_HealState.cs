using DuyBui.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class KG_HealState : HealState
    {
        private KingGoblin enemy;

        public KG_HealState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_HealState stateData, KingGoblin enemy) : base(entity, stateMachine, animBoolName, stateData)
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

            if(isAnimationFinish)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }
    }
}
