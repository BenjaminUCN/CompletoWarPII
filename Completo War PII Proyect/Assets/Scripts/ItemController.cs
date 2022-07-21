using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class ItemController : MonoBehaviour
{
    [SerializeField] private int healingPoints = 1;
    [SerializeField] private bool isHealingBoost = false;
    [SerializeField] private AudioClip pickClip;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            //GiveItem(other.gameObject);
            
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            HealthBar hb = (HealthBar)FindObjectOfType(typeof(HealthBar));

            if(player.hp+healingPoints >player.currentMaxHealth){
                if(isHealingBoost) player.currentMaxHealth+=2;
                hb.Heal(player.currentMaxHealth - player.hp);
                player.hp = player.currentMaxHealth;
            }else{
                player.hp += healingPoints;
                hb.Heal(healingPoints);
            }

            GameObject.FindWithTag("Audio").GetComponent<AudioSource>().PlayOneShot(pickClip, 0.7f);

            Destroy(gameObject);
        }
    }

    public virtual void GiveItem(GameObject player){
        //give benefit to player
        //Destroy(gameObject);
    }
}
