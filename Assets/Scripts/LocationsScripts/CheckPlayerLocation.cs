using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerLocation : MonoBehaviour {

	//public GameObject firstLevelContainer;
	//private GameObject currenLocation; 
	//private FirstLevelManager gameManagerScript;


	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){

			LevelManager.instance.currentLocation = this.gameObject;
		}
	}

	void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "Player") {


		}
	}
}
