using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class Entity : MonoBehaviour
    {
        public Core Core { get; private set; }
        protected Movement Movement { get => movement ?? Core.GetCoreComponent(ref movement); }
        private Movement movement;

        public FiniteStateMachine stateMachine;
        public AnimationToStateMachine atsm;

        public Animator anim { get; private set; }

        public D_Entity entityData;

        [SerializeField]
        private Transform playerCheck;
        [SerializeField]
        private Transform attackCheck;

        private float currentHealth;


        public virtual void Awake()
        {
            Core = GetComponentInChildren<Core>();

            anim = GetComponent<Animator>();
            atsm = GetComponent<AnimationToStateMachine>();

            stateMachine = new FiniteStateMachine();

            currentHealth = entityData.maxHealth;

        }

        public virtual void Update()
        {
            Core.LogicUpdate();
            stateMachine.currentState.LogicUpdate();
        }

        public virtual void FixedUpdate()
        {
            stateMachine.currentState.PhysicsUpdate();
        }

        public virtual void OnDrawGizmos()
        {
            if(Core != null)
            {
                Gizmos.DrawWireSphere(playerCheck.position, entityData.detectRadius);
                Gizmos.DrawWireSphere(attackCheck.position, entityData.TriggerAttackActionRadius);

            }
        }
        public Vector2 GetRoamingPosition()
        {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

        public virtual bool CheckPlayerInDetectedRange()
        {
            return Physics2D.OverlapCircle(playerCheck.position, entityData.detectRadius, entityData.whatIsPlayer);
        }
        public virtual bool CheckPlayerInAttackRangeAction()
        {
            return Physics2D.OverlapCircle(attackCheck.position, entityData.TriggerAttackActionRadius, entityData.whatIsPlayer);
        }
        public virtual Collider2D GetPlayerInDetectedRange()
        {
            return Physics2D.OverlapCircle(playerCheck.position, entityData.detectRadius, entityData.whatIsPlayer) ;
        }
    }
}
