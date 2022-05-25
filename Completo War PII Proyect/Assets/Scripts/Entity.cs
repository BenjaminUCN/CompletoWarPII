using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Entity: MonoBehaviour
{
    [Header("Entity:")]
    public float hp = 6;
    public float maxHp = 6;
    public float moveSpeed = 5f;
    public float attackDamage = 1f;

    public Color defaultColor;
    public Color hurtColor;
    bool isHitted = false;

    //bool invulnerable = false;
    //float invulnerableTime = 0.2f;

    public virtual void takeDamage(float damage){
        gameObject.GetComponent<AudioSource>().Play();
        if(!isHitted){
            hp -= damage;
            StartCoroutine(SwitchHurtColor());
        }
        
        if(hp <= 0.0f){
            Die();
        }
    }

    IEnumerator SwitchHurtColor(){
        isHitted = true;
        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
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
