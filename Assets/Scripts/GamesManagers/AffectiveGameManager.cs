using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectiveGameManager : MonoBehaviour {

	public GameObject currentLocation;

	void Start(){
	}

	void Update(){

		currentLocation = GameManager.instance.currentLocation;

		//Debug.Log ("Current location = " + currentLocation);

		//Debug.Log ("REGISTER: " + register);
		//Debug.Log ("REGISTER: " + timeOfVisit);

		if(GameManager.instance.currentGameVersion == "AffectiveGame"){
			if(GameManager.instance.actionFlag){
				currentLocation.GetComponent<SingleRoom> ().action();
				GameManager.instance.actionFlag = false;
			}
		}

	}
}
