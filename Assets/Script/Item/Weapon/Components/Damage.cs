using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class Damage : WeaponComponent<DamageData, AttackDamage>
    {
        private ActionHitBox hitBox;

        private void HandleDetectCollider2D(Collider2D[] colliders)
        {
            foreach (var item in colliders)
            {
                if (item.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(currentAttackData.Amount);
                }

                if(item.TryGetComponent(out IParticle particle))
                {
                    particle.EmitHitParticle(weapon.transform.position, item.transform.position);
                }
            }
        }

        protected override void Start()
        {
            base.Start();

            hitBox = GetComponent<ActionHitBox>();
            hitBox.OnDetectedCollider2D += HandleDetectCollider2D;

        }



        protected override void OnDestroy()
        {
            base.OnDestroy();

            hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
        }

    }
}
