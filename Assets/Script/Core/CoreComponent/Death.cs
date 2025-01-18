using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DuyBui.CoreSystem
{
    public class Death : CoreComponent
    {
        [SerializeField] private GameObject deathParticles;
        [SerializeField] private string deathSFX;
        private Stats stats;
        private DropItem dropItem;
        private Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);
        private DropItem DropItem => dropItem ? dropItem : core.GetCoreComponent(ref dropItem);
        private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent(ref particleManager);
        private ParticleManager particleManager;
        public void Die()
        {
            AudioManager.Instance.PlaySFX(deathSFX);
            ParticleManager?.StartParticles(deathParticles);
            core.transform.parent.gameObject.SetActive(false);
            DropItem?.Drop(transform.position);


            if (core.transform.parent.tag == "Player" || core.transform.parent.tag == "EvilWizard")
            {
                SceneManager.LoadScene("Menu");
            }
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
