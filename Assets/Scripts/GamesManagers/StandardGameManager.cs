using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardGameManager : MonoBehaviour {

	public GameObject currentLocation;
	public int register;
	public float timeOfVisit;


	void Start(){
	}

	void Update(){

		currentLocation = GameManager.instance.currentLocation;

		//Debug.Log ("Current location = " + currentLocation);
		register = currentLocation.GetComponent<SingleRoom>().register;
		timeOfVisit = currentLocation.GetComponent<SingleRoom> ().timeOfVisit;

		//Debug.Log ("REGISTER: " + register);
		//Debug.Log ("REGISTER: " + timeOfVisit);
		if(GameManager.instance.currentGameVersion == "StandardGame"){
			if((register >= 2) && (timeOfVisit > 15) && currentLocation.GetComponent<SingleRoom>().actionFlag){
				currentLocation.GetComponent<SingleRoom> ().action();
			}
		}
	}
}
