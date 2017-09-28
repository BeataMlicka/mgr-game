using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;

public class StoryGameManager : MonoBehaviour {

	public static StoryGameManager instance;

	private DataManager dataManager;

	private float time;
	private int timeStep;

	//var
	private bool[] conditions;

	//extra conditions
	public bool handleIsTaken;
	public bool handleIsUsed;

	public bool chestIsMoved;

	public bool theBoxIsOpen;

	public bool keyIsTaken;
	public bool keyIsUsed;

	public bool paintingFallen;

	public bool spiderAttacked;

	public bool sideHallwayFirstTrigger;

	public bool diningRoomCheckpoint;

	public bool labolatoryAlarm;

	public bool flashlight;

	public bool laboratoryKey;

	public bool playerIsActive;


	public GameObject player;
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

		time = 0;
		timeStep = 0;
		conditions = new bool[10];

		//ustawienie wartości tabeli

		for(int i = 0; i < conditions.Length; i++){
			conditions [i] = false;
		}
			
		dataManager = gameObject.GetComponent<DataManager> ();

		handleIsTaken = false;
		handleIsUsed = false;
		chestIsMoved = false;
		theBoxIsOpen = false;

		paintingFallen = false;

		keyIsTaken = false;
		keyIsUsed = false;

		spiderAttacked = false;

		sideHallwayFirstTrigger = false;

		diningRoomCheckpoint = false;
		labolatoryAlarm = false;

		flashlight = false;
		laboratoryKey = false;

		playerIsActive = true;
	}


	//--------------------------------------------------------------------------------------------------------//

	// Update is called once per frame
	void Update () {

		for(int i = 0; i < conditions.Length; i++){

			if(conditions[i]){

					WriteCatchingData (i, Convert.ToString(dataManager.getPulse()), Convert.ToString(dataManager.getGSR()), GameManager.instance.fullGameTime);

				conditions [i] = false;
			}
		}

		if(!playerIsActive){

			player.SetActive (false);
		}
	}

	//--------------------------------------------------------------------------------------------------------//
	public void setConditions(int i, bool value){
		conditions [i] = value;
	}

	//--------------------------------------------------------------------------------------------------------//

	[MenuItem("Write file")]

	static void WriteCatchingData(int i, string pulse, string gsr, float time){

		//Debug.Log ("Dane fabularne zapisane do pliku.");
		string path = "Assets/Output/catchingData.txt";

		string catchingTime = Convert.ToString(time);
		string measure = Convert.ToString (i);

		StreamWriter writer = new StreamWriter(path, true);

		writer.WriteLine ("akcja: " + measure + " - " + "time: " + catchingTime);
		writer.WriteLine ("pulse: " + pulse + " --- " + "gsr: " + gsr);
		writer.WriteLine ("");

		writer.Close ();
	}
}
