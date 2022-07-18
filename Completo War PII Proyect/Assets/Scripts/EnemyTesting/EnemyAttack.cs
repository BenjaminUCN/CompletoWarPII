using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //Gun reference
    [SerializeField] private GameObject Gun;
    //Player reference
    [SerializeField] private Transform target;

    [Header("Attack:")]
    [SerializeField] private AttackScriptableObject attackData;

    //public float attackDamage = 1f;
    //public float bulletSpeed = 70f;

    public float attackRange = 100f;
    public int shootsPerAttack = 3;
    public float cadencyTime = 0.3f;
    public float coolDownTime = 3f;
    private bool attackReady = true;

    private WaitForSeconds shootCadency, shootCoolDown;

    private bool attackEnabled = true;

    public void Initialize(){
        SetTarget(FindClosestPlayer().transform);
        GetSetAttackData();

        shootCadency = new WaitForSeconds(cadencyTime);
        shootCoolDown = new WaitForSeconds(coolDownTime);
    }

    void Update(){
        SetTarget(FindClosestPlayer().transform);
        if(attackEnabled){
            Attack();
        }
    }

    public void SetAttackEnabled(bool enable){
        attackEnabled = enable;
    }

    public void SetTarget(Transform target){
        this.target = target;
        Gun.GetComponent<GunController>().SetTarget(target);
    }

    public void GetSetAttackData(){
        this.attackRange = attackData.attackRange;
        this.shootsPerAttack = attackData.shootsPerAttack;
        this.cadencyTime = attackData.cadencyTime;
        this.coolDownTime = attackData.coolDownTime;
    }

    public void Attack(){
        float distance = Vector2.Distance(transform.position,target.position);

        //si esta a la distancia de ataque
        if(attackReady && distance <= attackRange){
            StartCoroutine(Attack1());
        }
    }

    private void OnDisable() {
        StopCoroutine(Attack1());
    }

    IEnumerator Attack1(){
        attackReady = false;
        for(int i=0;i<shootsPerAttack;i++){
            Gun.GetComponent<GunController>().Shoot();
            yield return shootCadency;
        }
        yield return shootCoolDown;
        attackReady = true;
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
