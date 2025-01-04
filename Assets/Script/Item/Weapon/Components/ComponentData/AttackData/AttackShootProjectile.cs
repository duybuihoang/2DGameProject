using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class AttackShootProjectile : AttackData
    {
        [field: SerializeField] public GameObject Projectile { get; private set; }

    }
}
