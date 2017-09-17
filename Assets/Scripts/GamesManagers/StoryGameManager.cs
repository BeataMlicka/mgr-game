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
	private int step;

	//var
	private bool[] conditions;
	public GameObject[] storyActions;

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
		step = 0;
		conditions = new bool[5];

		for(int i = 0; i < conditions.Length; i++){

			conditions [i] = false;
		}

		dataManager = gameObject.GetComponent<DataManager> ();
	}


	//--------------------------------------------------------------------------------------------------------//

	// Update is called once per frame
	void Update () {


		for(int i = 0; i < conditions.Length; i++){

			if(conditions[i]){

				if (time < 1) {
					time += Time.deltaTime;
				} else {

					WriteCatchingData (i, Convert.ToString(dataManager.getPulse()), Convert.ToString(dataManager.getGSR()), GameManager.instance.fullGameTime);

					step++;
					time = 0;

					if(step == 5){
						conditions [i] = false;
					}
				}
			}
		}

		//sprawdzenie czasu
		/*if (time < 1) {
			time += Time.deltaTime;
		} else {
			//przejście po tablicy
			for(int i = 0; i<conditions.Length; i++){
				
			}

			time = 0; 	
		}*/
	}
		
	//--------------------------------------------------------------------------------------------------------//
	public void setConditions(int i, bool value){
		this.conditions [i] = value;
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
