using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InvokeAttack : MonoBehaviour
{
    private Animator animator;

    public Vector3[] spawnPoints;
    public GameObject enemyPrefab;

    [SerializeField] private float coolDownTime = 1f;
    private bool attackReady = true;

    private WaitForSeconds attackCoolDown;

    public KeyCode actionA = KeyCode.X;

    /*void Start(){
        Initialize();
    }*/

    public void Initialize(){
        //GetSetAttackData();

        animator = GetComponent<Animator>();
        attackCoolDown = new WaitForSeconds(coolDownTime);
    }

    void Update(){
        /*if(Input.GetKeyDown(actionA)){
            Attack();
        }*/
        Attack();
    }

    public void Attack(){
        if(attackReady) StartCoroutine(Attack1());
    }

    IEnumerator Attack1(){
        attackReady = false;
        
        InvokeEnemies();

        yield return attackCoolDown;
        attackReady = true;
    }

    public void InvokeEnemies(){
        animator.SetTrigger("Attack");

        foreach (Vector3 point in spawnPoints)
        {
            CreateEnemy(transform.position + point);
        }
    }

    private void CreateEnemy(Vector3 position){
        GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
