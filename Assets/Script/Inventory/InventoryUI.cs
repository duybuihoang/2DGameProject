using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

namespace DuyBui
{
    public class InventoryUI : Singleton<InventoryUI>
    {
        public Inventory inventory;
        public Transform inventoryPanel;
        public Transform hover;
        public GameObject slotPrefab;
        private int currentSelectedSlot;


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
                Transform basic = slot.GetChild(0);

                Image icon = slot.GetChild(2).GetComponent<Image>();
                TextMeshProUGUI quantity = slot.GetChild(3).GetComponent<TextMeshProUGUI>();
                Debug.Log(quantity.name);

                if (inventory.slots[i] != null )
                {
                    icon.sprite = inventory.slots[i].icon;
                    icon.enabled = true;

                    if (inventory.slots[i].itemType == ItemType.Consumable)
                    {
                        quantity.text = inventory.quantities[i].ToString();
                    }
                    else
                    {
                        quantity.text = "";
                    }
                }
                else
                {
                    icon.enabled = false;
                    quantity.text = "";
                }
            }
        }

        public void UpdateHover()
        {
            if(hover == null)
            {
                hover = inventoryPanel.GetChild(0).GetChild(1);
            }
            hover.gameObject.SetActive(false);
            hover = inventoryPanel.GetChild(currentSelectedSlot).GetChild(1);
            hover.gameObject.SetActive(true);
        }
        

        public void SelectSlot(int pos)
        {
            currentSelectedSlot = pos;
            UpdateUI();
            UpdateHover();
            ActiveWeapon.Instance.SetCurrentItem(inventory.GetItem(pos));
        }    

        public void UseItem()
        {
            inventory.RemoveItem(currentSelectedSlot, 1);
            UpdateUI();
        }

        public bool AddItem(ItemSO item)
        {
            if(inventory.TryAddItem(item, 1))
            {
                UpdateUI();
                return true;
            }
            return false;
        }



    }
}
