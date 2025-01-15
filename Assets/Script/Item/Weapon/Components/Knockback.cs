using DuyBui.Weapon.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class Knockback : WeaponComponent<KnockbackData, AttackKnockback>
    {
        private ActionHitBox hitBox;

        
        private void HandleDetectedCollider(Collider2D[] colliders)
        {
            foreach (var item in colliders)
            {
                if(item.TryGetComponent(out IKnockbackable knockbackable))
                {
                    Vector2 direction = (item.transform.position - weapon.player.transform.position).normalized;
                    knockbackable.KnockBack( direction  , currentAttackData.strength);
                }
            }
        }

        protected override void Start()
        {
            base.Start();

            hitBox = GetComponent<ActionHitBox>();
            hitBox.OnDetectedCollider2D += HandleDetectedCollider;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            hitBox.OnDetectedCollider2D -= HandleDetectedCollider;
        }
    }
}
