using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuyBui
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance { get => instance; }
        private static Inventory instance;

        public ItemSO[] slots = new ItemSO[9];
        public int[] quantities = new int[9];

        private void Awake()
        {

            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

        }

        public bool TryAddItem(ItemSO item, int quantity)
        {
            bool added = false;

            for (int i = 0; i < 9; i++)
            {
                if (slots[i] == null || slots[i] == item)
                {
                    slots[i] = item;
                    if(item.itemType == ItemType.Consumable)
                    {
                        quantities[i] += quantity;
                    }
                    added = true;
                    break;
                }
            }
            return added;
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
        public void ClearInventory()
        {
            Array.Clear(slots, 0, 9);
        }

        public ItemSO GetItem(int slot)
        {
            return slots[slot];
        }
    }
}
