using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;

    private Transform target;
    [SerializeField] private float distance;
    private SpriteRenderer sp;

    private void Start() {
        healthPoint = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();

        Introduction();
    }

    private void Update() {
        Move();
        TurnDirection();
    }

    private void Introduction(){
        Debug.Log("My name is "+enemyName+", HP: "+healthPoint+", moveSpeed: "+moveSpeed);
    }

    private void Move(){
        if (Vector2.Distance(transform.position, target.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);    
        }
        
    }

    private void TurnDirection(){
        if(transform.position.x > target.position.x){
            sp.flipX = true;
        }else{
            sp.flipX = false;
        }
    }
}
