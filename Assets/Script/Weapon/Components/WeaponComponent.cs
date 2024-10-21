using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public abstract class WeaponComponent : MonoBehaviour
    {
        protected Weapon weapon;
        protected AnimationEventHandler evenHandler;
        protected Core Core => weapon.Core;

        protected bool isAttackActive;
        public virtual void Init()
        {

        }
        protected virtual void Awake()
        {
            weapon = GetComponent<Weapon>();
            evenHandler = GetComponentInChildren<AnimationEventHandler>();
        }

        protected virtual void Start()
        {
            weapon.onEnter += HandleEnter;
            weapon.onExit += HandleExit;
        }

        protected virtual void HandleEnter()
        {
            isAttackActive = true;
        }

        protected virtual void HandleExit()
        {
            isAttackActive = false;
        }

        protected virtual void OnDestroy()
        {
            weapon.onEnter -= HandleEnter;
            weapon.onExit -= HandleExit;
        }

    }

    public class WeaponComponent<T1, T2> : WeaponComponent where T1 : ComponentData<T2> where T2 : AttackData
    {
        protected T1 data;
        protected T2 currentAttackData;

        protected override void HandleEnter()
        {
            base.HandleEnter();

            Debug.Log("-----------------------------------");
            Debug.Log("attack data: " + data.ToString());
            Debug.Log("attack counter: " + weapon.CurrentAttackCounter);
            Debug.Log("attack data length: " + data.AttackData.Length);
            Debug.Log("-----------------------------------");

            currentAttackData = data.AttackData[weapon.CurrentAttackCounter];

        }

        public override void Init()
        {
            base.Init();

            data = weapon.Data.getData<T1>();
        }
    }
}
