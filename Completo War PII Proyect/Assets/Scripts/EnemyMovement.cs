using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyMovement : Entity
{
    /*private Animator animator;
    private Rigidbody2D rb;

    public Vector2 direction;
    
    public string enemyType = "";


    //player reference
    public Transform playerTransform;

    //bullet prefab reference
    public GameObject bulletPrefab;
    //fire point reference
    public Transform firePoint;

    public GameObject defeatedPrefab;
    [Space]
    [Header("Attack:")]
    public int shootsPerAttack = 3;
    public float shootTime = 0.3f;
    public float bulletSpeed = 70f;
    public float shootCoolDown = 3f;
    public bool attackReady = true;
    
    [Space]
    [Header("AI:")]
    public float distance;
    public float sightDistance = 100f;
    public float minimumFollowDistance = 64f;
    public float minimumRetreatDistance = 0f;

    WaitForSeconds wait;
    WaitForSeconds waitShoot;

    void Start(){
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        direction = new Vector2(0,0);

        wait = new WaitForSeconds(shootTime);
        waitShoot = new WaitForSeconds(shootCoolDown);
    }

    private void OnDisable() {
        StopCoroutine(Attack());
    }

    private void Update() {
        takeAction();
    }

    public override void Die(){
        GameObject defeated = Instantiate(defeatedPrefab,transform.position,transform.rotation);
        //room.GetComponent<RoomController>().updateEnemyCount(-1);
        base.Die();
        
    }

    void takeAction(){
        distance = Vector2.Distance(transform.position,playerTransform.position);

        //si esta dentro de la distancia de vision y lejos
        if(distance > minimumFollowDistance && distance <= sightDistance){
            moveTo(playerTransform.position,1);
        }

        //si esta demasiado cerca
        if(distance < minimumRetreatDistance){
            moveTo(playerTransform.position,-1);
        }

        //si esta a la distancia de ataque
        if(attackReady && distance <= sightDistance){
            //StartCoroutine(Attack());
        }
    }

    IEnumerator Attack(){
        Debug.Log("aaa");
    }

    void shoot(){
        direction.x = playerTransform.position.x - transform.position.x; 
        direction.y = playerTransform.position.y - transform.position.y;
        direction = direction.normalized;

        //Vector3 bulletOrigin = transform.position + new Vector3(direction.x*16,direction.y*16,0);
        GameObject b = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        b.GetComponent<BulletController>().targetName = "Player";
        Debug.Log(bulletSpeed);
        b.GetComponent<BulletController>().speed = bulletSpeed;
        b.GetComponent<BulletController>().movement = direction;
        b.GetComponent<BulletController>().damage = attackDamage;
        b.GetComponent<AudioSource>().Play();
    }

    void moveTo(Vector2 point,int aproachValue){
        Vector2 moveDirection = new Vector2(point.x -transform.position.x,point.y -transform.position.y); 
        rb.velocity = moveDirection.normalized * moveSpeed * aproachValue;

        if(moveDirection.x < 0){
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }else{
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
*/
}
