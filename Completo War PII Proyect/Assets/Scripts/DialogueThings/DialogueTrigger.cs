using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void Start(){
        //Read reader = gameObject.GetComponent<Read>();
        //reader.getLines(dialogue);

        gameObject.GetComponent<Reader>().getLines(dialogue);
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
