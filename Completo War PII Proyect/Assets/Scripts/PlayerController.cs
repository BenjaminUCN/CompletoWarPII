using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    //---Movement variables
    private Rigidbody2D rb;

    //Input 
    private float hInput;
    private float vInput;

    private Animator animator;
    private SpriteRenderer sprite;

    [Space]
    [Header("Keys:")]
    public string playerType = "";
    public KeyCode keyShoot = KeyCode.Space;
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyRight = KeyCode.D;
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;

    [Space]
    [Header("Animation:")]
    public string skin = "";
    //Animation States
    public string currentState;
    const  string state_IDLE = "player_idle";
    const  string state_HORIZONTAL = "player_left";
    const  string state_UP = "player_up";
    const  string state_DOWN = "player_down";
    //the direction the player is facing
    public Vector2 direction = Vector2.down;

    [Space]
    //bullet
    public GameObject bulletPrefab;

    private void Start() {
        this.skin = StaticValuesController.skin;
        currentState = state_IDLE;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void ChangeAnimationState(string newState){
        newState +=skin;
        //l
        if (newState == currentState) return;

        //Play the animation
        animator.Play(newState);

        //update current state
        currentState = newState;
    }

    void Update()
    {
        //get the Input from Horizontal axis
        hInput = Input.GetAxis("Horizontal"+playerType);
        //get the Input from Vertical axis
        vInput = Input.GetAxis("Vertical"+playerType);

        HandleSpritesAndAnimation();
        
        Move();

        if(Input.GetKeyDown(keyShoot)){
            //TODO shoot
            
            GameObject b;
            Vector3 bulletOrigin = transform.position + new Vector3(direction.x*8,direction.y*8,0);
            b = Instantiate(bulletPrefab,bulletOrigin,Quaternion.identity);
            b.GetComponent<BulletController>().targetName = "Enemy";
            b.GetComponent<BulletController>().movement = direction;
            b.GetComponent<BulletController>().damage = attackDamage;
        }
    }

    public override void Die(){
        Debug.Log("you died");
        //TODO
    }

    void Move(){
        //update the position
        //Vector3 vec = new Vector3(hInput * moveSpeed * Time.deltaTime, vInput * moveSpeed * Time.deltaTime, 0);
        //transform.position += vec;
        Vector2 movement = new Vector2(hInput,vInput);
        rb.velocity = movement.normalized * moveSpeed;
    }

    void HandleSpritesAndAnimation(){
        if(Input.GetKeyDown(keyLeft)){
            sprite.flipX = false;
            direction = Vector2.left;
        }
        if(Input.GetKeyDown(keyRight)){
            sprite.flipX = true;
            direction = Vector2.right;
        }
        if(Input.GetKeyDown(keyUp)){
            direction = Vector2.up;
        }
        if(Input.GetKeyDown(keyDown)){
            direction = Vector2.down;
        }

        if(hInput==0 && vInput==0){
            ChangeAnimationState(state_IDLE+directionToString());
        }else{
            if(direction == Vector2.left || direction == Vector2.right){
                ChangeAnimationState(state_HORIZONTAL);
            }
            if(direction == Vector2.down){
                ChangeAnimationState(state_DOWN);
            }
            if(direction == Vector2.up){
                //ChangeAnimationState(state_DOWN);
                ChangeAnimationState(state_UP);
            }
        }

        if(Input.GetKeyDown(KeyCode.C)){
            skin = "CJ";
        }
        if(Input.GetKeyDown(KeyCode.V)){
            skin = "";
        }

        if(direction.y != 0){
            sprite.flipX = false;
        }
    }

    string directionToString(){
        if(direction == Vector2.left){
            return "left";
        }
        if(direction == Vector2.right){
            return "left";
            //return "right";
        }
        if(direction == Vector2.up){
            return "up";
        }
        if(direction == Vector2.down){
            return "down";
        }
        return "";
    }
}
