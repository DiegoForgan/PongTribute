using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rigidBody;
    [SerializeField] private Transform ball;

    private float movement;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target;
        if(ball.position.x < 0) target = Vector2.zero;
        else target = ball.position;
        if(target == Vector2.zero && _rigidBody.position.y <= 0.1f && _rigidBody.position.y >= -0.1f){ 
            movement = 0f;
            return;
        }
        if(target.y < _rigidBody.position.y) movement = -1;
        else movement = 1;
    }


    private void FixedUpdate() {
        Vector2 nextMovement = new Vector2(0,movement*Time.fixedDeltaTime*_movementSpeed);
        _rigidBody.MovePosition(_rigidBody.position+nextMovement);
    }
}
