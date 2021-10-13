using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private void Start() {
        FindObjectOfType<AudioManager>().Play("MenuTheme");
    }
    public void StartGame(){
        FindObjectOfType<AudioManager>().Stop("MenuTheme");
        FindObjectOfType<AudioManager>().Play("GameTheme");
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
