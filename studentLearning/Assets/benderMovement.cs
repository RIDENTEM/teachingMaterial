using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benderMovement : MonoBehaviour
{


    private float benderMaxSpeed = 10.0f; // The max speed bender can go
    private float groundedRadius = 0.2f;
    private float jumpForce = 200.0f;
    private bool isGrounded;
    private bool isJumping;
    private SpriteRenderer benderSprite;
    private bool facingRight;
    private Rigidbody2D benderRB;
    private Animator benderAnimator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float benderJumpForce = 400.0f;


    private void Awake()
    {
        facingRight = true;
        benderRB = GetComponent<Rigidbody2D>();
        benderAnimator = GetComponent<Animator>();
        isJumping = false;
    }

    private void FixedUpdate()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }
    }

    void flipSprite()
    {
        benderSprite.flipX = facingRight;
        facingRight = !facingRight;
    }

    void benderJump()
    {
        benderRB.AddForce(new Vector2(0.0f, jumpForce));
    }

    void getPlayerInput()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {

        }
        else if(Input.GetKeyDown(KeyCode.A))
        {

        }
    }

    void Update()
    {

        if (!isJumping)
        {
            isJumping = Input.GetKeyDown(KeyCode.Space);
        }
        if(isJumping)
        {
            benderJump();
        }

    }
}
