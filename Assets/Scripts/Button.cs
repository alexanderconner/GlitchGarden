using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	private Color currentColor = Color.black;

	private Button[] buttonArray;
	public static GameObject selectedGameObject;
	public GameObject gameObjectPrefab;

	void Start()
	{
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		GetComponent<SpriteRenderer> ().color = Color.black;
	}

	void OnMouseDown () {


		foreach (Button thisButton in buttonArray)
		{
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}

		GetComponent<SpriteRenderer>().color = Color.white;

		//Since we have only a single static selectedGameObject, we can easily call that object to see what has been selected. 
		selectedGameObject = gameObjectPrefab;

	}
}