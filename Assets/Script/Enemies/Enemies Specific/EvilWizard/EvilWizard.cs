using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class EvilWizard : Entity
    {
        #region State Initialize
        public EW_IdleState idleState { get; private set; }
        public EW_MoveState moveState { get; private set; }
        public EW_MeleeAttackState attackState { get; private set; }
        #endregion

        #region StateData
        [SerializeField]
        private D_IdleState idleStateData;
        [SerializeField]
        private D_MoveState moveStateData;
        [SerializeField]
        private D_MeleeAttackState meleeAttackStateData;
        
        #endregion

        [SerializeField]
        private Transform meleeAttackPosition;
        public override void Awake()
        {
            base.Awake();

            idleState = new EW_IdleState(this, stateMachine, "idle", idleStateData, this);
            moveState = new EW_MoveState(this, stateMachine, "move", moveStateData, this);
            attackState = new EW_MeleeAttackState(this, stateMachine, "attack", meleeAttackPosition, meleeAttackStateData, this);
            // healState = new KG_HealState(this, stateMachine, "heal", healStateData, this);
            //  summonState = new KG_SummonState(this, stateMachine, "summon", summonStateData, this);
        }


        private void Start()
        {
            stateMachine.Initialize(idleState);
        }

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
        }


    }
}
