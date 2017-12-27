using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

	[HideInInspector]public static PlayerMovement instance;
	public float movementSpeed;

	private Rigidbody2D rb;
	private BoxCollider2D col;
	private Animator anim;
	private Vector2 lastMove;

	void Start ()
	{
		if(instance != null)
			Destroy(this);
		instance = this;
		
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
	}

	void Update () 
	{
		float MoveHorizontal = Input.GetAxisRaw("Horizontal");
		float MoveVertical = Input.GetAxisRaw("Vertical");
		Vector2 movement = new Vector2(MoveHorizontal, MoveVertical);
		rb.velocity = movement*movementSpeed;
		UpdateAnimation(movement.normalized);
	}

	void UpdateAnimation(Vector2 dir)
	{
		if(Mathf.Abs(dir.x) <= float.Epsilon && Mathf.Abs(dir.y) <= float.Epsilon)
		{
			anim.SetFloat("LastX", lastMove.x);
			anim.SetFloat("LastY", lastMove.y);
			anim.SetBool("Movement", false);
		}
		else
		{
			//lastMove.x = rb.velocity.x*10;
			//lastMove.y = rb.velocity.y*10;
			lastMove.x = dir.x;
			lastMove.y = dir.y;
			anim.SetBool("Movement", true);
		}
		anim.SetFloat("VelocityX", dir.x);
		anim.SetFloat("VelocityY", dir.y);
	}
}
