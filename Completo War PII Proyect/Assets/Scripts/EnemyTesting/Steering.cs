using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    public Transform targetFollow;
    public Transform targetAvoid;

    public Vector2 steeringForces = Vector2.zero;

    public float followSpeed = 15f;
    public float slowdownDistance = 64f;
    public float speedupDistance = 200f;

    public float maxForce = 0.5f;
    public float fleeWeight = 0.5f;

    Vector2 velocity = Vector2.zero;

    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*//Get desired direction
        Vector2 playerDistance = targetFollow.position - transform.position;
        //Set to max speed
        Vector2 desiredVelocity = playerDistance.normalized * followSpeed;
        //Get steering force
        Vector2 steering = desiredVelocity - velocity;

        //Limit by max force?
        Vector2 steeringForce = steering.normalized * maxForce;
        
        velocity += steering * Time.deltaTime;*/
        


        //Debug.Log("velocity: "+velocity.magnitude);

        /*// Más cerca, más lento
        float slowndownFactor = Mathf.Clamp01(playerDistance.magnitude / slowdownDistance);
        velocity *= slowndownFactor;

        Debug.Log("slowdown: "+slowndownFactor);

        // Más cerca, más rápido
        float speedupFactor = Mathf.Clamp01(speedupDistance / playerDistance.magnitude );
        velocity *= speedupFactor;

        //Debug.Log(playerDistance.magnitude+", speedup: "+speedupFactor);

        transform.position += (Vector3) velocity * Time.deltaTime;*/
        
        //addforce(seekForce(targetFollow), 1f);
        //addforce(fleeForce(targetAvoid), fleeWeight);
        if(Vector2.Distance(transform.position, targetFollow.position) > 100){
            addforce(arriveForce(targetFollow), 1f);
            UpdateVelocity();
        }else{
            rb.velocity = Vector2.zero;
        }
        

        
        
    }

    void UpdateVelocity(){
        //Update vectors
        velocity += steeringForces;
        velocity = Vector2.ClampMagnitude(velocity, followSpeed);
        rb.velocity = velocity;
        //transform.position += (Vector3) velocity * Time.deltaTime;
    }

    public void addforce(Vector2 force, float weight){
        force *= weight;
        steeringForces += force;
    }

    public Vector2 seekForce(Transform target){
        //Get desired direction
        Vector2 playerDistance = target.position - transform.position;
        //Set to max speed
        Vector2 desiredVelocity = playerDistance.normalized * followSpeed;
        //Get steering force
        Vector2 steering = desiredVelocity - velocity;
        //Limit by max force?
        Vector2 steeringForce = Vector2.ClampMagnitude(steering, maxForce);
        //Vector2 steeringForce = steering.normalized * maxForce;

        return steeringForce;
    }

    public Vector2 fleeForce(Transform target){
        //Get desired direction
        Vector2 targetDistance = target.position - transform.position;
        //Set to max speed
        Vector2 desiredVelocity = targetDistance.normalized * followSpeed;
        desiredVelocity *= -1;
        //Get steering force
        Vector2 steering = desiredVelocity - velocity;
        //Limit by max force
        Vector2 steeringForce = Vector2.ClampMagnitude(steering, maxForce);

        return steeringForce;
    }

    public Vector2 arriveForce(Transform target){
        //Get desired direction
        Vector2 targetDistance = target.position - transform.position;
        //Set to max speed
        Vector2 desiredVelocity = targetDistance.normalized * followSpeed;
        
        // Más cerca, más lento
        float slowndownFactor = Mathf.Clamp01(targetDistance.magnitude / slowdownDistance);
        desiredVelocity *= slowndownFactor;
        
        //Get steering force
        Vector2 steering = desiredVelocity - velocity;
        //Limit by max force
        //Vector2 steeringForce = Vector2.ClampMagnitude(steering, maxForce);

        //return steeringForce;
        return steering;
    }
}
