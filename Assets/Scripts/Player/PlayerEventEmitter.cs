using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventEmitter : Singleton<PlayerEventEmitter>{

	[HideInInspector]public UnityEvent interact;
	[HideInInspector]public UnityEvent onDamage;
	[HideInInspector]public UnityEvent onHeal;
	public UnityEvent onHealthChange;
	//public UnityEvent 

	void Start () 
	{	
		base.EnforceSingleton();
		interact = new UnityEvent();
		onDamage = new UnityEvent();
		onHeal = new UnityEvent();
		onHealthChange = new UnityEvent();
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.E))
			interact.Invoke();
	}
}
