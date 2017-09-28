using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//

public class Pulse : SensorAbstract {


	void Start(){

		inputData = new List<float>();
		averages = new List<float>();
	}


	/// --------------------------------------------------------------------------------------------------------------------------------
	//metoda dodająca odczyt do listy

	public override void addInput(float newInput){

		inputData.Add (newInput); //jest ok
		this.register++; //jest ok
	}

	/// --------------------------------------------------------------------------------------------------------------------------------
	//metoda obliczająca średnią, z pomiarów pobranych od momentu obliczenia ostatniej średniej
	public override float calculateAverage(){
		
		float sum = 0;
		float currentAverage = 0;

		//Debug.Log ("reg - " + register); //63
		//Debug.Log ("Table size = " + this.inputData.Count); //63

		int size = this.inputData.Count - 1;

		for (int i = size; i > size - register; i--){ 
			
			sum += this.inputData [i];
		}

		currentAverage = sum / register;
		average = currentAverage;
		//Debug.Log ("Average: " + average);
		this.averages.Add(currentAverage);

		Debug.Log ("P aver = " + currentAverage);

		return currentAverage;

		register = 0;
	}


	/// --------------------------------------------------------------------------------------------------------------------------------
	//method porównująca ostanie średnie
	public override bool compareAverage(){

		int size = this.averages.Count;

		Debug.Log ("P: 1 - " + this.averages[size-1] + " --- " + this.averages[size-2] + " --- " + this.averages[size-3]);


		if ((this.averages [size - 1] < this.averages [size - 2]) && (this.averages [size - 2] < this.averages [size - 3])) {
			
			Debug.Log ("lower");
			return true;

		} else {
			Debug.Log ("higher or equal");
			return false;
		}

	}

	/// --------------------------------------------------------------------------------------------------------------------------------

}
