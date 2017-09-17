using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;


public class DataManager : MonoBehaviour {
	

	//time variables
	private float time;
	private int step;

	//-------------------------------------------------------------

	//sensors objects
	private GalvanicSkinResponse gsr;
	private Pulse pulse;



	private float pulseInput;
	private float gsrInput;

	// Use this for initialization
	void Start () {

		//time
		time = 0;
		step = 0;

		gsr = gameObject.GetComponent<GalvanicSkinResponse>();
		pulse = gameObject.GetComponent<Pulse>();
	}
	
	//--------------------------------------------------------------------------------------------------------//

	void Update(){

		time += Time.deltaTime;

		if(time > 5 && GameManager.instance.getFullGameTime() > 30){

			pulse.calculateAverage ();
			gsr.calculateAverage ();

			time = 0;
			step++;

			if (step > 3) {
			
				checkActionCondition (pulse.compareAverage(), gsr.compareAverage());

				step = 0;
			}
		}
			
		//odmierzanie czasu od ostatniej akcji
		/*
		if (storyGameManager.getCatchData ()) {
			Debug.Log ("Pobrane dane wyrywkowe.");
			WriteData (Convert.ToString(pulseInput), Convert.ToString(gsrInput));
		}*/

	}


	//--------------------------------------------------------------------------------------------------------//
	public void saveData(float pulseInput, float gsrInput){

		this.pulseInput = pulseInput;
		this.gsrInput = gsrInput;

		//Debug.Log("Dane zostały zapisane: " + this.pulseInput + " " + this.gsrInput);

		WriteData (Convert.ToString(pulseInput), Convert.ToString(gsrInput));

		//sprawdzenie danych
		if((pulseInput > 60) && (pulseInput < 200)){

			pulse.addInput(pulseInput);
			//Debug.Log("P dodany");
		}

		if((gsrInput > 0 ) && (gsrInput < 45)){
			gsr.addInput(gsrInput);
			//Debug.Log("G dodany");
		}
	}

	//--------------------------------------------------------------------------------------------------------//
	public float getPulse(){
		return this.pulseInput;
	}

	public float getGSR(){
		return this.gsrInput;
	}

	//--------------------------------------------------------------------------------------------------------//
	private void checkActionCondition(bool firstCondition, bool secondCondition){

		if(firstCondition && secondCondition){
			GameManager.instance.actionFlag = true;
		}
	}

	//--------------------------------------------------------------------------------------------------------//

	[MenuItem("Write file")]

	static void WriteData(string pulse, string gsr) {

		//Debug.Log ("Dane zapisane do pliku.");

		string firstPath = "Assets/Output/pulseData.txt";
		string secondPath = "Assets/Output/gsrData.txt";


		//write data to test.txt file
		StreamWriter pulseWriter = new StreamWriter(firstPath, true);
		StreamWriter gsrWriter = new StreamWriter(secondPath, true);

		pulseWriter.WriteLine (pulse);
		gsrWriter.WriteLine (gsr);

		pulseWriter.Close ();
		gsrWriter.Close ();

	}



}
