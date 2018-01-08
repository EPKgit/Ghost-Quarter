using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour 
{
	public GameObject interactionPrefab;

	protected bool playerInRange;
	protected GameObject interactionDisplay;
	private bool isInteractable;
	
	protected virtual IEnumerator Start () 
	{
		if(this.GetComponent<Collider2D>() == null)
			Debug.Log(this.name + " does not have the required collider.");
		yield return new WaitUntil(()=>PlayerEventEmitter.instance != null);
		PlayerEventEmitter.instance.interact.AddListener(AttemptInteract);
		isInteractable = true;
	}
	
	void AttemptInteract()
	{
		if(playerInRange && isInteractable)
		{
			Interact(PlayerEventEmitter.instance.gameObject);
		}

	}

	public void removeInteractability()
	{
		isInteractable = false;
		if(interactionDisplay != null)
			Destroy(interactionDisplay);
	}

	public abstract void Interact(GameObject user);
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player" && isInteractable)
		{
			playerInRange = true;
			interactionDisplay = Instantiate(interactionPrefab, this.gameObject.transform, false);
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player" && isInteractable)
		{
			playerInRange = false;
			Destroy(interactionDisplay);
		}
	}
}
