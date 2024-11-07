using DuyBui.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class TG_IdleState : IdleState
    {
        private TorchGoblin enemy;

        public TG_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, TorchGoblin enemy) : base(entity, stateMachine, animBoolName, stateData)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(isIdleTimeOver || isPlayerInDetectedRange)
            {
                stateMachine.ChangeState(enemy.moveState);
            }    
        }

    }
}
