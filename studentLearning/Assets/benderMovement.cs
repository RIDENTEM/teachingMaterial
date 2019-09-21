using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benderMovement : MonoBehaviour {


    private float benderMaxSpeed = 10.0f; // The max speed bender can go
    private float groundedRadius = 0.2f;
    private bool isGrounded;
    private Animator benderAnimator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float benderJumpForce = 400.0f;


    private void Awake()
    {
        benderAnimator = GetComponent<Animator>();
    } 

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
    }

    // Update is called once per frame
    void Update () {
		
	}
}
