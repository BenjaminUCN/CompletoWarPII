using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{   
    public float attackDamage = 1f;

    //bullet prefab reference
    public GameObject bulletPrefab;

    public Vector2 direction;

    //player reference
    public Transform playerTransform;

    void Start(){
        direction = new Vector2(0,0);
    }

    void Update()
    {
        
    }

    void shoot(){
        direction.x = playerTransform.position.x - transform.position.x; 
        direction.y = playerTransform.position.y - transform.position.y;
        direction = direction.normalized;

        GameObject b;
        Vector3 bulletOrigin = transform.position + new Vector3(direction.x*16,direction.y*16,0);
        b = Instantiate(bulletPrefab,bulletOrigin,Quaternion.identity);
        b.GetComponent<BulletController>().targetName = "Player";
        b.GetComponent<BulletController>().movement = direction;
        b.GetComponent<BulletController>().damage = attackDamage;
        b.GetComponent<AudioSource>().Play();
    }
}
