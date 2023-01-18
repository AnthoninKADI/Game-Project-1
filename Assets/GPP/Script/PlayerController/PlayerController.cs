using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour

{
    [HideInInspector]
    public Rigidbody2D rb;
    private SpriteRenderer _renderer;
    [SerializeField]
    private PlayerAnimation _playerAnimation;

    [Header("Movement")]
    public float speed;
    [HideInInspector]
    public Vector2 movementInput;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    public float smoothTime = 0.1f;

    [Header("Jump")]
    public float jumpForce = 2f;
    public float jumpForceHolding = 0.5f;
    public bool isGrounded = false;
    private bool isHolding = false;
    public float threshold;

    [Header("WallJump")]
    [HideInInspector]
    public bool leftHitbox = false;
    [HideInInspector]
    public bool rightHitbox = false;
    [SerializeField]
    private Vector2 wallJumpForce;
    [SerializeField]
    private float wrongDirection;
    [SerializeField]
    private float jumpTime;
    private bool hasWallJumped = false;

    [Header("Electricity")]
    [SerializeField]
    private GameObject electric;
    [HideInInspector]
    public bool ElectricityActive;
    public float electricityDuration = 2f;

    [Header("")]
    [SerializeField]
    private GameObject interaction;

    private float startSpeed, startJump;

    [Header("Pause")]
    [SerializeField]
    private GameObject pauseMenu;
    [HideInInspector]
    public bool gameIsPaused = false;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        electric.SetActive(false);
        interaction.SetActive(false);
        ElectricityActive = false;
        startSpeed = speed;
        startJump = jumpForce;
    }
    private void FixedUpdate()
    {
        SmoothedMovement();
        AddJumpForce();
        SetSprite();

    }

    public void Movement(InputAction.CallbackContext context)
    {
        movementInput.x = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!leftHitbox && !rightHitbox)
            {
                if (Mathf.Abs(rb.velocity.y) < threshold && isGrounded)
                {
                    isHolding = true;
                    isGrounded = false;
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    _playerAnimation.Jumping();
                }
            }
            else
            {
                if (!hasWallJumped)
                {
                    if (leftHitbox && !isGrounded)
                    {
                        hasWallJumped = true;
                        if (smoothedMovementInput.x < -0.1f)
                        {
                            rb.velocity = new Vector2(smoothedMovementInput.x * 5 + wallJumpForce.x, wallJumpForce.y - wrongDirection);
                        }
                        else
                        {
                            rb.velocity = new Vector2(smoothedMovementInput.x * speed + wallJumpForce.x, wallJumpForce.y);
                        }
                        Invoke("NotWallJumping", jumpTime);
                    }

                    else if (rightHitbox && !isGrounded)
                    {
                        hasWallJumped = true;
                        if (smoothedMovementInput.x > 0.1f)
                        {
                            rb.velocity = new Vector2(smoothedMovementInput.x * 5 - wallJumpForce.x, wallJumpForce.y - wrongDirection);
                        }
                        else
                        {
                            rb.velocity = new Vector2(smoothedMovementInput.x * speed - wallJumpForce.x, wallJumpForce.y);
                        }
                        Invoke("NotWallJumping", jumpTime);
                    }
                }
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

    private void SmoothedMovement()
    {
        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            movementInput,
            ref movementInputSmoothVelocity,

            smoothTime);

        if (!leftHitbox && !rightHitbox)
        {
            if (!hasWallJumped)
            {
                rb.velocity = new Vector2(smoothedMovementInput.x * speed, rb.velocity.y);
            }
        }
        _playerAnimation.Running();
    }

    public void Electric(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            CameraShakes.Instance.ShakeCamera(12f, .1f);
            _playerAnimation.AttackON();
            electric.SetActive(true);
            ElectricityActive = true;
            Invoke("StopElectricity", electricityDuration);
        }
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            interaction.SetActive(true);
        }
        if (context.canceled || context.performed)
        {
            interaction.SetActive(false);
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (!gameIsPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            gameIsPaused = true;
        }
        else if(gameIsPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            gameIsPaused = false;
        }        
    }

    private void StopElectricity()
    {
        electric.SetActive(false);
        ElectricityActive = false;
    }

    private void NotWallJumping()
    {
        hasWallJumped = false;
    }

    private void AddJumpForce()     // let the player jump higher if is holding the jump button
    {
        if (isHolding)
        {
            rb.AddForce(new Vector2(0, jumpForceHolding), ForceMode2D.Impulse);
        }
    }

    public void SetVelocity(bool IsMoving)
    {
        if (IsMoving)
        {
            jumpForce = startJump;
            speed = startSpeed;
        }
        else
        {
            jumpForce = 0f;
            speed = 0f;
        }
    }

    private void SetSprite()
    {
        if (rb.velocity.x > 0)
        {
            if (!rightHitbox && !leftHitbox)
            {
                _renderer.flipX = false;
            }
        }
        else if (rb.velocity.x < 0)
        {
            if (!rightHitbox && !leftHitbox)
            {
                _renderer.flipX = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("Elevator"))
        {
            isGrounded = true;
        }
    }
}

