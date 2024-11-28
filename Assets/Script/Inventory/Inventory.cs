using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class Inventory : Singleton<Inventory>
    {
        public ItemSO[] slots = new ItemSO[9];
        public int[] quantities = new int[9];

        public void AddItem(ItemSO item, int quantity, int slot)
        {
            if (slots[slot] == null || slots[slot] == item)
            {
                slots[slot] = item;
                quantities[slot] += quantity;
            }
        }

        public void RemoveItem(int slot, int quantity)
        {
            if (slots[slot] != null)
            {
                quantities[slot] -= quantity;
                if (quantities[slot] <= 0)
                {
                    slots[slot] = null;
                    quantities[slot] = 0;
                }
            }
        }

        public ItemSO GetItem(int slot)
        {
            return slots[slot];
        }
    }
}
