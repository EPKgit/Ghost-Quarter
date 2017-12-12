using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

	public static PlayerMovement instance;

	private Rigidbody2D rb;
	private BoxCollider2D col;

	void Start ()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(this);
		
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<BoxCollider2D>();
	}

	void Update () 
	{
		float MoveHorizontal = Input.GetAxisRaw("Horizontal");
		float MoveVertical = Input.GetAxisRaw("Vertical");

		rb.velocity = new Vector2(MoveHorizontal, MoveVertical);
	}
}
