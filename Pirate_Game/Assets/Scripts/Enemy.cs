using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using KBCore.Refs;

namespace Platformer{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : Entity {
        [SerializeField, Self] NavMeshAgent agent;
        [SerializeField, Child] Animator animator;

        StateMachine stateMachine;

        void OnValidate() => this.ValidateRefs();

        void Start() {
            stateMachine = new StateMachine();

        }

        void At(IState from, IState to, IPredicate condition) => stateMachine>AddTransition(from, to, condition);
        void Any(IState to, IPredicate condition) => stateMachine.AddAnyTransition(to, condition);

        void Update() {
            stateMachine.Update();
        }

        void FixedUpdate() {
            stateMachine.FixedUpdate();
        }
    }
}   