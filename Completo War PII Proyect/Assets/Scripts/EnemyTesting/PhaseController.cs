using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhaseController : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController secondController;
    private bool inPhase2 = false;

    [SerializeField] private UnityEvent OnChangePhase;

    public void ChangeAnimatorController(){
        EnemyScript e = GetComponent<EnemyScript>();
        if(e.hp <= e.maxHp/2 && !inPhase2){
            inPhase2 = true;
            OnChangePhase?.Invoke();

            Animator animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = secondController;
            animator.SetTrigger("Attack");
        }
        
    }
}
