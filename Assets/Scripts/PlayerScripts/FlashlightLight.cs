using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightLight : MonoBehaviour {

	public static FlashlightLight instance;

	public Light flashlight;

	public bool isActive;

	private int batteryActiveTime;
	private float counter;
	private int timeStep;

	private int batteryLoadingLevel;

	public Texture2D fullBatteryIcon;
	public Texture2D threeFourthBatteryIcon;
	public Texture2D halfBatteryIcon;
	public Texture2D quarterBatteryIcon;
	public Texture2D emptyBatteryIcon;

	private int textureSize;
	private int margin;

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
		flashlight = GetComponent<Light> ();
		isActive = false;
		flashlight.enabled = false;

		batteryActiveTime = 200; // 200 sec

		counter = 0;
		timeStep = 8;

		batteryLoadingLevel = 100;

		textureSize = (int)(Screen.height * 0.09);
		margin = (int)(Screen.height * 0.02);
	}


	//--------------------------------------------------------------------------------------------------------//

	// Update is called once per frame
	void Update () {

		if(isActive){
			
			StoryGameManager.instance.flashlight = true;
			flashlight.enabled = true;

			if (counter < timeStep) {
				counter += Time.deltaTime;

			} else { 

				if (batteryLoadingLevel > 0) {
					batteryLoadingLevel -= 13; 
				} else {
					flashlight.GetComponent<Light> ().intensity = 0;
				}

				Debug.Log ("Battery Loading Level: " + batteryLoadingLevel);
				counter = 0;
			}
		}

		if(batteryLoadingLevel > 0){
			flashlight.GetComponent<Light> ().intensity = 10;
			Monster.instance.attack = false;

		}

		if(batteryLoadingLevel <= 0){
			Monster.instance.attack = true;
		}
	}

	//--------------------------------------------------------------------------------------------------------//
	void OnGUI() {

		if (isActive) {
			if (batteryLoadingLevel > 75) {
				GUI.DrawTexture (new Rect (Screen.width - textureSize * 2 - margin, (margin + textureSize), textureSize * 2, textureSize), fullBatteryIcon);
			} else if (batteryLoadingLevel > 50) {
				GUI.DrawTexture (new Rect (Screen.width - textureSize * 2 - margin, (margin + textureSize), textureSize * 2, textureSize), threeFourthBatteryIcon);
			} else if (batteryLoadingLevel > 25) {
				GUI.DrawTexture (new Rect (Screen.width - textureSize * 2 - margin, (margin + textureSize), textureSize * 2, textureSize), halfBatteryIcon);
			} else if (batteryLoadingLevel > 0) {
				GUI.DrawTexture (new Rect (Screen.width - textureSize * 2 - margin, (margin + textureSize), textureSize * 2, textureSize), quarterBatteryIcon);
			} else {
				GUI.DrawTexture(new Rect(Screen.width - textureSize * 2 - margin, (margin + textureSize), textureSize*2, textureSize), emptyBatteryIcon);
			}
		}
	}

	//--------------------------------------------------------------------------------------------------------//
	public void setBatteryLoadingLevel(int value){
		this.batteryLoadingLevel = batteryLoadingLevel + value;
	}

	public int getBatteryLoadingLevel(){
		return this.batteryLoadingLevel;
	}
	//--------------------------------------------------------------------------------------------------------//
	public void setIsActive(bool value){
		this.isActive = value;
	}

}
