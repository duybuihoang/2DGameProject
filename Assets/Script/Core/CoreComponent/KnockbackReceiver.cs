using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.CoreSystem
{
    public class KnockbackReceiver : CoreComponent, IKnockbackable
    {

        [SerializeField] private float maxKnockbackTime = 0.2f;

        private CoreComp<Movement> movement;

        protected bool isKnockBackActive { get; private set; }
        private float knockBackStartTimer;

        private Stats stats;
        private KnockbackReceiver knockback;
        private Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);

        public override void LogicUpdate()
        {
            CheckKnockback();

        }

        protected override void Awake()
        {
            base.Awake();

            movement = new CoreComp<Movement>(core);
        }



        public void KnockBack(Vector2 direction, float strength)
        {
            movement.Comp?.SetVelocity(direction, strength);
            movement.Comp.canSetVelocity = false;
            isKnockBackActive = true;
            knockBackStartTimer = Time.time;
        }

        private void CheckKnockback()
        {
            if(isKnockBackActive && Time.time >= knockBackStartTimer + maxKnockbackTime)
            {
                isKnockBackActive = false;
                movement.Comp.canSetVelocity = true;
                Stats?.CheckIsDeath();
            }
        }
       
    }
}
