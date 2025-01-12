using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    [CreateAssetMenu(fileName = "newHealStateData", menuName = "Data/State Data/Heal State")]

    public class D_HealState : ScriptableObject
    {
        public float amount = 40;
    }
}
