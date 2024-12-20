using DuyBui.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui
{
    public class KingGoblin : Entity
    {
        #region State Initialize
        public KG_IdleState idleState { get; private set; }
        public KG_MoveState moveState { get; private set; }
        public KG_MeleeAttackState attackState { get; private set; }

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

            idleState = new KG_IdleState(this, stateMachine, "idle", idleStateData, this);
            moveState = new KG_MoveState(this, stateMachine, "move", moveStateData, this);
            attackState = new KG_MeleeAttackState(this, stateMachine, "attack", meleeAttackPosition, meleeAttackStateData, this);
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
