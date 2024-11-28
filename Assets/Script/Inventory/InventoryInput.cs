using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class InventoryInput : MonoBehaviour
    {
        public Inventory inventory;
        public int selectedSlot = 0;

        void Update()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    selectedSlot = i;
                    Debug.Log("Selected Slot: " + selectedSlot);
                    InventoryUI.Instance.SelectSlot(selectedSlot);
                }
            }
        }
    }
}
