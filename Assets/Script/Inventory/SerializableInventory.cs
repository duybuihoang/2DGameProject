using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DuyBui
{
    [Serializable]
    public class SerializableInventory 
    {
        public string[] itemNames;
        public int[] quantities;

        public SerializableInventory(Inventory inventory)
        {
            itemNames = new string[9];
            quantities = new int[9];

            for (int i = 0; i < 9; i++)
            {
                if (inventory.slots[i] != null)
                {
                    itemNames[i] = inventory.slots[i].itemName;
                    quantities[i] = inventory.quantities[i];
                }
                else
                {
                    itemNames[i] = "";
                    quantities[i] = 0;
                }
            }
        }

    }
}
