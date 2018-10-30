using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour 
{

	protected bool playerInRange;
	protected GameObject interactionDisplay;
	protected Animator animator;
	protected new ParticleSystem particleSystem;

	private bool isInteractable;
	
	protected virtual IEnumerator Start () 
	{
		if(this.GetComponent<Collider2D>() == null)
			Debug.Log(this.name + " does not have the required collider.");
		yield return new WaitUntil(()=>PlayerEventEmitter.instance != null);
		PlayerEventEmitter.instance.interact.AddListener(AttemptInteract);
		isInteractable = true;
		animator = GetComponent<Animator>();
		particleSystem = GetComponent<ParticleSystem>();
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
		HideAnimationDisplay();
	}

	public abstract void Interact(GameObject user);

	public virtual void AnimationDisplay()
	{
		particleSystem.Play();
	}
	public virtual void HideAnimationDisplay()
	{
		particleSystem.Stop();
	}


	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player" && isInteractable)
		{
			playerInRange = true;
			AnimationDisplay();
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player" && isInteractable)
		{
			playerInRange = false;
			HideAnimationDisplay();
		}
	}
}
