using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;



public class rigidbody : MonoBehaviour
{
    PlayerInput input;
    InputAction jumpAction;
    InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnJump (InputAction.CallbackContext ctx) {
       // rb.AddForce(Vector3.up * jumpForce);    
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        //rb.AddForce(Vector2.front * moveAction.ReadValue<Vector2>);
    }
    void Awake()
    {
        input = GetComponent<PlayerInput>();
        moveAction = input.actions["Move"];
        jumpAction = input.actions["Jump"];
        jumpAction.performed += OnJump;
        moveAction.performed += OnMove;
    }


    // Update is called once per frame
    void Update()
    {
        const float speed = 1f;
        Vector2 move = input.actions["Move"].ReadValue<Vector2>();
        transform.Translate(move * speed * Time.deltaTime);
    }
}
