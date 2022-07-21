using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{   

    

    public void ChangeScene(string skin){
        StaticValuesController.skin = skin;
        SceneManager.LoadScene("lvl2Alpha");
    }

    public void EscenaPersonajes() {
        SceneManager.LoadScene("Menu");
    }

    public void EscenaOpciones() {
        SceneManager.LoadScene("Options");
    }

    public void VolverAMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
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
