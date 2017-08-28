using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	//menu objects
	public GameObject mainMenuHolder;
	public GameObject controlMenuHolder;
	public GameObject optionsMenuHolder;
	public GameObject introHolder;

	public Slider volumeSilder;

	public Toggle standardGameToggle;
	public Toggle affectiveGameToggle;

	//current game version
	public string currentGameVersion; 


	//--------------------------------------------------------------------------------------------------------//
	void Start(){
		
	}

	//--------------------------------------------------------------------------------------------------------//
	void Update(){
		ActiveToggle ();
	}

	//--------------------------------------------------------------------------------------------------------//

	//menu functions

	public void Play(){
		SceneManager.LoadScene ("Intro");
	}

	public void Quit(){
		Application.Quit ();
	}

	public void MainMenu(){

		controlMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		introHolder.SetActive (false);
		mainMenuHolder.SetActive (true);
	}

	public void ControlMenu(){


		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		introHolder.SetActive (false);
		controlMenuHolder.SetActive (true);
	}

	public void OptionsMenu(){
		mainMenuHolder.SetActive (false);
		controlMenuHolder.SetActive (false);
		introHolder.SetActive (false);
		optionsMenuHolder.SetActive (true);
	}

	void ActiveToggle(){

		if (standardGameToggle.isOn) {
			//Debug.Log ("STANDARD TOGGLE ACTIVE");
			currentGameVersion = "StandardGame";
			GameManager.instance.setCurrentGameVersion(currentGameVersion);
			//Debug.Log ("A: " + GameManager.instance.getCurrentGameVersion());
		} else if (affectiveGameToggle.isOn) {
			//Debug.Log ("AFFECTIVE TOGGLE ACTIVE");
			currentGameVersion = "AffectiveGame";
			GameManager.instance.setCurrentGameVersion(currentGameVersion);
			//Debug.Log ("B: " + GameManager.instance.getCurrentGameVersion());
		}
	}
		
	public void SetSoundsVolume(float value){

	}
		
}
