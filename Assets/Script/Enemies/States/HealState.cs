using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class HealState : State
    {
        protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private Movement movement;
        protected DamageReceiver DamageReceiver { get => damageReceiver ?? core.GetCoreComponent(ref damageReceiver); }
        private DamageReceiver damageReceiver;
        protected Stats Stats { get => stats ?? core.GetCoreComponent(ref stats); }
        private Stats stats;

        protected D_HealState stateData;

        protected bool isAnimationFinish;
        protected bool isPlayerInAttackRange;

        public HealState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_HealState stateData) : base(entity, stateMachine, animBoolName)
        {
            this.stateData = stateData;
        }

        public override void Enter()
        {
            base.Enter();

            isAnimationFinish = false;
            entity.atsm.healState = this;
            DamageReceiver.Vulnerable = false;
        }

        public override void Exit()
        {
            base.Exit();
            DamageReceiver.Vulnerable = true;
        }

        public virtual void FinishHeal()
        {
            isAnimationFinish = true;
        }
        public virtual void TriggerHeal()
        {
            Stats.IncreaseHealth(stateData.amount);
        }
    }
}
