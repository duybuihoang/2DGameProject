using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class TG_MoveState : MoveState
    {
        private TorchGoblin enemy;
        public TG_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, TorchGoblin enemy) : base(entity, stateMachine, animBoolName, stateData)
        {
            this.enemy = enemy;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();



            if(isRoamingOver)
            {
                //if(roamingDirection.x * Movement.FacingDirection < 0)
                //{
                //    enemy.idleState.SetFlipAfterIdle(true);
                //}

                stateMachine.ChangeState(enemy.idleState);
            }
        }
    }
}
