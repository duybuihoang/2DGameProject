using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DuyBui.CoreSystem
{
    public class DropItem : CoreComponent
    {
        [SerializeField] private List<ItemSO> itemList = new List<ItemSO>();
        [SerializeField] private GameObject pickupPrefabs;


        private ItemSO getRandomItemData()
        {
            return itemList[Random.Range(0, itemList.Count)];
        }


        public void Drop(Vector2 pos)
        {
            var data = getRandomItemData();
            if (data == null)
            {
                return;
            }
            var item = Instantiate(pickupPrefabs, pos, Quaternion.identity);
            item.GetComponent<Pickupable>()?.SetData(data);

        }

    }
}
