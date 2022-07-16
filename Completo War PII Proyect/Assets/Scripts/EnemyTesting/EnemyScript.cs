using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class EnemyScript : Entity
{
    [Space]
    [Header("Scripts: ")]
    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private EnemyMovement enemyMovement;

    [Header("Die: ")]
    [SerializeField] private GameObject defeatedPrefab;

    void Start(){
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponent<EnemyAttack>();

        enemyMovement.Initialize(moveSpeed);
        enemyAttack.Initialize();
    }

    void Update(){
        SetTarget(FindClosestPlayer().transform);

        enemyMovement.Move();
        enemyAttack.Attack();
    }

    public override void Die(){
        GameObject defeated = Instantiate(defeatedPrefab,transform.position,transform.rotation);
        //room.GetComponent<RoomController>().updateEnemyCount(-1);
        base.Die();  
    }

    void SetupComponents(){
        //
    }

    void SetTarget(Transform target){
        enemyMovement.SetTarget(target);
        enemyAttack.SetTarget(target);
    }

    public GameObject FindClosestPlayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
