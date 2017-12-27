using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInteractable : Interactable {

	public Sprite oChest;
	public Sprite cChest;

	private bool chestOpen;
	private SpriteRenderer sp;

	IEnumerator Start()
	{
		yield return StartCoroutine(base.Start());
		chestOpen = false;
		sp = GetComponent<SpriteRenderer>();
	}

	
	public override void Interact(GameObject user)
	{
		chestOpen = !chestOpen;
		if(chestOpen)
			sp.sprite = oChest;
		else
			sp.sprite = cChest;
	}
}
