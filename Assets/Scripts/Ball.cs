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

    private void OnBecameInvisible() {
        RestartBall();
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

    private void OnCollisionEnter2D() {
        FindObjectOfType<AudioManager>().Play("Hit");
        _rigidBody.velocity *= 1.1f;
    }

    
}
