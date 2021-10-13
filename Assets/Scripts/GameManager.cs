using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text PlayerScoreText;
    [SerializeField] private TMP_Text EnemyScoreText;

    private int playerScore = 0;
    private int enemyScore = 0;
    private bool gameFinished = false;

    [SerializeField] private TMP_Text WinnerText;
    [SerializeField] private GameObject WinnerPanel;


    private static GameManager instance;
    private readonly int WINTHRESHOLD = 15;

    public static GameManager Instance{

        get{
           if(instance == null) instance = FindObjectOfType<GameManager>();
           return instance; 
        }
    }
    
    private void Start() {
        FindObjectOfType<AudioManager>().Play("GameTheme");
    }
    public void UpdatePlayerScore(){
        playerScore++;
        PlayerScoreText.SetText(playerScore.ToString());
        if(playerScore == WINTHRESHOLD) ShowWinner("WON !!!");
    }

    public void UpdateEnemyScore(){
        enemyScore++;
        EnemyScoreText.SetText(enemyScore.ToString());
        if(enemyScore == WINTHRESHOLD) ShowWinner("LOST :(");
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Mouse0) && gameFinished){
            RestartGame();
        }
    }

    private void RestartGame()
    {
        gameFinished = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    private void ShowWinner(string status){
        WinnerText.SetText("YOU "+status);
        WinnerPanel.SetActive(true);
        gameFinished = true;
        Time.timeScale = 0f;
    }
}
