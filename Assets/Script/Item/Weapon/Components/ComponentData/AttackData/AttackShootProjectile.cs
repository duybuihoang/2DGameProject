using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DuyBui.Weapon.Components
{
    [Serializable]
    public class AttackShootProjectile : AttackData
    {
        [field: SerializeField] public GameObject Projectile { get; set; }

    }
}
