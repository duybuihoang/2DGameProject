using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
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
            AudioManager.Instance.PlaySFX(stateData.SFX);

            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);


            foreach (Collider2D collider in detectedObjects)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();


                if (damageable != null)
                {
                    damageable.Damage(stateData.attackDamage);
                }

                IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

                if (knockbackable != null)
                {
                    Vector2 direction = (collider.transform.position - entity.transform.position).normalized;
                    knockbackable.KnockBack(direction, stateData.knockbackStrength);
                }

                IParticle particle = collider.GetComponent<IParticle>();

                if(particle != null)
                {
                    particle.EmitHitParticle(entity.transform.position, collider.transform.position);
                }


            }
        }
    }
}
