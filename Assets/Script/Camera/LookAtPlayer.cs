using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class LookAtPlayer : MonoBehaviour
    {
        private CinemachineVirtualCamera cine;
        private GameObject poly;


        private void Awake()
        {
            cine = GetComponent<CinemachineVirtualCamera>();
            poly = GameObject.FindGameObjectWithTag("Confiner");
        }

        void Start()
        {
            if(cine)
            {
                cine.Follow = GameObject.FindGameObjectWithTag("Player").transform;
                this.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = poly.GetComponent<PolygonCollider2D>();
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
