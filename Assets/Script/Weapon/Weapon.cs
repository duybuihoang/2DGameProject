
using DuyBui.CoreSystem;
using DuyBui.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class Weapon : MonoBehaviour
    {
        public WeaponDataSO Data { get; private set; }

        private PlayerInputHandler inputHandler;
        private GameObject activeWeapon;

        public GameObject player { get; set; }

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
        public Core Core { get; private set; }

        [SerializeField] public GameObject SlashEffect;
        [SerializeField] public Transform SlashSpawnPoint;
        private GameObject slashAnimation;


        public void Enter()
        {
            if (isAttacking == false)
            {
                anim.SetBool("active", true);
                anim.SetInteger("counter", CurrentAttackCounter);

                onEnter?.Invoke();

                isAttacking = true;
                TriggerSlashEffect();
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
