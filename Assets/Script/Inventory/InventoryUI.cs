using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DuyBui
{
    public class InventoryUI : Singleton<InventoryUI>
    {
        public Inventory inventory;
        public Transform inventoryPanel;
        public GameObject slotPrefab;

        void Start()
        {
            SelectSlot(0);
        }

        private void Update()
        {
        }

        public void UpdateUI()
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                Transform slot = inventoryPanel.GetChild(i);
                Debug.Log(slot);

                Transform basic = slot.GetChild(0);
                Transform hover = slot.GetChild(1);

                hover.gameObject.SetActive(false);


                Image icon = slot.GetChild(2).GetComponent<Image>();
                //Text quantity = slot.GetChild(1).GetComponent<Text>();

                if (inventory.slots[i] != null)
                {
                    icon.sprite = inventory.slots[i].icon;
                    icon.enabled = true;
                   // quantity.text = inventory.quantities[i].ToString();
                }
                else
                {
                    icon.enabled = false;
                    //quantity.text = "";
                }
            }
        }

        public void SelectSlot(int pos)
        {
            UpdateUI();
            inventoryPanel.GetChild(pos).GetChild(1).gameObject.SetActive(true);
        }    
    }
}
