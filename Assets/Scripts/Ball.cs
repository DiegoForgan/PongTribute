using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    
    [SerializeField] private float _forceMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("GameTheme");
        _rigidBody = GetComponent<Rigidbody2D>();
        LaunchOnRandomDirection();
    }

    private void LaunchOnRandomDirection(){
        _rigidBody.position = Vector2.zero;
        _rigidBody.velocity = Vector2.zero;
        
        int randomDirection = 0;
        while(randomDirection == 0) randomDirection = Random.Range(-1,2);
         
        _rigidBody.AddForce(new Vector2(Random.Range(1,2),Random.Range(1,2))*_forceMultiplier*randomDirection,ForceMode2D.Impulse);
    }

    private void RestartBall(){
        LaunchOnRandomDirection();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        FindObjectOfType<AudioManager>().Play("Hit");
        if (other.gameObject.CompareTag("Paddle")) {
            _rigidBody.velocity *= 1.1f;
            Debug.Log("Velocity increased");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //play score sound
        //Update score
        if (other.gameObject.CompareTag("PlayerGoalZone")) 
        //Update enemy score +1
            GameManager.Instance.UpdateEnemyScore();
        if (other.gameObject.CompareTag("EnemyGoalZone")) 
        //Update player score+1 
            GameManager.Instance.UpdatePlayerScore();
        RestartBall();
    }

    
}
