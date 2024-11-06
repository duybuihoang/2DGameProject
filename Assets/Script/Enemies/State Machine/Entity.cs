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

        public Animator anim { get; private set; }

        public D_Entity data;
        private float currentHealth;


        public virtual void Awake()
        {
            Core = GetComponentInChildren<Core>();
            anim = GetComponent<Animator>();
            stateMachine = new FiniteStateMachine();

            currentHealth = data.maxHealth;

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

        }
        public Vector2 GetRoamingPosition()
        {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }

    }
}
