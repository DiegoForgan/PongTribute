using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    private bool GamePaused = false;
    private static PauseMenu instance;

    public static PauseMenu Instance{

        get{
           if(instance == null) instance = FindObjectOfType<PauseMenu>();
           return instance; 
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GamePaused) ResumeGame();
        } 
    }

    public void SetGamePaused(bool status){
        GamePaused = status;
    }

    void ResumeGame(){
        Time.timeScale = 1f;
        GamePaused = false;
        gameObject.SetActive(false);
    }

    public void ReturnToMainMenu(){
        GamePaused = false;
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("GameTheme");
        FindObjectOfType<AudioManager>().Play("MenuTheme");
        SceneManager.LoadScene(0);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
