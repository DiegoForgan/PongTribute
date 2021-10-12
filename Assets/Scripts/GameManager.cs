using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text PlayerScoreText;
    [SerializeField] private TMP_Text EnemyScoreText;

    private int playerScore = 0;
    private int enemyScore = 0;

    private static GameManager instance;

    public static GameManager Instance{

        get{
           if(instance == null) instance = FindObjectOfType<GameManager>();
           return instance; 
        }
    }
    
    public void UpdatePlayerScore(){
        playerScore++;
        PlayerScoreText.SetText(playerScore.ToString());
    }

    public void UpdateEnemyScore(){
        enemyScore++;
        EnemyScoreText.SetText(enemyScore.ToString());
    }
}
