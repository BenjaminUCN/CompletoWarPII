using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private float timing, coolDownTime;

    private bool ready = true;
    [SerializeField] private bool localEnable = true;

    [SerializeField] private UnityEvent OnTeleportStart;
    [SerializeField] private UnityEvent OnTeleportEnd;

    void Update(){
        if(localEnable){
            Teleport();
        }
    }

    public void Teleport(){
        if(ready){
            StartCoroutine(TeleportCoroutine());
        }
    }

    IEnumerator TeleportCoroutine(){
        ready = false;
        OnTeleportStart?.Invoke();

        GetComponent<Animator>().SetTrigger("Attack");
        yield return new WaitForSeconds(timing);
        RandomMove();
        OnTeleportEnd?.Invoke();
        yield return new WaitForSeconds(coolDownTime);
        ready = true;
    }

    public void RandomMove(){
        transform.position = new Vector3(Random.Range(minX,maxX), Random.Range(minY,maxY));
    }

    public void SetLocalEnable(bool enable){
        localEnable = enable;
    }
}
