using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
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
=======
public class CameraController : MonoBehaviour {

	public Vector3 offset;
	public GameObject toFollow;

	void FixedUpdate () 
>>>>>>> origin/master
	{
		this.transform.position = toFollow.transform.position + offset;
	}
}
