using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangedAttackStateData", menuName = "Data/State Data/Ranged Attack State")]
public class D_RangedAttackState : ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage = 10f;
    public float attackRadius = 10f;
    public LayerMask whatIsPlayer;
}

