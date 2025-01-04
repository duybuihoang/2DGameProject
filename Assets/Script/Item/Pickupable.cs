using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class Pickupable : MonoBehaviour
    {
        [SerializeField] private ItemSO data;

        private SpriteRenderer icon;
        private CircleCollider2D coll;

        private void Awake()
        {
            icon = GetComponent<SpriteRenderer>();
            coll = GetComponent<CircleCollider2D>();
        }

        private void Start()
        {
            icon.sprite = data.icon;
            if(data.itemType == ItemType.Consumable)
            {
                transform.localScale = new Vector3(3f, 3f, 3f);
                coll.radius /= 3;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if(InventoryUI.Instance.AddItem(data))
                {
                    Destroy(gameObject);
                }
            }
                
        }

    }
}
