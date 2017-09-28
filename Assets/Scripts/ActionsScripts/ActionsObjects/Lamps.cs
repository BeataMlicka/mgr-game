
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamps : MonoBehaviour {

	public Light light;
	public AudioSource audioSource;

	public bool isOn; //włączona
	public bool isBlinking; //mrugająca

	private float time;
	private float blinkingTime;

	void Start(){

		isOn = true;
		isBlinking = false;

		audioSource.enabled = false;
	}

	void Update(){

		if(LightManager.instance.isBlinking && LightManager.instance.isOn && 2 == 4){

			if (blinkingTime < 10) {
				if (time < 1) {
					light.intensity -= UnityEngine.Random.Range (2, 10);
					time += Time.deltaTime;
				} else {
					light.intensity += UnityEngine.Random.Range (2, 10);
					time = 0; 
				}	
				blinkingTime += Time.deltaTime;
			} else {
				blinkingTime = 0;
				isBlinking = false;
			}

		}


		if(!LightManager.instance.isOn){
			light.enabled = false;
		}
	}

}
