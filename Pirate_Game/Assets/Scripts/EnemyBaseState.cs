using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer {
    protected readonly Enemy enemy;
    protected readonly Animator animator;

    protected const float crossFadeDuration = 0.1f;
    protected EnemyBaseState(Enemy enemy, Animator animator){
        this.enemy = enemy;
        this.animator = animator;
    }
    public abstract class EnemyBaseState : IState { 
        public virtual void OnEnter() {
            throw new System.NotImplementedException();
        }
        public virtual void Update(){
            throw new System.NotImplementedException();
        }
        public virtual void FixedUpdate(){
            throw new System.NotImplementedException();
        }
        public virtual void OnExit(){
            throw new System.NotImplementedException();
        }
    }
    
}