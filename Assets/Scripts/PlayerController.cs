using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private int amountOfJumps = 2;
    private int jumpsRemaining;

    [Header("Player Controls")]
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rigidBody;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rigidBody = GetComponent<Rigidbody2D>();
        playerControls.Movement.Jump.performed += OnJump;
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Update()
    {
        PlayerInput();
        CheckIsGrounded();
        HandleVariableJump();
        UpdateAnimations();
        FlipSprite();
        ResetJumps();
    }

    private void FixedUpdate()
    {
        Move();
        HandleBetterFall();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void CheckIsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Move()
    {
        rigidBody.linearVelocity = new Vector2(movement.x * moveSpeed, rigidBody.linearVelocity.y);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
            if (!isGrounded) { 
                playerAnimator.SetTrigger("doubleJump");
            }

            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpForce);
            jumpsRemaining--;

            SoundManager.Instance.PlayJumpSound();
        }
    }

    private void ResetJumps()
    {
        if (isGrounded)
        {
            jumpsRemaining = amountOfJumps;
        }
    }

    private void HandleBetterFall()
    {
        if (rigidBody.linearVelocity.y < 0)
        {
            rigidBody.linearVelocity += Vector2.up * Physics2D.gravity * fallMultiplier * Time.fixedDeltaTime;
        }
    }

    private void HandleVariableJump()
    {
        bool realsedJumpEarly = rigidBody.linearVelocity.y > 0 && !playerControls.Movement.Jump.IsPressed();

        //Debug.Log(realsedJumpEarly);

        if (realsedJumpEarly)
        {
            rigidBody.linearVelocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        }
    }

    private void UpdateAnimations()
    {
        playerAnimator.SetFloat("moveX", movement.x);
        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    private void FlipSprite()
    {
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
