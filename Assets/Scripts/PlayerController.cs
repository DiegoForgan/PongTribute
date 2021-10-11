using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    private Rigidbody2D _rigidBody;
    private float _playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(0, _playerMovement * _movementSpeed * Time.fixedDeltaTime);
        _rigidBody.MovePosition(_rigidBody.position + movement);
    }
}
