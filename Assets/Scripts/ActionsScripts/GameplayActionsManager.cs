using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayActionsManager : MonoBehaviour {

	public static GameplayActionsManager instance;
	public bool fallingPainting;

	private bool[] actionStatus;

	public bool singingGirl;
	public bool girlsSteps;
	public bool openCupboard;

	//------------------------------------------------------------------------------------------------------------------------------------/

	void Awake(){

		if (instance == null) {

			DontDestroyOnLoad (gameObject);
			instance = this;

		} else if(instance != this) {
			Destroy (gameObject);
		}
	}

	//------------------------------------------------------------------------------------------------------------------------------------/

	// Use this for initialization
	void Start () {
		actionStatus = new bool[1];


		for(int i = 0; i < actionStatus.Length; i++){
			actionStatus [i] = true;
		}

		fallingPainting = false;
		singingGirl = false;
		girlsSteps = false;
		openCupboard = false;
	}

	//------------------------------------------------------------------------------------------------------------------------------------/
	
	// Update is called once per frame
	void Update () {

		if(CameraController.instance.gameTimeCounter > 60 && (actionStatus[0] == true) ){//&& (LevelManager.instance.currentLocation.tag = "office")){ // && (LevelManager.instance.currentLocation.tag == "office")){
			fisrtGameplayAction ();
			actionStatus [0] = false;
		}
	}


	public void waitFunction(double waitTime){

		for (double time = waitTime; waitTime > 0;) {
			//Debug.Log ("");
			waitTime -= Time.deltaTime;
		}
	}

	//------------------------------------------------------------------------------------------------------------------------------------/
	//-------------------------------------------------- FIRST GAMEPLAY ACTION -----------------------------------------------------------/
	//------------------------------------------------------------------------------------------------------------------------------------/

	public void fisrtGameplayAction(){

		fallingPainting = true;
		waitFunction (3);
		openCupboard = true;
		waitFunction (3);
		girlsSteps = true;
		waitFunction (4);
		singingGirl = true;
	}
}
