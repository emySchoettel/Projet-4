using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class TittleScreenManager: MonoBehaviour { 
    public string StartScene; 
    public void StartGame() {  
        SceneManager.LoadScene(StartScene,LoadSceneMode.Single);  
    }  
    public void LoadGame() {  
        //TODO système de chargement. 
    }  
    public void ExitGame() {  
        Debug.Log("exitgame");  
        Application.Quit();  
    }  
}  
