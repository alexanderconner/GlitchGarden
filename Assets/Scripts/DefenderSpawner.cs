using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	GameObject defenderParent;
	private StarDisplay stardisplay;

	// Use this for initialization
	void Start () {
		stardisplay = GameObject.FindObjectOfType<StarDisplay> ();
		defenderParent = GameObject.Find ("Defenders");

		if (defenderParent == null)
		{
			defenderParent = new GameObject("Defenders");
		}
	}

	void OnMouseDown() {
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPos = SnapToGrid(rawPos);
		//Find selected guy
		GameObject defender = Button.selectedGameObject;
		int defenderCost = defender.GetComponent<Defenders> ().starCost;
		//Check stars and Create the bugger under parent gameobject Defenders
		if (stardisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			GameObject newDefender = Instantiate (defender, roundedPos, Quaternion.identity);
			newDefender.transform.parent = defenderParent.transform;
		} else {
			Debug.Log ("Insufficient stars to spawn");
		}
	}

	Vector2 CalculateWorldPointOfMouseClick()
	{

		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		//WTF
		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}


	Vector2 SnapToGrid(Vector2 rawWorldPos)
	{
		float gridX = rawWorldPos.x;
		float gridY = rawWorldPos.y;

		return new Vector2 (Mathf.RoundToInt(gridX), Mathf.RoundToInt(gridY));
	}
}
