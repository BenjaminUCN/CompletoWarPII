using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class ItemController : MonoBehaviour
{
    [SerializeField] private float benefit;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            GiveItem(other.gameObject);
        }
    }

    public virtual void GiveItem(GameObject player){
        //give benefit to player
    }
}
