using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class DamageData : ComponentData<AttackDamage>
    {
        public DamageData()
        {
            ComponentDependency = typeof(Damage);
        }
    }
}
