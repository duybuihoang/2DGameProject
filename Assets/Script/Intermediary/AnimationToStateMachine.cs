using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class AnimationToStateMachine : MonoBehaviour
    {
        public AttackState attackState;
        public HealState healState;

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

