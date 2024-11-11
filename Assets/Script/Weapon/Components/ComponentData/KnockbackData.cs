using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class KnockbackData : ComponentData<AttackKnockback>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(Knockback);
        }
    }
}
