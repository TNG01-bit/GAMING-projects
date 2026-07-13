using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;



public class rigidbody : MonoBehaviour
{
    PlayerInput input;
    InputAction jumpAction;
    InputAction moveAction;
    Rigidbody rb;
    public float moveSpeed = 15f;
    public float jumpForce = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnJump (InputAction.CallbackContext ctx) {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);    
    }

     void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 i = moveAction.ReadValue<Vector2>();
        Vector3 f = new Vector3(i.x, 0.0f, i.y);
        rb.AddForce(f * moveSpeed);
    }

    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
        moveAction = input.actions["Move"];
        jumpAction = input.actions["Jump"];
        jumpAction.performed += OnJump;
        //moveAction.performed += OnMove;
        //rb.OnJump
    }


    // Update is called once per frame
    void Update()
    {
        // Pentru mișcare continuă și fluidă cu Rigidbody, citim valoarea în FixedUpdate
        //Vector2 inputVector = moveAction.ReadValue<Vector2>();

        // Transformăm mișcarea 2D în direcții 3D (X și Z)
        //Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        // Aplicăm mișcarea direct pe viteza corpului fizic
        //rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);

        Vector2 i = moveAction.ReadValue<Vector2>();
        Vector3 f = new Vector3(i.x, 0.0f, i.y);
        rb.AddForce(f * moveSpeed);
    }
}
