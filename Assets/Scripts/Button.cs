using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	private Button[] buttonArray;
	private Text costText;
	public static GameObject selectedGameObject;
	public GameObject gameObjectPrefab;


	void Start()
	{
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		GetComponent<SpriteRenderer> ().color = Color.black;

		costText = GetComponentInChildren<Text> ();
		if (!costText) {
			Debug.LogWarning (name + " has no text cost component");
		}

		//TODO change name of gameobjectPrefab to more desc. name
		costText.text = gameObjectPrefab.GetComponent<Defenders> ().starCost.ToString ();
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