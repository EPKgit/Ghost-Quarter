using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour 
{

	public GameObject toControl;
	public Vector3 offset;

	void LateUpdate () 
	{
		Vector3 playerpos = this.gameObject.transform.position;
		if(toControl != null)
			toControl.transform.position = playerpos + offset;
	}
}
