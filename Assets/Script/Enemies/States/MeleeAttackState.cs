using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class MeleeAttackState : AttackState
    {
        protected D_MeleeAttackState stateData;

        public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttackState stateData) : base(entity, stateMachine, animBoolName, attackPosition)
        {
            this.stateData = stateData;
        }

        public override void TriggerAttack()
        {
            base.TriggerAttack();

            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);


            foreach (Collider2D collider in detectedObjects)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();


                if (damageable != null)
                {
                    damageable.Damage(stateData.attackDamage);
                }

                //IKnockBackable knockbackable = collider.GetComponent<IKnockBackable>();

                //if (knockbackable != null)
                //{
                //    knockbackable.KnockBack(stateData.knockbackAngle, stateData.knockbackStrength, Movement.FacingDirection);
                //}

            }
        }
    }
}