using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHealth : MonoBehaviour {

	public float maxHealth;
	protected float currentHealth;
	public float health
	{
		get { return currentHealth; }
		set
		{
			currentHealth = value;
			if(currentHealth <= 0)
				Die();
			if(currentHealth > maxHealth)
				currentHealth = maxHealth;
		}
	}

	protected virtual IEnumerator Start()
	{
		yield return null;
		health = maxHealth;
	}

	protected abstract void Die();

	public virtual void Damage(float amount)
	{
		health -= amount;
	}

	public virtual void Heal(float amount)
	{
		health += amount;
	}
	
}
