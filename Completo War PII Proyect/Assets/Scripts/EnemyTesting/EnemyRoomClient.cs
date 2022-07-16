using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomClient : MonoBehaviour
{
    //Room reference
    public GameObject room;

    void Start()
    {
        room.GetComponent<RoomController>().updateEnemyCount(1);
    }


    void Update()
    {
        
    }

    void die(){
        room.GetComponent<RoomController>().updateEnemyCount(-1);
    }
}
