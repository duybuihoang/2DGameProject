using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class RangedAttackState : AttackState
    {
        protected D_RangedAttackState stateData;
        protected GameObject projectile;
        protected Projectile projectileScript;
        //protected Projectile projectileScript;
        public RangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData) : base(entity, stateMachine, animBoolName, attackPosition)
        {
            this.stateData = stateData;
        }
        public override void TriggerAttack()
        {
            base.TriggerAttack();

            Collider2D target = Physics2D.OverlapCircle(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

            projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);

            projectileScript = projectile.GetComponent<Projectile>();
            projectileScript.Fire(attackPosition.position, target.transform.position, stateData.projectileDamage);

        }
    }
}
