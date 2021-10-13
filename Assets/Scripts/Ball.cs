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
        _rigidBody = GetComponent<Rigidbody2D>();
        LaunchOnRandomDirection();
    }

    private void LaunchOnRandomDirection(){
        _rigidBody.position = Vector2.zero;
        _rigidBody.velocity = Vector2.zero;
        
        int randomDirection = (Random.Range(0,2) == 0) ? 1 : -1;
        int randomX = (Random.Range(0,2) == 0) ? 1 : -1;
        int randomY = (Random.Range(0,2) == 0) ? 1 : -1;

        _rigidBody.AddForce(new Vector2(randomX,randomY)*_forceMultiplier*randomDirection,ForceMode2D.Impulse);
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
        int direction = 0;
        if (other.gameObject.CompareTag("PlayerGoalZone")) 
        {//Update enemy score +1
            GameManager.Instance.UpdateEnemyScore();
            direction = 1;
        }
        if (other.gameObject.CompareTag("EnemyGoalZone")) 
        {//Update player score+1 
            GameManager.Instance.UpdatePlayerScore();
            direction = -1;
        }
        LaunchToDirection(direction);    
    }

    private void LaunchToDirection(int direction)
    {
        _rigidBody.position = Vector2.zero;
        _rigidBody.velocity = Vector2.zero;
        
        int randomY = (Random.Range(0,2) == 0) ? 1 : -1;

        _rigidBody.AddForce(new Vector2(direction,randomY)*_forceMultiplier,ForceMode2D.Impulse);
    }
}
