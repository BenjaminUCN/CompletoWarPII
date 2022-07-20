using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private float moveSpeed;

    private float distance;
    
    [Space]
    [SerializeField] private Transform target;//player reference

    [Space]
    [Header("IA:")]
    [SerializeField] private IAScriptableObject IAData; 
    [SerializeField] private float sightDistance = 100f;
    [SerializeField] private float minimumFollowDistance = 64f;
    [SerializeField] private float minimumRetreatDistance = 0f;

    private bool movementEnabled = true;

    [SerializeField] private UnityEvent OnTurnDirection;
    [SerializeField]private bool localEnable = true;

    public void Initialize(){
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        //this.moveSpeed = moveSpeed;
        this.moveSpeed = IAData.moveSpeed;

        this.sightDistance = IAData.sightDistance;
        this.minimumFollowDistance = IAData.minimumFollowDistance;
        this.minimumRetreatDistance = IAData.minimumRetreatDistance;
    }

    void Update(){
        SetTarget(FindClosestPlayer().transform);
        if(movementEnabled){
            Move();
        }
    }

    private void OnDisable() {
        //se queda quieto
        animator.SetBool("IsMoving", false);
        rb.velocity = new Vector2(0,0);
    }

    public void SetMovementEnabled(bool enable){
        movementEnabled = enable;
    }

    public void SetTarget(Transform target){
        this.target = target;
    }

    public void Move(){
        distance = Vector2.Distance(transform.position,target.position);

        //si esta dentro de la distancia de vision y lejos
        if(distance > minimumFollowDistance && distance <= sightDistance){
            moveTo(target.position,1);
        }else //si esta demasiado cerca
        if(distance < minimumRetreatDistance){
            moveTo(target.position,-1);
        }else{
            //se queda quieto
            animator.SetBool("IsMoving", false);
            rb.velocity = new Vector2(0,0);
        }
    }

    public void moveTo(Vector2 point,int aproachValue){
        animator.SetBool("IsMoving", true);

        Vector2 moveDirection = new Vector2(point.x -transform.position.x,point.y -transform.position.y); 
        rb.velocity = moveDirection.normalized * moveSpeed * aproachValue;

        if(moveDirection.x < 0){
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }else{
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
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

    public void SetLocalEnable(bool enable){
        localEnable = enable;
        //se queda quieto
        animator.SetBool("IsMoving", false);
        rb.velocity = new Vector2(0,0);
    }
}
