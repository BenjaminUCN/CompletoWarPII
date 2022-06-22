using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 32f;
    public Vector2 movement = new Vector2(0,0);
    public bool isTemporal = true;
    public float lifeSpan = 8f;
    public float damage;

    public string shooterName;
    public string targetName;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        
        if(isTemporal){
            rb.velocity = new Vector2(movement.x*speed, movement.y*speed);
            lifeSpan -= Time.deltaTime;
            if(lifeSpan <= 0.0f){
                Destroy(gameObject);
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.name.Substring(0,4) == "Wall"){
            Destroy(gameObject);
        }else if(other.gameObject.tag == targetName){
            //target = enemy
            if(other.gameObject.name.Substring(0,5) == "Enemy"){
                if(other.gameObject.TryGetComponent<EnemyController>(out EnemyController enemy)){
                    enemy.takeDamage(damage);
                }  
            }
            //target = player
            if(other.gameObject.TryGetComponent<PlayerController>(out PlayerController player)){
                    player.takeDamage(damage);
                } 
            if(isTemporal){
                Destroy(gameObject);
            }
            
        }
            
        
        
    }
}
