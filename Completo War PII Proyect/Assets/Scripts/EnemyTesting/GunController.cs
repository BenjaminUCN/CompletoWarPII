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

    [SerializeField] private int bulletsPerShoot = 3; //Bullets created in 1 shot
    [SerializeField] private float bulletsAngle = 5f; //Angle between the bullets

    [SerializeField] private KeyCode actionA = KeyCode.Z;

    void Start(){
        Debug.Log(transform.position);
        Debug.Log(firePoint.position);

        sp = GetComponent<SpriteRenderer>();

        attackDamage = GunData.attackDamage;
        bulletSpeed = GunData.bulletSpeed;
        //sp.sprite = spriteArray[GunData.spriteIndex];
        sp.sprite = GunData.gunSprite;
        firePoint.localPosition = GunData.firePointPosition;
    }

    void Update()
    {
        Aim();
        TurnDirection();

        if(Input.GetKeyDown(actionA)){
            Shoot2(bulletsPerShoot, bulletsAngle);
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

        float rad = Mathf.Atan2(y, x);
        CreateBullet(direction, rad);

        /*GameObject b = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        b.GetComponent<BulletController>().targetName = "Player";
        Debug.Log(bulletSpeed);
        b.GetComponent<BulletController>().speed = bulletSpeed;
        b.GetComponent<BulletController>().movement = direction;
        b.GetComponent<BulletController>().damage = attackDamage;
        b.GetComponent<AudioSource>().Play();*/
    }

    public void Shoot2(int n, float angle){
        float x = target.position.x - transform.position.x; 
        float y = target.position.y - transform.position.y;
        Vector2 direction = new Vector2(x,y).normalized;

        float rad = Mathf.Atan2(y, x);
        angle = angle * Mathf.Deg2Rad;

        float offset = 0f;
        if(n%2==0){
            offset = angle/2;
            n = (n-2)/2;

            //Create first 2 bullets
            direction = new Vector2(Mathf.Cos(rad+offset), Mathf.Sin(rad+offset));
            CreateBullet(direction, rad+offset);
            direction = new Vector2(Mathf.Cos(rad-offset), Mathf.Sin(rad-offset));
            CreateBullet(direction, rad-offset);
        }else{
            //Create first Bullet
            CreateBullet(direction, rad);
            n = (n-1)/2;
        }

        //Create the rest of the bullets in pairs
        for(int i=1;i<=n;i++){
                direction = new Vector2(Mathf.Cos(rad+(i*angle)+offset), Mathf.Sin(rad+(i*angle)+offset));
                CreateBullet(direction, rad+(i*angle)+offset);
                direction = new Vector2(Mathf.Cos(rad-(i*angle)-offset), Mathf.Sin(rad-(i*angle)-offset));
                CreateBullet(direction, rad-(i*angle)-offset);
            }
        
    }

    public void CreateBullet(Vector2 dir, float angle){
        GameObject b = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        b.transform.eulerAngles = new Vector3(0.0f,0.0f,angle* Mathf.Rad2Deg -180f);

        b.GetComponent<SpriteRenderer>().sprite = GunData.bulletSprite;

        BulletController bc = b.GetComponent<BulletController>();
        bc.targetName = "Player";
        bc.damage = attackDamage;
        bc.speed = bulletSpeed;
        bc.movement = dir;

        if(GunData.bulletSound != null) b.GetComponent<AudioSource>().clip = GunData.bulletSound;
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
