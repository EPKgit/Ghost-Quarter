using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour 
{
	public GameObject interactionPrefab;

	private bool playerInRange;
	private GameObject interactionDisplay;

	protected IEnumerator Start () 
	{
		if(this.GetComponent<Collider2D>() == null)
			Debug.Log(this.name + " does not have the required collider.");
		yield return new WaitUntil(()=>PlayerInteraction.instance != null);
		PlayerInteraction.instance.interact.AddListener(AttemptInteract);
	}
	
	void AttemptInteract()
	{
		if(playerInRange)
		{
			Interact(PlayerInteraction.instance.gameObject);
		}

	}

	public abstract void Interact(GameObject user);
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player")
		{
			playerInRange = true;
			interactionDisplay = Instantiate(interactionPrefab, this.gameObject.transform, false);
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player")
		{
			playerInRange = false;
			Destroy(interactionDisplay);
		}
	}
}
