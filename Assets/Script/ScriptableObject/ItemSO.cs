using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public enum ItemType { Weapon, Consumable }

    [CreateAssetMenu(fileName = "newItemData", menuName = "Data/Item Data/Basic Item Data", order = 0)]
    public class ItemSO : ScriptableObject
    {
        [Header("Base Data")]
        public string itemName;
        public Sprite icon;
        public ItemType itemType;
        public int maxStackSize;
        public GameObject ItemObj;
        public string SFX;
    }
}
