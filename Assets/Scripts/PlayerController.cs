using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private PlayerInputActions playerControls;
    
    private InputAction movement;
    InputAction jumpAction; // Add this for jump input
    InputAction fireAction;
    InputAction altFireAction;
    
    public int moveSpeed = 10;
    public int jumpPower = 5;
    
    private Vector2 moveDirection = Vector2.zero;
    private bool isGrounded = true;
    [SerializeField] LayerMask groundLayer;  // For checking if grounded
    [SerializeField] Transform groundCheck;  // Position to check for ground
    [SerializeField] float groundCheckRadius = 0.2f; // Radius for ground check
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
    }
    
    void OnEnable()
    {
        InputActions();
        movement.Enable();
        jumpAction.Enable();
        //fireAction.Enable();
        //altFireAction.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        jumpAction.Disable();
        //fireAction.Disable();
        //altFireAction.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = movement.ReadValue<Vector2>().normalized;
        Vector2 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, currentVelocity.y);
    }
    
    void FixedUpdate()
    {
        CheckIfGrounded(); // Check if the player is on the ground
    }

    void InputActions()
    {
        movement = playerControls.Player.Move;
        jumpAction = playerControls.Player.Jump;
        fireAction = playerControls.Player.Fire;
        //altFireAction = playerControls.Player.AltFire;
        movement.performed += Move;
        jumpAction.performed += Jump;
        //fireAction.performed += Fire;
        //altFireAction.performed += AltFire;
    }
    
    void Move(InputAction.CallbackContext context)
    {
        Debug.Log("There's movement");
    }
    
    void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower); // Apply upward force for jump
            Debug.Log("Jumping");
        }
    }
    
    void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    
    /*void Fire(InputAction.CallbackContext context)
    {
        Command fireCommand = new FireCommand(rb, bulletSpeed, moveDirection, BulletType.Normal);
        fireCommand.Execute();
    }

    void AltFire(InputAction.CallbackContext context)
    {
        Command fireCommand = new FireCommand(rb, bulletSpeed, moveDirection, BulletType.Large);
        fireCommand.Execute();
    }*/


    
}
