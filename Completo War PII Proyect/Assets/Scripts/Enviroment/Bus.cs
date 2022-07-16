using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bus : MonoBehaviour
{
    private BoxCollider2D col;
    //private DialogueTrigger trigger;

    public KeyCode actionA = KeyCode.E;

    private bool isNearPlayer;
    //private bool isTalking;

    [SerializeField] UnityEngine.Events.UnityEvent evento;

    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        //trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    void Update()
    {
        if(Input.GetKeyDown(actionA) && isNearPlayer){
              evento.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isNearPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        isNearPlayer = false;
    }
}
