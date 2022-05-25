using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public int enemyCount;
    public bool clear;

    void Start(){
        OpenDoors();
    }

    public void updateEnemyCount(int value){
        enemyCount += value;

        if(enemyCount <= 0){
            clear = true;
            OpenDoors();
        }
    }

    public void OpenDoors(){
        for(int i=0; i< this.gameObject.transform.childCount; i++){
            GameObject door = this.gameObject.transform.GetChild(i).gameObject;
            door.GetComponent<DoorController>().Open();
        }
    }

    public void CloseDoors(){
        for(int i=0; i < this.gameObject.transform.childCount; i++){
            GameObject door = this.gameObject.transform.GetChild(i).gameObject;
            door.GetComponent<DoorController>().Close();
        }
    }
}
