using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.CoreSystem
{
    public class PlayerSensor : CoreComponent
    {
        private GameObject playerPos;

        protected override void Awake()
        {
            base.Awake();
            playerPos = GameObject.Find("Player");
        }

        public virtual Vector2 GetPlayerPos()
        {
            return playerPos.transform.position;
        }
    }
}
