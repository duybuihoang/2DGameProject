using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class Item : MonoBehaviour
    {
        public Core Core { get; private set; }
        public GameObject player { get; set; }
        protected PlayerInputHandler inputHandler;


        protected virtual void Awake()
        {
            GetCore();
            player = transform.parent.parent.gameObject;
            inputHandler = GetComponentInParent<PlayerInputHandler>();


        }

        public void GetCore()
        {
            Core = transform.parent.parent.GetComponentInChildren<Core>();
        }

        public void SetCore(Core core)
        {
            Core = core;
        }

        #region virtual

        protected virtual void Update()
        {
        }

        protected virtual void OnEnable()
        {
        }

        protected virtual void OnDisable()
        {
        }

        protected virtual void Enter() { }
        protected virtual void Exit() { }
        #endregion
    }
}
