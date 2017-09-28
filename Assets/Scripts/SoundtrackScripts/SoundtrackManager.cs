using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour {

/*
	public static SoundtrackManager instance;

	public AudioSource lightRain;
	public AudioSource storm;
	public AudioSource firstBackground;
	public AudioSource ghostBackground;

	private bool isOn;
	private bool firstBackgroundMusic;
	private bool ghostBackgroundMusic;

	//--------------------------------------------------------------------------------------------------------//

	void Awake(){

		if (instance == null) {

			DontDestroyOnLoad (gameObject);
			instance = this;

		} else if(instance != this) {
			Destroy (gameObject);
		}

	}

	//--------------------------------------------------------------------------------------------------------//


	// Use this for initialization
	void Start () {

		isOn = true;
		firstBackgroundMusic = false;
		ghostBackgroundMusic = false;

		lightRain.enabled = true;
		storm.enabled = false;
		firstBackground.enabled = false;
		ghostBackground.enabled = false;
	}

	//--------------------------------------------------------------------------------------------------------//

	
	// Update is called once per frame
	void Update () {

		//Debug.Log ("GTC: " + CameraController.instance.gameTimeCounter);

		if(isOn){

			if (GameManager.instance.fullGameTime > 30) {

				//Debug.Log ("GC: " + CameraController.instance.gameTimeCounter);
				lightRain.enabled = false;
				storm.enabled = true;
			} else {

				lightRain.enabled = true;
				storm.enabled = false;
			}
		}
	}*/
}
