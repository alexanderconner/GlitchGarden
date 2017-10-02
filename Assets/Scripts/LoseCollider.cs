using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	LevelManager levelManager;

	void Start() 
	{
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D()
	{
		print ("You lose");
		levelManager.LoadLevel ("03b Lose");
	}
}
