using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.CoreSystem
{
    public class Stats : CoreComponent
    {
        public event Action OnHealthZero;

        [SerializeField] private float maxHealth;
        private float currentHealth;

        private Flash flash;
        private Flash Flash => flash ? flash : core.GetCoreComponent(ref flash);

        protected override void Awake()
        {
            base.Awake();

            currentHealth = maxHealth;
        }

        public void DecreaseHealth(float amount)
        {
            currentHealth -= amount;

            Flash?.StartFlash();

            
        }

        public void IncreaseHealth(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        }

        public void CheckIsDeath()
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                OnHealthZero?.Invoke();
            }
        }
    }
}
