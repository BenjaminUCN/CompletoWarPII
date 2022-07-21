using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuescoSpawnPlanta : MonoBehaviour
{
    [SerializeField] private GameObject PlantaPrefab;

    void Start(){
        Invoke("SpawnPlanta", 3.5f);
    }

    void SpawnPlanta(){
        GameObject defeated = Instantiate(PlantaPrefab,transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
