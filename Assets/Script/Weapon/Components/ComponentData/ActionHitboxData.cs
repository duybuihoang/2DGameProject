using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class ActionHitboxData : ComponentData<AttackActionHitbox>
    {
        [field: SerializeField] public LayerMask DetectableLayers { get; private set; }

        public ActionHitboxData()
        {
            ComponentDependency = typeof(ActionHitBox);
        }
    }
}
