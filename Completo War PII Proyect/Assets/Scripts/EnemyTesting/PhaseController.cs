using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhaseController : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController secondController;
    [SerializeField] private AudioClip transformation;
    [SerializeField] private AudioClip hurtPhase2;
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
            GetComponent<AudioSource>().PlayOneShot(transformation, 0.7f);
            GetComponent<AudioSource>().clip = hurtPhase2;
        }
        
    }
}
