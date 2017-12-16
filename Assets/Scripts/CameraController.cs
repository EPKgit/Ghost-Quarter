using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{

	public GameObject toFollow;
	public Vector3 offset;

	void Start () 
	{
		if(toFollow == null)
			toFollow = PlayerMovement.instance.gameObject;
		
	}

	void LateUpdate () 
	{
		this.transform.position = toFollow.transform.position + offset;
	}
}
