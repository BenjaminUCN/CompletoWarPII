using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MeleeAttack : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Vector3 attackPointOffset = new Vector3( 0.0f, -8.4f, 0.0f);
    [SerializeField] private float attackRange = 16f;
    [SerializeField] private LayerMask enemyLayers;

    [SerializeField] private float damage = 1f;

    [SerializeField] private float coolDownTime = 1f;
    private bool attackReady = true;

    private WaitForSeconds attackCoolDown;

    //public KeyCode actionA = KeyCode.X;

    private float offsetX;

    public void Initialize(){
        //GetSetAttackData();

        animator = GetComponent<Animator>();
        attackCoolDown = new WaitForSeconds(coolDownTime);
        offsetX = attackPointOffset.x;
    }

    public void TurnAttackPointOffset(){
        if(GetComponent<SpriteRenderer>().flipX == true){
            attackPointOffset.x = -offsetX;
        }else{
            attackPointOffset.x = offsetX;
        }
        
    }

    void Update(){
        TurnAttackPointOffset();
        Attack();
    }

    public void Attack(){
        if(attackReady) StartCoroutine(Attack1());
    }

    public void Jump(){
        // Play an attack animation
        animator.SetTrigger("Attack");

        // Detect entities in range of attack
        Collider2D[] hitEntities = Physics2D.OverlapCircleAll(transform.position + attackPointOffset, attackRange, enemyLayers);

        // Damage them
        foreach(Collider2D entity in hitEntities){
            Debug.Log("hit "+ entity.name);

            if(entity.gameObject.TryGetComponent<PlayerController>(out PlayerController player)){
                    player.takeDamage(damage);
            } 
        }
    }

    IEnumerator Attack1(){
        attackReady = false;
        
        Jump();

        yield return attackCoolDown;
        attackReady = true;
    }

    private void OnDrawGizmosSelected() {
        if(attackPointOffset == null){
            return;
        }

        Gizmos.DrawWireSphere(transform.position + attackPointOffset, attackRange);
    }
}
