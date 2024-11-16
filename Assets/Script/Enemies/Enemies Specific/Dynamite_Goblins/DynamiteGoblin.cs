using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class DynamiteGoblin : Entity
    {
        #region StateData
        public DG_IdleState idleState { get; private set; }
        public DG_MoveState moveState { get; private set; }
        public DG_RangedAttackState attackState { get; private set; }
        #endregion


        #region StateData
        [SerializeField]
        private D_IdleState idleStateData;
        [SerializeField]
        private D_MoveState moveStateData;
        [SerializeField]
        private D_RangedAttackState attackStateData;
        #endregion

        [SerializeField]
        private Transform rangedAttackPosition;

        public override void Awake()
        {
            base.Awake();

            idleState = new DG_IdleState(this, stateMachine, "idle", idleStateData, this);
            moveState = new DG_MoveState(this, stateMachine, "move", moveStateData, this);
            attackState = new DG_RangedAttackState(this, stateMachine, "attack", rangedAttackPosition, attackStateData, this);

        }

        private void Start()
        {
            stateMachine.Initialize(idleState);
        }

        //public override void OnDrawGizmos()
        //{
        //    base.OnDrawGizmos();

        //    Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
        //}
    }

   
}
