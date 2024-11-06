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

        #endregion

        #region StateData
        [SerializeField]
        private D_IdleState idleStateData;
        [SerializeField]
        private D_MoveState moveStateData;
        #endregion

        public override void Awake()
        {
            base.Awake();

            idleState = new TG_IdleState(this, stateMachine, "idle", idleStateData, this);
            moveState = new TG_MoveState(this, stateMachine, "move", moveStateData, this);
        }

        private void Start()
        {
            stateMachine.Initialize(idleState);
        }

        public override void OnDrawGizmos()
        {
            
        }
    }
}
