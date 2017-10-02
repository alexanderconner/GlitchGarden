﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;
	private int stars = 100;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		starText = GetComponent<Text> ();
		UpdateDisplay ();
	}


	public void AddStars(int amount) {
		print (amount + "Stars added to display");
		stars += amount;
		print ("Total stars:" + stars);
		UpdateDisplay ();
	}

	public Status UseStars(int amount) {

		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	private void UpdateDisplay() {
		starText.text = stars.ToString ();
	}
}