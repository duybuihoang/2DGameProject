using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class AnimationToStateMachine : MonoBehaviour
    {
        public AttackState attackState;
        public HealState healState;
        public SummonState summonState;


        private void TriggerSummon()
        {
            summonState.TriggerSummon();
        }

        private void FinishSummon()
        {
            summonState.FinishSummon();
        }

        private void TriggerAttack()
        {
            attackState.TriggerAttack();
        }

        private void FinishAttack()
        {
            attackState.FinishAttack();
        }
        private void TriggerHeal()
        {
            healState.TriggerHeal();
        }

        private void FinishHeal()
        {
            healState.FinishHeal();
        }

    }
}

