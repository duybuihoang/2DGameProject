using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Weapon.Components
{
    public class Movement : WeaponComponent<MovementData, AttackMovement>
    {
        private CoreSystem.Movement coreMovement;
        private CoreSystem.Movement CoreMovement => coreMovement ? coreMovement : Core.GetCoreComponent(ref coreMovement);



        private void HandleStartMovement()
        {
            //CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, coreMovement.FacingDirection);
            CoreMovement.SetVelocity(currentAttackData.Direction * coreMovement.FacingDirection, currentAttackData.Velocity);

        }
        private void HandleStopMovement()
        {
            CoreMovement.SetVelocityZero();
        }


        protected override void Start()
        {
            base.Start();

            evenHandler.OnStartMovement += HandleStartMovement;
            evenHandler.OnStopMovement += HandleStopMovement;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            evenHandler.OnStartMovement -= HandleStartMovement;
            evenHandler.OnStopMovement -= HandleStopMovement;

        }
    }
}

        