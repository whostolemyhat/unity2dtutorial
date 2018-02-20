using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	private Rigidbody2D playerBody;
	private SpriteRenderer renderer;
	private Animator anim;
	private float movePlayerVector;
	private bool facingRight = false;
	public float speed = 4.0f;


	// Use this for initialization
	void Start () {
		playerBody = (Rigidbody2D)GetComponent(typeof(Rigidbody2D));
		renderer = (SpriteRenderer)GetComponent(typeof(SpriteRenderer));
		anim = (Animator)GetComponent(typeof(Animator));
	}
	
	// Update is called once per frame
	void Update () {
		movePlayerVector = Input.GetAxis("Horizontal");
		playerBody.velocity = new Vector2(movePlayerVector * speed, playerBody.velocity.y);
		anim.SetFloat("speed", Mathf.Abs(movePlayerVector));
		
		if (movePlayerVector > 0 && !facingRight) {
			Flip();
		} else if (movePlayerVector < 0 && facingRight) {
			Flip();
		}
	}

	void Flip() {
		facingRight = !facingRight;
		renderer.flipX = facingRight;
	}
}
