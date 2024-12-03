using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class AttackState : State
    {
        protected Transform attackPosition;
        protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private Movement movement;

        protected bool isAnimationFinish;
        protected bool isPlayerInAttackRange;

        public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
        {
            this.attackPosition = attackPosition;
        }

        public override void DoChecks()
        {
            base.DoChecks();
            isPlayerInAttackRange = entity.CheckPlayerInAttackRangeAction();
        }

        public override void Enter()
        {
            base.Enter();

            entity.atsm.attackState = this;
            isAnimationFinish = false;
            Movement?.SetVelocityZero();
        }

        public virtual void TriggerAttack()
        {
            //Debug.Log("TriggerAttack");
        }

        public virtual void FinishAttack()
        {
            isAnimationFinish = true;
        }
    }
}
