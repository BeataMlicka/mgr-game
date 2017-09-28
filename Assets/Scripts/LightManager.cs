using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

	public static LightManager instance;

	public bool isBlinking;
	public bool isOn;

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

		isBlinking = false;
		isOn = true;
	}


	public void setIsBlinking(bool value){
		this.isBlinking = value;
	}


	public void setLampsState(bool value){
		this.isOn = value;
	}
}
