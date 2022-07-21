using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public int enemyCount;
    public bool clear;

    public Entity[] enemies;

    void Start(){
        OpenDoors();
        enemyCount = enemies.Length;
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

    public void ActivateEnemies(){
        foreach (Entity e in enemies)
        {
            e.gameObject.SetActive(true);
        }
    }
}
