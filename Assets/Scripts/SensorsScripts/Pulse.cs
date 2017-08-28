using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//

public class Pulse : MonoBehaviour {


	private List<int> pulseValues;
	private int averageTimeCounter = 10;
	private int timeStep = 10;
	private float comparativeAverage;
	private List<string> results;
	public int resultsCounter = 0;

	void Start(){

		pulseValues = new List<int> ();
		results = new List<string>();
	}

	//getters and setters
	public void setAverageTimeCounter(int timeStep){
		this.averageTimeCounter += timeStep;
	}

	public void setComparativeAverages(float average){
		this.comparativeAverage = average;
	}

	public float getComparativeAverage(){
		return this.comparativeAverage;
	}

	public int getResultsTableSize(){
		return results.Count;
	}

	//method adding new input to list
	public void addInput(int pulseInput){

		pulseValues.Add (pulseInput);

		if(pulseValues.Count >= averageTimeCounter){
			//wywołaj metodę liczącą średnią
			average();
			setAverageTimeCounter(timeStep);
		}
	}

	//method calculating average 
	public void average(){

		float sum = 0;
		float currentAverage = 0;
		float lastAverage = 0;

		for (int i = this.pulseValues.Count; i > this.pulseValues.Count - timeStep; i--){ 
			Debug.Log("Jestem tutaj :)");
			sum += this.pulseValues [i-1];
			Debug.Log ("suma: " + sum);
		}

		currentAverage = sum / 10;
		//Debug.Log ("Average: " + average);

		//metoda porównująca średnią
		compareAverages(currentAverage);
		setComparativeAverages(currentAverage);
	}

	//method comareing averages
	public void compareAverages(float currentAverage){

		if (currentAverage > getComparativeAverage ()) {
			this.results.Add("higher");
			resultsCounter++;
			Debug.Log ("higher");

		} else if (currentAverage < getComparativeAverage ()) {
			this.results.Add("lower");
			resultsCounter++;
			Debug.Log ("lower");

		} else {
			this.results.Add("equal");
			resultsCounter++;
			Debug.Log ("equal");
	
		}
	}

	//method checking results
	public string checkingResults(){

		if (this.results [this.results.Count - 3] == "lower" && 
			this.results [this.results.Count - 2] == "lower" && this.results [this.results.Count - 1] == "lower") {
			return "action";
		} else if (this.results [this.results.Count - 3] == "higher" && 
			this.results [this.results.Count - 2] == "higher" && this.results [this.results.Count - 1] == "higher") {
			return "wait";
		} else {
			return "wait";
		}
	}

}
