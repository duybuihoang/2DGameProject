using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    [Serializable]
    public class AttackActionHitbox : AttackData
    {
        public bool Debug;
        [field: SerializeField] public Rect HitBox { get; private set; }

    }
}
