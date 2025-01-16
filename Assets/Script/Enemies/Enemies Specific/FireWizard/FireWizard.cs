using DuyBui.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class FireWizard : Entity
    {
        #region State Initialize
        public FW_IdleState idleState { get; private set; }
        public FW_MoveState moveState { get; private set; }

        public FW_AttackState attackState { get; private set; }
        #endregion

        #region StateData
        [SerializeField]
        private D_IdleState idleStateData;
        [SerializeField]
        private D_MoveState moveStateData;
        [SerializeField]
        private D_MeleeAttackState meleeAttackStateData;
        [SerializeField]
        private D_RangedAttackState rangeAttackStateData;
        [SerializeField]
        private D_HealState healStateData;
        [SerializeField]
        private D_SummonState summonStateData;
        #endregion

        [SerializeField]
        private Transform meleeAttackPosition;
        [SerializeField]
        private Transform rangedAttackPosition;


        public override void Awake()
        {
            base.Awake();

            idleState = new FW_IdleState(this, stateMachine, "idle", idleStateData, this);
            moveState = new FW_MoveState(this, stateMachine, "move", moveStateData, this);
            attackState = new FW_AttackState(this, stateMachine, "attack", rangedAttackPosition, rangeAttackStateData, this);
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

            //Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
        }



    }
}
