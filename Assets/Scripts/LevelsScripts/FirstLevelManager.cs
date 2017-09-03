using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelManager : MonoBehaviour {

	//connecting scripts
	private GameManager gameManager;

	//time counting var
	private float counter = 0;
	private int time = 1;
	private int actionCounter = 3;

	//location objects
	public GameObject mainHall;
	public GameObject corridor;
	public GameObject office;
	public GameObject roomOffice;



	//--------------------------------------------------------------------------------------------------------//
	void Start(){

		gameManager = gameObject.GetComponent<GameManager>();
	}

	//--------------------------------------------------------------------------------------------------------//

	void Update() {

	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////
	/// COLLISION DETECTION FUNCTIONS
	//////////////////////////////////////////////////////////////////////////////////////////////////////
	private GameObject currentLocation;

	public void checkLocation(GameObject currentLocation){

		this.currentLocation = currentLocation;
		Debug.Log("GameManager.sc" + " " + currentLocation);
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////////
	/// ACTIONS MANAGEMENT FUNCTIONS 
	//////////////////////////////////////////////////////////////////////////////////////////////////////

	private MainHallActionsScript mainHallActionsScript;
	private LeftCorridorActionsScript leftCorridorAcrionsScript;
	private OfficeActionsScript officeActionsScript;
	private OfficeRoomActionsScript officeRoomAcrionsScript;

	public void checkSituation(){

		if (currentLocation.tag == "MainHall") {

			mainHallActionsScript = currentLocation.GetComponent<MainHallActionsScript> ();
			mainHallActionsScript.changeLight ();
			Debug.Log ("Sprawdzona lokacja: Main Hall");
		} else if (currentLocation.tag == "LeftCorridor") {

			leftCorridorAcrionsScript = currentLocation.GetComponent<LeftCorridorActionsScript> ();
			Debug.Log ("Sprawdzona lokacja: Left Corridor");
		} else if (currentLocation.tag == "Office") {

			officeActionsScript = currentLocation.GetComponent<OfficeActionsScript> ();
			Debug.Log ("Sprawdzona lokacja: Office");
		} else if (currentLocation.tag == "OfficeRoom") {

			officeRoomAcrionsScript = currentLocation.GetComponent<OfficeRoomActionsScript> ();
			Debug.Log ("Sprawdzona lokacja to: OfficeRoom");
		} else {
			Debug.Log ("Jesteś w NICOSCI!");
		}


	}
}
