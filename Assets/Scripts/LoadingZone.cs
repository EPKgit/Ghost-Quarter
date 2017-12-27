using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingZone : MonoBehaviour {

	public string sceneName;

	void Start () 
	{
		if(this.GetComponent<Collider2D>() == null)
			Debug.Log(this.name + " does not have the required collider.");
	}
	
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player")
			SceneManager.LoadSceneAsync(sceneName);
	}
}