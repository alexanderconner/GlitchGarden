using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider, difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		Debug.Log ("Music Manager: ");
		Debug.Log (musicManager);
		//Set Slider value so it matches the current saved volume
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty ();
	}

	// Update is called once per frame
	void Update () {
		musicManager.ChangeVolume (volumeSlider.value);
	}

	public void SaveAndExit() {
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (difficultySlider.value);
		levelManager.LoadLevel ("01 Start");
	}

	public void setDefaults() {

		volumeSlider.value = 0.75f;
		difficultySlider.value = 2f;
	}
}
