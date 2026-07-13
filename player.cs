using UnityEngine;
using UnityEngine.InputSystem;

internal class rb { };

public class player : MonoBehaviour
{
    InputAction move, jump;
    float lastJump = -1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    void Awake()
    {
        var actions = GetComponent<PlayerInput>().actions;
        move = actions["Move"];
        jump = actions["Jump"];
        jump.performed +=_=> TryJump();
    }

    // Update is called once per frame
    void TryJump()
    {
        if (Time.time - lastJump < 0.3f) return;
        lastJump = Time.time;
        //rb.AddForce(Vector3.up * jumpForce);
    }

     void Update()
    {
        const float speed = 1f;      
        Vector2 dir = move.ReadValue<Vector2>();
            transform.Translate(dir *speed * Time.deltaTime);
    }
};
