using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    [CreateAssetMenu(fileName = "newMeleeAttackStateData", menuName = "Data/State Data/Melee Attack State")]
    public class D_MeleeAttackState : ScriptableObject
    {
        [Header("attack data")]
        public float attackRadius = 0.8f;
        public float attackDamage = 10f;

        [Header("knockback data")]
        public float knockbackStrength = 10f;

        [Header("layer")]
        public LayerMask whatIsPlayer;

    }
}
