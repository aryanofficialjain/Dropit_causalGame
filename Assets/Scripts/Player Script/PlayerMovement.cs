using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Rigidbody2D mybody;
    public Joystick joystick;  // Reference to the joystick

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveInput = 0f;

        // Check if joystick has input
        if (Mathf.Abs(joystick.Horizontal) > 0.1f)
        {
            moveInput = joystick.Horizontal;  // Use joystick input if available
        }
        else
        {
            moveInput = Input.GetAxisRaw("Horizontal");  // Fall back to keyboard input
        }

        // Apply movement
        if (moveInput > 0f)
        {
            mybody.velocity = new Vector2(moveSpeed, mybody.velocity.y);
            print("Right");
        }
        else if (moveInput < 0f)
        {
            mybody.velocity = new Vector2(-moveSpeed, mybody.velocity.y);
            print("Left");
        }
        else
        {
            // Stop movement when no input is detected
            mybody.velocity = new Vector2(0f, mybody.velocity.y);
        }
    }

    public void PlatformMove(float x)
    {
        mybody.velocity = new Vector2(x, mybody.velocity.y);
    }
}