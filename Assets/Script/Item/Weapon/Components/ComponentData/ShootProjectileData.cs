using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class ShootProjectileData : ComponentData<AttackShootProjectile>
    {
        [field: SerializeField] public float damage { get; private set; }
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(ShootProjectile);
        }
    }
}
