using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Interactable 
{

	public string speaker;
	public Dialogue[] script;
	

	private DialogueManager dialogueManager;
	private int conversationNumber;

	protected override IEnumerator Start()
	{
		yield return StartCoroutine(base.Start());
		conversationNumber = 0;
		Dialogue d;
		for(int x = 0; x < script.Length; x++)
		{
			d = script[x];
			if(d.SpeakerName == "")
				d.SpeakerName = speaker;
		}
		yield return new WaitUntil(()=>DialogueManager.instance != null);
		dialogueManager = DialogueManager.instance;
	}

	
	public override void Interact(GameObject user)
	{
		if(user.tag == "Player" && !dialogueManager.inDialogue)
			StartDialogue();		
	}

	public void StartDialogue()
	{
		dialogueManager.StartDialogue(script[conversationNumber]);
		conversationNumber++;
		if(conversationNumber >= script.Length)
			removeInteractability();
	}
	
}
