using DuyBui.CoreSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class ActionHitBox : WeaponComponent<ActionHitboxData,AttackActionHitbox>
    {
        public event Action<Collider2D[]> OnDetectedCollider2D;

        private CoreComp<CoreSystem.Movement> movement;

        private Vector2 offset;
        private Collider2D[] detected;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();
            Debug.Log("actionHitBox Start");
            movement = new CoreComp<CoreSystem.Movement>(Core);
            evenHandler.OnAttackAction += HandleAttackAction;

        }


        private void HandleAttackAction()
        {
            offset.Set(
                transform.position.x + currentAttackData.HitBox.center.x * movement.Comp.FacingDirection,
                transform.position.y + currentAttackData.HitBox.center.y
                );


            detected = Physics2D.OverlapBoxAll(offset, currentAttackData.HitBox.size, 0f, data.DetectableLayers);

            if (detected.Length == 0)
                return;

            OnDetectedCollider2D?.Invoke(detected);

            foreach (var item in detected)
            {

                Debug.Log(this.weapon.name + " attack " +item.name);
            }

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            evenHandler.OnAttackAction -= HandleAttackAction;
        }

        private void OnDrawGizmosSelected()
        {
            if (data == null)
                return;

            foreach (var item in data.AttackData)
            {
                if (!item.Debug)
                    continue;

                Gizmos.DrawWireCube(((transform.position + (Vector3)item.HitBox.center)), item.HitBox.size);
            }
        }
    }
}

