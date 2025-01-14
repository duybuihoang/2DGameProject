using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class ShootProjectile : WeaponComponent<ShootProjectileData, AttackShootProjectile>
    {
        private float startTime;
        public void EmitProjectile()
        {
            Debug.Log("start " + Time.time );

            if (Time.time >= startTime + data.ShootInterval)
            {
                startTime = Time.time;
                var projectile = GameObject.Instantiate(currentAttackData.Projectile, weapon.transform.position, Quaternion.identity);
                var projectileScript = projectile.GetComponent<Projectile>();
                var worldMouseInput = Camera.main.ScreenToWorldPoint(weapon.inputHandler.MouseInput);

                Debug.Log("weapon.transform.position: " + weapon.transform.position);
                Debug.Log("worldMouseInput: " + worldMouseInput);
                Debug.Log("data.damage: " + data.damage);
                Debug.Log(projectileScript);
                if (projectileScript)
                {
                    projectileScript.Fire(weapon.transform.position, worldMouseInput, data.damage);
                }
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            evenHandler.OnAttackAction -= EmitProjectile;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            startTime = Time.time;
            evenHandler.OnAttackAction += EmitProjectile;
        }
    }
}
