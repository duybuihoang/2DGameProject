using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class DetectPlayerInRoom : MonoBehaviour
    {
        [SerializeField] private PolygonCollider2D coll;
        private bool canSetActive;
        private void Awake()
        {
            coll = GetComponent<PolygonCollider2D>();
            canSetActive = true;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                CameraManager.Instance.SetCamPolygon(this.coll);
                if (canSetActive)
                {
                    canSetActive = false;
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        transform.GetChild(i).gameObject.SetActive(true);
                    }
                }

            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                canSetActive = true;
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                //TilemapManager.Instance.UpdateTileVisibility(coll);

            }
        }
    }
}
