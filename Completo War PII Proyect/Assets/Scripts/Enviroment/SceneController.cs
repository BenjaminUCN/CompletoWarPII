using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string skin){
        StaticValuesController.skin = skin;
        SceneManager.LoadScene("testLevel0");
    }

    public void EscenaPersonajes() {
        SceneManager.LoadScene("Menu");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Menu"){
            SceneManager.LoadScene("Menu");
        }    
        
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Menu"){
            SceneManager.LoadScene("MainMenu");
        }
    }
}
