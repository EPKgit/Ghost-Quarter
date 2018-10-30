using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Singleton<PlayerAttack>
{


	private Animator animator;

	void Start () 
	{
		animator = GetComponent<Animator>();		
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			animator.Play("PlayerAttack");
		}
	}
}
