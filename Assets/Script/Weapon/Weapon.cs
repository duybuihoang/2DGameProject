
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

        private PlayerInputHandler inputHandler;
        private GameObject activeWeapon;
        private GameObject player;

        protected bool isAttacking = false;

        [SerializeField] private float attackCounterResetCooldown;
        private int currentAttackCounter;
        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set
            {
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
            if (isAttacking == false)
            {
                anim.SetBool("active", true);
                anim.SetInteger("counter", CurrentAttackCounter);

                onEnter?.Invoke();

                isAttacking = true;
            }
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
            //print($"{transform.name} exit");

            anim.SetBool("active", false);
            CurrentAttackCounter++;
            onExit?.Invoke();

            isAttacking = false;
        }

        private void Awake()
        {
            WeaponGameObject = transform.Find("WeaponSprite").gameObject;
            anim = WeaponGameObject.GetComponent<Animator>();
            EventHandler = WeaponGameObject.GetComponent<AnimationEventHandler>();

            attackCounterResetTimer = new Timer(attackCounterResetCooldown);

            inputHandler = GetComponentInParent<PlayerInputHandler>();

            activeWeapon = transform.parent.gameObject;
            player = transform.parent.parent.gameObject;
        }

        private void Update()
        {
            //attackCounterResetTimer.Tick();
            if(!isAttacking)
            {
                MouseFollowWithOffset();
            }    
            
            if(inputHandler.attack)
            {
                this.Enter();
            }

        }

        private void ResetAttackCounter()
        {
            currentAttackCounter = 0;
        }  

        private void OnEnable()
        {
            EventHandler.OnFinish += Exit;
        }

        private void OnDisable()
        {
            EventHandler.OnFinish -= Exit;

        }

        private void MouseFollowWithOffset()
        {
            Vector3 mousePos = inputHandler.MouseInput;
            Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            if(mousePos.x > playerScreenPoint.x)
                activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
            else
                activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
    }

}
