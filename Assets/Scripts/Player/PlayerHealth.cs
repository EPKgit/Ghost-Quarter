using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : AbstractHealth
{
	public static PlayerHealth instance;

	public void EnforceSingleton () 
	{
		if(instance != null)
			Destroy(this);
		instance = this;
	}

	new protected IEnumerator Start()
	{
		yield return StartCoroutine(base.Start());
		yield return new WaitUntil(()=>PlayerEventEmitter.instance != null);
		PlayerEventEmitter.instance.onHealthChange.AddListener(Print);
	}

	void Print()
	{
		Debug.Log(health);
	}
	protected override void Die()
	{
		
	}

	public override void Damage(float amount)
	{
		base.Damage(amount);
		PlayerEventEmitter.instance.onDamage.Invoke();
		PlayerEventEmitter.instance.onHealthChange.Invoke();
	}

	public override void Heal(float amount)
	{
		base.Damage(amount);
		PlayerEventEmitter.instance.onHeal.Invoke();
		PlayerEventEmitter.instance.onHealthChange.Invoke();
	}
}
