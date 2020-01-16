using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class benderMove : MonoBehaviour {

    float currentSpeed;
    float maxSpeed = 10.0f;
    Rigidbody2D benderRB;

	// Use this for initialization
	void Start () {
       benderRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

       currentSpeed = CrossPlatformInputManager.GetAxis("Horizontal");

        benderRB.velocity = new Vector2(currentSpeed * maxSpeed, benderRB.velocity.y);
	}
}
