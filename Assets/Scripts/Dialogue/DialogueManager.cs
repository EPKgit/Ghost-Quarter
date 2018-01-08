using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : Singleton<DialogueManager>
 {
	public Text nameText;
	public Text dialogueText;
	public bool inDialogue;

	[SerializeField]private Queue<string> sentences;
	private Animator animator;

	void Start()
	{
		base.EnforceSingleton();
		PlayerEventEmitter.instance.interact.AddListener(AdvanceDialogue);
		sentences = new Queue<string>();	
		inDialogue = false;
		animator = GetComponent<Animator>();
	}

	public void StartDialogue(Dialogue d)
	{
		PlayerMovement.instance.removePlayerControl();
		inDialogue =  true;
		animator.SetBool("isOpen", true);
		sentences.Clear();
		foreach(string s in d.sentences)
			sentences.Enqueue(s);
		nameText.text = d.SpeakerName;
		AdvanceDialogue();
	}

	public void AdvanceDialogue()
	{
		if(!inDialogue)
			return;
		if(sentences.Count == 0)
		{
			Invoke("EndDialogue", 0.2f);
			return;
		}
		dialogueText.text = sentences.Dequeue();
			
	}

	void EndDialogue()
	{
		Debug.Log("end");
		dialogueText.text = "";
		animator.SetBool("isOpen", false);
		inDialogue = false;
		PlayerMovement.instance.returnPlayerControl();
	}

}
