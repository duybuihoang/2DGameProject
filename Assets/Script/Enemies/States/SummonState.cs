using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class SummonState : State
    {
        protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
        private Movement movement;
        protected DamageReceiver DamageReceiver { get => damageReceiver ?? core.GetCoreComponent(ref damageReceiver); }
        private DamageReceiver damageReceiver;

        protected bool isAnimationFinish;
        protected D_SummonState stateData;


        public SummonState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_SummonState stateData) : base(entity, stateMachine, animBoolName)
        {
            this.stateData = stateData;
        }

        public override void Enter()
        {
            base.Enter();
            isAnimationFinish = false;
            DamageReceiver.Vulnerable = false;
            entity.atsm.summonState = this;
        }

        public override void Exit()
        {
            base.Exit();
            DamageReceiver.Vulnerable = true;

        }

        public virtual void TriggerSummon()
        {
            var summonList = stateData.summonList;

            if (summonList == null || summonList.Count <= 0)
            {
                Debug.LogWarning("No objects to spawn!");
                return;
            }
            for (int i = 0; i < Random.Range(stateData.minSummonCount, stateData.maxSummonCount + 1); i++)
            {
                GameObject minions = summonList[Random.Range(0, summonList.Count)];

                Vector2 randomPos = Random.insideUnitCircle * stateData.summonRadius;
                Vector3 summonPos = new Vector3(randomPos.x, randomPos.y, 0);

                GameObject summonedMinion = Object.Instantiate(minions, summonPos, Quaternion.identity);

            }
        }

        public virtual void FinishSummon()
        {
            isAnimationFinish = true;
        }

    }
}
