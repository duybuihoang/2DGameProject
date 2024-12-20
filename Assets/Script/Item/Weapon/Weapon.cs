
using DuyBui.CoreSystem;
using DuyBui.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class Weapon : Item
    {
        public WeaponDataSO Data { get; private set; }

        private GameObject activeWeapon;


        public bool isAttacking = false;

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

        [SerializeField] public GameObject SlashEffect;
        [SerializeField] public Transform SlashSpawnPoint;
        private GameObject slashAnimation;


        protected override void Enter()
        {
            if (isAttacking == false)
            {
                anim.SetBool("active", true);
                anim.SetInteger("counter", CurrentAttackCounter);

                onEnter?.Invoke();

                isAttacking = true;
                //TriggerSlashEffect();
                AudioManager.Instance.PlaySFX(Data.SFX);
            }
        }

        public void SetData(WeaponDataSO data)
        {
            Data = data;
        }

        protected override void Exit()
        {
            //print($"{transform.name} exit");

            anim.SetBool("active", false);
            CurrentAttackCounter++;
            onExit?.Invoke();

            isAttacking = false;
        }

        protected override void Awake()
        {
            base.Awake();
            WeaponGameObject = transform.Find("WeaponSprite").gameObject;

            anim = WeaponGameObject.GetComponent<Animator>();
            EventHandler = WeaponGameObject.GetComponent<AnimationEventHandler>();

            activeWeapon = transform.gameObject;
        }



        protected override void Update()
        {
            //attackCounterResetTimer.Tick();
            if(!isAttacking)
            {
                MouseFollowWithOffset();
            }    
            
            if(inputHandler.attack)
            {
                Enter();
            }

        }

        private void ResetAttackCounter()
        {
            currentAttackCounter = 0;
        }  

        protected override void OnEnable()
        {
            EventHandler.OnFinish += Exit;
        }

        protected override void OnDisable()
        {
            EventHandler.OnFinish -= Exit;

        }

        private void MouseFollowWithOffset()
        {
            Vector3 mousePos = inputHandler.MouseInput;
            Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            if (mousePos.x > playerScreenPoint.x)
            {
                activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle);
            }
        }

        //todo: bring slash effect to weapon component
        private void TriggerSlashEffect()
        {
            Vector3 mousePos = inputHandler.MouseInput;
            Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(player.transform.position);


            slashAnimation = Instantiate(SlashEffect, SlashSpawnPoint.position, Quaternion.identity);
            slashAnimation.transform.parent = this.transform.parent;

            if (mousePos.x > playerScreenPoint.x)
            {
                slashAnimation.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                slashAnimation.GetComponent<SpriteRenderer>().flipX = true;
            }

            
            slashAnimation.GetComponent<SpriteRenderer>().flipY = currentAttackCounter != 0;
            

        }

    }

}
