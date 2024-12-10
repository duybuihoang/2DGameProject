using DuyBui.Weapon.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class ActiveWeapon : Singleton<ActiveWeapon>
    {
        public GameObject currentItem;

        private void Awake()
        {
            currentItem = null;
        }


        public void SetCurrentItem(ItemSO itemData)
        {

            if (currentItem)
            {
                Destroy(currentItem);
            }
            if (itemData)
            {

                currentItem = Instantiate(itemData.ItemObj, transform);
                currentItem.GetComponent<Item>().GetCore();
            }

            Debug.Log(currentItem);
        }
    }
}
