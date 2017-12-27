using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour {

	public static PlayerInteraction instance;
	/*[HideInInspector]*/public UnityEvent interact;

	void Start () 
	{	if(instance != null)
			Destroy(this.gameObject);
		instance = this;
		interact = new UnityEvent();
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E))
			interact.Invoke();
	}
}
