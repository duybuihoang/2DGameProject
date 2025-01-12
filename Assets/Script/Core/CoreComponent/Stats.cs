using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.CoreSystem
{
    public class Stats : CoreComponent
    {
        public event Action OnHealthZero;
        public event Action<float> OnHealthChange;

        [SerializeField] public float maxHealth;
        public float currentHealth;

        private Flash flash;
        private Flash Flash => flash ? flash : core.GetCoreComponent(ref flash);

        private KnockbackReceiver knockback;
        private KnockbackReceiver Knockback => knockback ? knockback : core.GetCoreComponent(ref knockback);


        protected override void Awake()
        {
            base.Awake();

            currentHealth = maxHealth;

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            CheckIsDeath();

        }

        public void DecreaseHealth(float amount)
        {
            currentHealth -= amount;

            Flash?.StartFlash();
            OnHealthChange?.Invoke(currentHealth / maxHealth);
        }

        public void IncreaseHealth(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            OnHealthChange?.Invoke(currentHealth / maxHealth);

        }

        public void CheckIsDeath()
        {
            if (currentHealth <= 0 && !Knockback.isKnockBackActive)
            {
                currentHealth = 0;
                OnHealthZero?.Invoke();
            }
        }
    }
}
