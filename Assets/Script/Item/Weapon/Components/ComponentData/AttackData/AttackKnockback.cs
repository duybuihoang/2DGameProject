using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    [Serializable]
    public class AttackKnockback : AttackData
    {
        [field: SerializeField] public float strength { get; private set; }
    }
}
