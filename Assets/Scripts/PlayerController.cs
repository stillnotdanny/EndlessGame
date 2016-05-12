﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	private Rigidbody2D myRigidbody;
	public bool grounded;
	public LayerMask whatIsGround;
	private Collider2D myCollider;
	private Animator myAnimator;
	public float lockPos = 0;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);
		if (grounded) {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);	
			}
		}
		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);
	}
}
