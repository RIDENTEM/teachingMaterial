using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class benderMovement : MonoBehaviour
{


    private float benderCurrentSpeed = 0.0f;
    private float benderMaxSpeed = 10.0f; // The max speed bender can go
    private float groundedRadius = 0.2f; // The radius of our ground check
    private float benderJumpForce = 400.0f;
    private bool isGrounded = false; // Determines whether or not bender is touching the ground
    private bool isJumping; // Determines whether or not bender is jumping
    private bool facingRight; // Determines if bender is facing our right
    private SpriteRenderer benderSprite; // This is our bender sprite, which is just the image we see of him
    private Rigidbody2D benderRB; 
    private Animator benderAnimator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;

    // The first function that is called on any GameObject when Play mode is activated
    private void Awake()
    {
        facingRight = true;
        benderRB = GetComponent<Rigidbody2D>();
        benderSprite = GetComponent<SpriteRenderer>();
        benderAnimator = GetComponent<Animator>();
        isJumping = false;
    }

    // Flip bender's sprite
    void flipSprite()
    {
        benderSprite.flipX = facingRight;
        facingRight = !facingRight;
    } 

    void getPlayerInput()
    {

        // Set bender's current speed to whatever our Horizontal axis is bound to (i.e. the 'a' and 'd' keys on our keyboard)
        benderCurrentSpeed = CrossPlatformInputManager.GetAxis("Horizontal");

        benderAnimator.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        { 
            benderAnimator.SetFloat("Speed", Mathf.Abs(benderCurrentSpeed));
             
            
        }
        // Set the velocity of bender's rigidbody to the value we get from our input multipled by his max speed
        // and the velocity he is traveling on the y axis which will be calculated when we jump
        benderRB.velocity = new Vector2(benderCurrentSpeed * benderMaxSpeed, benderRB.velocity.y);

    }

    // Gets called every 0.02 seconds, or fixed frame
    private void FixedUpdate()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }

        // Set the isGrounded bool inside the animator 
        benderAnimator.SetBool("isGrounded", isGrounded);

        // Set the vertical speed of bender after we have jumped
        benderAnimator.SetFloat("vSpeed", benderRB.velocity.y);

        // Get our input  
        getPlayerInput();

        // Check if we should flip bender's sprite around to face the right direction
        if (benderCurrentSpeed > 0 && !facingRight)
        {
            flipSprite();
        }
        else if (benderCurrentSpeed < 0 && facingRight)
        {
            flipSprite();
        }

        // Check if we can jump
        if (isGrounded && isJumping && benderAnimator.GetBool("isGrounded"))
        {
            isGrounded = false;
            benderAnimator.SetBool("isGrounded", false);
            benderRB.AddForce(new Vector2(0.0f, benderJumpForce));
        }
        isJumping = false;

    }

    // Gets called every frame
    void Update()
    {
        if (!isJumping)
        {
            isJumping = Input.GetKeyDown(KeyCode.Space);
        }
    }
     
     
}
