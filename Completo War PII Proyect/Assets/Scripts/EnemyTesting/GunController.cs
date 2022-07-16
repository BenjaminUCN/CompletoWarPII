using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GunController : MonoBehaviour
{   
    private SpriteRenderer sp;    
    //[SerializeField] private Sprite[] spriteArray;

    //Player reference
    [SerializeField] private Transform target;
    //Bullet prefab reference
    [SerializeField] private GameObject bulletPrefab;
    //Fire point reference
    [SerializeField] private Transform firePoint;

    [field:SerializeField] private GunScriptableObject GunData;

    private float attackDamage = 0f;
    private float bulletSpeed = 1f;

    [SerializeField] private KeyCode actionA = KeyCode.Z;

    void Start(){
        Debug.Log(transform.position);
        Debug.Log(firePoint.position);

        sp = GetComponent<SpriteRenderer>();

        attackDamage = GunData.attackDamage;
        bulletSpeed = GunData.bulletSpeed;
        //sp.sprite = spriteArray[GunData.spriteIndex];
        sp.sprite = GunData.sprite;
        firePoint.localPosition = GunData.firePointPosition;
    }

    void Update()
    {
        Aim();
        TurnDirection();

        if(Input.GetKeyDown(actionA)){
            Shoot();
        }

    }

    public void SetTarget(Transform target){
        this.target = target;
    }

    public void Aim(){
        Vector2 dir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -180f;
        transform.eulerAngles = new Vector3(0.0f,0.0f,angle);
    }

    public void Shoot(){
        float x = target.position.x - transform.position.x; 
        float y = target.position.y - transform.position.y;
        Vector2 direction = new Vector2(x,y).normalized;

        GameObject b = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        b.GetComponent<BulletController>().targetName = "Player";
        Debug.Log(bulletSpeed);
        b.GetComponent<BulletController>().speed = bulletSpeed;
        b.GetComponent<BulletController>().movement = direction;
        b.GetComponent<BulletController>().damage = attackDamage;
        b.GetComponent<AudioSource>().Play();
    }

    public void TurnDirection(){
        if(transform.position.x < target.position.x){
            sp.flipY = true;
        }else{
            sp.flipY = false;
        }
    }
}
