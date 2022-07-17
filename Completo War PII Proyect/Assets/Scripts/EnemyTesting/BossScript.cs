using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossScript : MonoBehaviour
{
    [Header("Events: ")]
    //[SerializeField] private UnityEvent OnDie;
    //[SerializeField] private UnityEvent OnStart;
    [SerializeField] private UnityEvent OnMove;
    [SerializeField] private UnityEvent OnAttack;

    [SerializeField] private int timesToRepeat = 1;
    [SerializeField] private float moveTime, attackTime, coolDownTime;

    private bool isReady = true;
    private WaitForSeconds waitMove, waitAttack, waitCoolDown;

    void Start(){
        waitMove = new WaitForSeconds(moveTime);
        waitAttack = new WaitForSeconds(attackTime);
        waitCoolDown = new WaitForSeconds(coolDownTime);
    }

    void Update(){
        if(isReady){
            StartCoroutine(Pattern());
        }
    }

    IEnumerator Pattern(){
        isReady = false;

        for(int i=0;i<timesToRepeat;i++){
            OnMove?.Invoke();
            yield return waitMove;
            OnAttack?.Invoke();
            yield return waitAttack;
        }
        yield return waitCoolDown;

        isReady = true;
    }
}
