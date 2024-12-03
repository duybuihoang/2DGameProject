using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class Item : MonoBehaviour
    {
        public Core Core { get; private set; }

        protected virtual void Awake()
        {
            GetCore();
            Debug.Log(Core);
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
