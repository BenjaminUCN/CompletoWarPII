using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(BoxCollider2D))]
public class Entity: MonoBehaviour
{
    [Header("Entity:")]
    public float hp = 6;
    public float maxHp = 6;
    public float moveSpeed = 5f;
    public float attackDamage = 1f;

    private Color defaultColor;
    public Color hurtColor = new Color(1f, 0.30196078f, 0.30196078f);
    bool isHitted = false;

    [SerializeField] private UnityEvent OnTakeDamage;
    //bool invulnerable = false;
    //float invulnerableTime = 0.2f;

    public virtual void takeDamage(float damage){
        OnTakeDamage?.Invoke();
        gameObject.GetComponent<AudioSource>().Play();
        if(!isHitted){
            hp -= damage;
            StartCoroutine(Invulnerability());
        }
        
        if(hp <= 0.0f){
            Die();
        }
    }

    IEnumerator Invulnerability(){
        isHitted = true;

        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        WaitForSeconds wait = new WaitForSeconds(0.1f);

        defaultColor = sp.color;
        sp.color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return wait;
        sp.color = defaultColor;
        yield return wait;
        sp.color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return wait;
        sp.color = defaultColor;
        
        isHitted = false;
    }

    public virtual void Die(){
        Destroy(gameObject);
    }
    /*
    IEnumerator BecomeVulnerable(){
        yield return new WaitForSeconds(invulnerableTime);
    }*/
}
