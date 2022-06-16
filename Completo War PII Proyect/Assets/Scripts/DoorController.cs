using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Color defaultColor;
    //17:09

    public bool horizontal;

    public Color openColor;
    public Color closeColor;

    //referencia a la puerta
    public GameObject door;

    private Animator animator;

    void Start(){
        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;

        animator = door.GetComponent<Animator>();
    }

    //Activación de la puerta
    private void OnTriggerEnter2D(Collider2D other) {
        RoomController room = this.gameObject.transform.parent.gameObject.GetComponent<RoomController>();

        //Si es el jugador quien la activó y la room no ha sido limpiada
        if(other.gameObject.name == "Player" && !room.clear){
            //Cierra todas las puertas de la room
            room.CloseDoors();
        }
        

    }

    public void Open(){
        Collider2D col = door.GetComponent<Collider2D>();
        col.isTrigger = true;

        //cambia color puerta abierta
        //door.GetComponent<SpriteRenderer>().color = openColor;

        if(horizontal){
            animator.Play("doorLaserHOpening");
        }else{
            animator.Play("doorLaserVOpening");
        }
        
    }

    public void Close(){
        Collider2D col = door.GetComponent<Collider2D>();
        col.isTrigger = false;

        //cambia color puerta cerrada
        //door.GetComponent<SpriteRenderer>().color = closeColor;

        if(horizontal){
            animator.Play("doorLaserHClosing");
        }else{
            animator.Play("doorLaserVClosing");
        }
        
    }
}
