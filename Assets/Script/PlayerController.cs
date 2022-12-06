using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour

{
    private Rigidbody2D rb;
    private Vector3 velocity;

    [Header("Movement")]
    public float speed;
    private Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    public float smoothTime = 0.1f;

    [Header("Jump")]
    private bool isGrounded = false;
    public float jumpForce = 2f;
    public float jumpForceHolding = 0.5f;
    private bool isHolding = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Movement(InputAction.CallbackContext context)
    {
        movementInput.x = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (rb.velocity.y == 0 && isGrounded)
            {
                isHolding = true;
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        if(context.canceled && !context.started)
        {
            isHolding = false;
        }
        if (context.performed && !context.started)
        {
            isHolding = false;
        }
    }

    private void AddJumpForce()     // let the player jump higher if is holding the jump button
    {
        if (isHolding)
        {
            rb.AddForce(new Vector2(0, jumpForceHolding), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            movementInput,
            ref movementInputSmoothVelocity,
            smoothTime);

        velocity = rb.velocity;
        velocity.x = smoothedMovementInput.x * speed;
        rb.velocity = velocity;
        AddJumpForce();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}