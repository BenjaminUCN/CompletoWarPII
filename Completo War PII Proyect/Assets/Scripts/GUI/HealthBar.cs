using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    public Image[] healthPoints;

    public float health = 10f;
    public float maxHealth = 10f;

    [SerializeField] private UnityEvent OnDie;

    void Start(){
        HealthBarFiller();
    }

    bool DisplayHealthPoint(float _health, int pointNumber){
        return ( (pointNumber * 10) < _health);
    }

    void HealthBarFiller(){
        for(int i= 0; i< healthPoints.Length; i++){
            if(i < health){
                healthPoints[i].enabled = true;
            }else{
                healthPoints[i].enabled = false;
            }
            //healthPoints[i].enabled = DisplayHealthPoint(health, i);
        }
    }

    public void Damage(float damagePoints){
        health -= damagePoints;
        HealthBarFiller();
        if (health <= 0) {
            OnDie?.Invoke();            
        }   
    }

    public void Heal(float healPoints){
        if(health+healPoints <= maxHealth){
            health += healPoints;
            HealthBarFiller(); 
        }
         
    }
}
