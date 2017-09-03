using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour {

	public AudioSource lightRain;
	public AudioSource storm;

	// Use this for initialization
	void Start () {

		lightRain.enabled = true;
		storm.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("GTC: " + CameraController.instance.gameTimeCounter);

		if (CameraController.instance.gameTimeCounter > 20) {

			Debug.Log ("GC: " + CameraController.instance.gameTimeCounter);
			lightRain.enabled = false;
			storm.enabled = true;
		} else {
		
			lightRain.enabled = true;
			storm.enabled = false;
		}
		
	}
}
