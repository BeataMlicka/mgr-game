using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabolatoryAlarm : ActionsAbstract {

	public Light firstLight;
	public Light secondLight;

	public AudioSource audioSource;

	private float time;
	private bool playerIsInside;

	public GameObject exidDoorKey;

	// Use this for initialization
	void Start () {

		firstLight.enabled = false;
		secondLight.enabled = false;

		playerIsInside = false;
		audioSource.enabled = false;
		time = 0;

		exidDoorKey.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if (playerIsInside) {

			if (time < 15) {
			
				audioSource.enabled = true;
				firstLight.enabled = true;
				secondLight.enabled = true;

				if (firstLight.intensity > 0 && firstLight.intensity < 10) {
					firstLight.intensity -= Time.deltaTime * 0.00f;
				} else{
					firstLight.intensity += Time.deltaTime * 0.00f;
				}


				if (secondLight.intensity > 0 && secondLight.intensity < 10) {
					secondLight.intensity -= Time.deltaTime;
				} else {
					secondLight.intensity += Time.deltaTime;
				}

			} else {
				audioSource.enabled = false;
				firstLight.enabled = false;
				secondLight.enabled = false;
				action ();
				Destroy (this);
			}

			time += Time.deltaTime;
		}
	}


	public override void action(){
		StoryGameManager.instance.setConditions (8, true);
	}


	void OnTriggerEnter(){
		playerIsInside = true;
		exidDoorKey.SetActive (true);
		Debug.Log ("Wyjściowe drzwi aktywne");
		StoryGameManager.instance.labolatoryAlarm = true;
	}
}
