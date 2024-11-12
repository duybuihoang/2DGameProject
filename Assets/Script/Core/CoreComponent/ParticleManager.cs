using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace DuyBui.CoreSystem
{
    public class ParticleManager : CoreComponent
    {
        private Transform particleContainer;
        protected override void Awake()
        {
            base.Awake();


            particleContainer = GameObject.FindGameObjectWithTag("ParticleContainer").transform;

        }
        public GameObject StartParticles(GameObject particlePrefab, Vector2 position, Quaternion rotation)
        {
            return Instantiate(particlePrefab, position, rotation, particleContainer);

        }

        public GameObject StartParticles(GameObject particlePrefab)
        {
            return StartParticles(particlePrefab, transform.position, quaternion.identity);
        }

    }
}
