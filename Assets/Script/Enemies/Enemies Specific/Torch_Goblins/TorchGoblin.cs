using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class TorchGoblin : Entity
    {
        #region State Initialize
        public TG_IdleState idleState { get; private set; }
        public TG_MoveState moveState { get; private set; }
        public TG_MeleeAttackState attackState { get; private set; }

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

            idleState = new TG_IdleState(this, stateMachine, "idle", idleStateData, this);
            moveState = new TG_MoveState(this, stateMachine, "move", moveStateData, this);
            attackState = new TG_MeleeAttackState(this, stateMachine, "attack", meleeAttackPosition, meleeAttackStateData, this);
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
