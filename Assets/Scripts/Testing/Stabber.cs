using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabber : MonoBehaviour {

	public float damage;

	void OnTriggerEnter2D(Collider2D other) 
	{
		PlayerHealth ab = other.gameObject.GetComponent<PlayerHealth>();
		if(ab != null)
		{
			ab.Damage(damage);			
		}
	}
}
