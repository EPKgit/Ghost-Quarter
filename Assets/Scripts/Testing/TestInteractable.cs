using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInteractable : Interactable 
{

	public Sprite oChest;
	public Sprite cChest;

	private bool chestOpen;
	private SpriteRenderer sp;

	protected override IEnumerator Start()
	{
		yield return StartCoroutine(base.Start());
		chestOpen = false;
		sp = GetComponent<SpriteRenderer>();
		particleSystem.Stop();
	}

	
	public override void Interact(GameObject user)
	{
		chestOpen = !chestOpen;
		animator.SetBool("IsOpen", chestOpen);
	}

}
