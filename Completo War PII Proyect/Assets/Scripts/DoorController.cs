using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool Horizontal;
    public bool Vertical;

    public float crossingDistance = 100f;

    public Color defaultColor;

    void Start(){
        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        RoomController room = this.gameObject.transform.parent.gameObject.GetComponent<RoomController>();

        if(other.gameObject.name == "Player" && !room.clear){
            Transform playerTransform = other.gameObject.GetComponent<Transform>();
            Vector3 direction = new Vector3();

            if(Horizontal){
                direction = new Vector3(transform.position.x - playerTransform.position.x, 0.0f, 0.0f);
            }

            if(Vertical){
                direction = new Vector3(0.0f, transform.position.y - playerTransform.position.y, 0.0f);
            }
            direction = direction.normalized;

            playerTransform.position += direction * crossingDistance;

            
            room.CloseDoors();
        }
        

    }

    public void Open(){
        Collider2D col = gameObject.GetComponent<Collider2D>();
        col.isTrigger = true;

        //cambia color puerta abierta
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
    }

    public void Close(){
        Collider2D col = gameObject.GetComponent<Collider2D>();
        col.isTrigger = false;

        //cambia color puerta cerrada
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
    }
}
