using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class CameraManager : Singleton<CameraManager>
    {
        public GameObject cameraObject;
        public CinemachineConfiner2D confiner;
        private void Awake()
        {
            cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
            confiner = cameraObject.GetComponent<CinemachineConfiner2D>();
        }
        public void SetCamPolygon(PolygonCollider2D poly)
        {
            confiner.m_BoundingShape2D = poly;
        }
    }
}
