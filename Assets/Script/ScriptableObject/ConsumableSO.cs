using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    [CreateAssetMenu(fileName = "newConsumeData", menuName = "Data/Consumable Data/Basic Consumable Data", order = 0)]

    public class ConsumableSO : ScriptableObject    
    {
        public enum ConsumeType
        {
            Buff, 
            Projectile,
        }

        [Header("Consumable Item Settings")]
        public ConsumeType itemType; // Type of the consumable item
        public float effectAmount;

    }
}
