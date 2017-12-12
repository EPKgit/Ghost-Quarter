using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour 
{

	public GameObject light;
	public Vector3 offset;

	void LateUpdate () 
	{
		Vector3 playerpos = this.gameObject.transform.position;
		light.transform.position = playerpos + offset;
	}
}
