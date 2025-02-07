using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class Consumable : Item
    {
        public ConsumableSO Data;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Enter()
        {
            base.Enter();

            AudioManager.Instance.PlaySFX(Data.SFX);
            player.GetComponentInChildren<Stats>().IncreaseHealth(Data.effectAmount);
            InventoryUI.Instance.UseItem();

            this.Exit();
        }

        protected override void Exit()
        {
            base.Exit();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void Update()
        {
            base.Update();
            if (inputHandler.attack)
            {
                inputHandler.UsedMouseInput();
                Enter();
            }
        }
    }
}
