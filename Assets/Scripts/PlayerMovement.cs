using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed;

	private Rigidbody2D rb;
	private CircleCollider2D col;

	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<CircleCollider2D> ();
	}

	void Update ()
	{
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		rb.velocity = new Vector2 (moveHorizontal * movementSpeed, moveVertical * movementSpeed);
	
	}
}
