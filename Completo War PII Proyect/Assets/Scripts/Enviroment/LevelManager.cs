using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void EndGame(){
        if(!gameHasEnded){
            gameHasEnded = true;
            Invoke("Restart", 2f);
        }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
