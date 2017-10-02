using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;
	private float secondsLeft;
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndofLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		winLabel = GameObject.Find ("YouWin");
		if (!winLabel) {
			Debug.LogWarning ("No win label found");
		}
		winLabel.SetActive (false);
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		secondsLeft = levelSeconds;

	}
	
	// Update is called once per frame
	void Update () {
		slider.value = 1.0f - (Time.timeSinceLevelLoad / levelSeconds);

		//If time is up and if we havent already won, win
		if ((Time.timeSinceLevelLoad >= levelSeconds) && !isEndofLevel)
		{
			print("You won");
			winLabel.SetActive (true);
			audioSource.Play ();
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndofLevel = true;
		}
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel ();
	}
}
