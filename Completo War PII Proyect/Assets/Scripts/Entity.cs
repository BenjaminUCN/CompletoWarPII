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

    [Header("Die: ")]
    [SerializeField] private AudioClip defeatClip;
    [SerializeField] private Sprite defeatedSprite;
    [SerializeField] private GameObject defeatedPrefab;

    public virtual void takeDamage(float damage){
        
        gameObject.GetComponent<AudioSource>().Play();
        if(!isHitted){
            OnTakeDamage?.Invoke();
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
        GameObject defeated = Instantiate(defeatedPrefab,transform.position,transform.rotation);
        defeated.GetComponent<AudioSource>().clip = defeatClip;
        defeated.GetComponent<AudioSource>().Play();
        defeated.GetComponent<SpriteRenderer>().sprite = defeatedSprite;

        Destroy(gameObject);
    }
    /*
    IEnumerator BecomeVulnerable(){
        yield return new WaitForSeconds(invulnerableTime);
    }*/
}
