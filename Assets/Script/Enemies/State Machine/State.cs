using DuyBui.CoreSystem;
using DuyBui.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DuyBui.Enemies
{
    public class State 
    {
        protected FiniteStateMachine stateMachine;
        protected Core core;
        protected Entity entity;
        public float startTime { get; private set; }

        protected string animBoolName;

        public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
        {
            this.entity = entity;
            this.stateMachine = stateMachine;
            this.animBoolName = animBoolName;
            core = entity.Core;
        }

        public virtual void Enter()
        {
            startTime = Time.time;
            entity.anim.SetBool(animBoolName, true);
            DoChecks();
        }

        public virtual void Exit()
        {
            entity.anim.SetBool(animBoolName, false);

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {

        }
    }
}
