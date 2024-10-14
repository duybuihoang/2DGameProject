
using DuyBui.CoreSystem;
using DuyBui.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class Weapon : MonoBehaviour
    {
        public WeaponDataSO Data { get; private set; }

        [SerializeField] private float attackCounterResetCooldown;
        private int currentAttackCounter;
        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set
            {
                //currentAttackCounter = value % numberOfAttacks;
                currentAttackCounter = value >= Data?.NumberOfAttacks ? 0 : value;
            }
        }
        private Timer attackCounterResetTimer;


        public event Action onEnter;
        public event Action onExit;

        private Animator anim;
        public GameObject WeaponGameObject { get; private set; }

        public AnimationEventHandler EventHandler { get; private set; }
        public Core Core { get; private set; }



        public void Enter()
        {
            print($"{transform.name} enter");

            attackCounterResetTimer.StopTimer();

            anim.SetBool("active", true);
            anim.SetInteger("counter", CurrentAttackCounter);

            onEnter?.Invoke();
        }

        public void SetCore(Core core)
        {
            Core = core;
        }

        public void SetData(WeaponDataSO data)
        {
            Data = data;
        }

        private void Exit()
        {
            anim.SetBool("active", false);
            CurrentAttackCounter++;
            attackCounterResetTimer.StartTimer();
            onExit?.Invoke();
        }

        private void Awake()
        {
            WeaponGameObject = transform.Find("WeaponSprite").gameObject;
            anim = WeaponGameObject.GetComponent<Animator>();
            EventHandler = WeaponGameObject.GetComponent<AnimationEventHandler>();

            attackCounterResetTimer = new Timer(attackCounterResetCooldown);


        }

        private void Update()
        {
            attackCounterResetTimer.Tick();
        }

        private void ResetAttackCounter() => CurrentAttackCounter = 0;

        private void OnEnable()
        {
            EventHandler.OnFinish += Exit;
            attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
        }

        private void OnDisable()
        {
            EventHandler.OnFinish -= Exit;
            attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;

        }
    }

}
