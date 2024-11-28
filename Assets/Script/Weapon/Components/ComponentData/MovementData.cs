using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class MovementData : ComponentData<AttackMovement>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(Movement);
        }
    }
}
