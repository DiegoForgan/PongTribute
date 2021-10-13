using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    private Rigidbody2D _rigidBody;
    private float _playerMovement;
    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerMovement = Input.GetAxisRaw("Vertical");
        if ( (_rigidBody.position.y < -3.3f && _playerMovement == -1)
        || (_rigidBody.position.y > 3.3f && _playerMovement == 1) ) _playerMovement = 0f;
        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            PauseMenu.Instance.SetGamePaused(true);
        }
    }

    private void FixedUpdate() {
        Vector2 movement = new Vector2(0, _playerMovement * _movementSpeed * Time.fixedDeltaTime);
        _rigidBody.MovePosition(_rigidBody.position + movement);
    }
}
