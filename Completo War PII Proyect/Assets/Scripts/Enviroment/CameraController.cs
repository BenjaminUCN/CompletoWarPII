using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 direction;
    public bool offset = true;
    public bool follow = false;
    public float followThreshold = 32f;
    public float stopThreshold = 1f;
    public float speed = 32f;

    void Update()
    {
        followPlayer(offset);
    }

    private void followPlayer(bool offset){
        if(offset){
            direction = playerTransform.position - transform.position; 
            direction.z =0;

            if(direction.magnitude > followThreshold){
                follow = true;   
            }
        
            if(direction.magnitude < stopThreshold){
                follow = false;
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
            }

            if(follow){
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
        }else{
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        }
    }
}
