using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace DuyBui.CoreSystem
{
    public class Death : CoreComponent
    {
        [SerializeField] private GameObject deathParticles;
        private Stats stats;
        private Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);
        private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent(ref particleManager);
        private ParticleManager particleManager;
        public void Die()
        {
            ParticleManager?.StartParticles(deathParticles);
            core.transform.parent.gameObject.SetActive(false);
        }
        private void OnEnable()
        {
            Stats.OnHealthZero += Die;
        }

        private void OnDisable()
        {
            Stats.OnHealthZero -= Die;
        }
    }
}
