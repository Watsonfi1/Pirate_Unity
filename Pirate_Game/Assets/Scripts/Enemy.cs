using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Enemy : Entity {
        [SerializeField, Self] NavMeshAgent agent;
        [SerializeField, Child] Animator animator;

        StateMachine stateMachine;

        void OnValidate() => this.ValidateRefs();

        }
    }
}
