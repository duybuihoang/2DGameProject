using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.CoreSystem
{
    public class DamageReceiver : CoreComponent, IDamageable, IParticle
    {
        [SerializeField] private GameObject HitParticle;
        [SerializeField] string SFX;
        private CoreComp<Stats> stats;
        private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent(ref particleManager);
        private ParticleManager particleManager;

        private bool vulnerable = true;
        public bool Vulnerable { get => vulnerable; set => vulnerable = value; }


        public void Damage(float amount)
        {
            if(vulnerable)
            {
                AudioManager.Instance.PlaySFX(SFX);
                stats.Comp?.DecreaseHealth(amount);
            }

        }

        public void EmitHitParticle(Vector3 selfPos, Vector3 targetPos)
        {
            float x = targetPos.x - selfPos.x;
            float y = targetPos.y - selfPos.y;

            float degree = Mathf.Atan2(-y, x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.Euler(degree, 90f, -90f);

            ParticleManager?.StartParticles(HitParticle, targetPos, rotation);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = new CoreComp<Stats>(core);
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            //stats.Comp.CheckIsDeath();
        }
    }
}
