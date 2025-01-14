using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class KG_IdleState : IdleState
    {
        private KingGoblin enemy;
        public KG_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, KingGoblin enemy) : base(entity, stateMachine, animBoolName, stateData)
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
            if(Time.time >= summonTime +  enemy.summonState.stateData.summonInterval)
            {
                summonTime = Time.time;
                stateMachine.ChangeState(enemy.summonState);
            }    
            else if (isPlayerInDetectedRange)
            {
                stateMachine.ChangeState(enemy.moveState);
            }
            else
            {
                if (Stats.currentHealth < Stats.maxHealth)
                {
                    stateMachine.ChangeState(enemy.healState);
                }
            }
        }
    }
}
