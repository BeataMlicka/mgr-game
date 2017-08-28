using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerLocation : MonoBehaviour {

	public GameObject firstLevelContainer;
	private GameObject currenLocation; 
	private FirstLevelManager gameManagerScript;


	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){

			currenLocation = this.gameObject; 

			gameManagerScript = firstLevelContainer.GetComponent<FirstLevelManager>();
			gameManagerScript.checkLocation (currenLocation);

			Debug.Log ("CheckPlayerLocation.sc" + " " + currenLocation);

			//teoria sprawdzająca skrypty i lokacje
			if(currenLocation.tag == "MainHall"){
				Debug.Log ("Moja teoria dziala!!! HAHAHAHAHA");
			}

		}
	}

	void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "Player") {


		}
	}
}
