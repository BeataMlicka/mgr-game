using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleRoom : Room {

	public GameObject sound_1;
	public GameObject sound_2;
	public GameObject sound_3;
	public GameObject sound_4;
	public GameObject sound_5;
	public GameObject sound_6;


	public Queue<GameObject> actionsQueue;

	public bool actionFlag;

	//---------------------------------------------------------------------------------------------------------------------
	void Start(){

		actionsQueue = new Queue<GameObject>();
		actionsQueue.Enqueue (sound_1);
		actionsQueue.Enqueue (sound_2);
		actionsQueue.Enqueue (sound_3);
		actionsQueue.Enqueue (sound_4);
		actionsQueue.Enqueue (sound_5);
		actionsQueue.Enqueue (sound_6);

		register = 0;
		timeOfVisit = 0;
		actionFlag = true;
	}
		
	//--------------------------------------------------------------------------------------------------------------------

	public override void action (){
		actionsQueue.Peek ().GetComponent<MakeStrangeSound>().action();
		Debug.Log ("Akcja w = " + this.gameObject);
		actionFlag = false;
		actionsQueue.Dequeue ();
	}

	//---------------------------------------------------------------------------------------------------------------------

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){

			GameManager.instance.currentLocation = this.gameObject;
			register++;
			Debug.Log ("Wchodzisz do: " + this.gameObject + "n-ty raz -> " + register);
		}
	}

	void OnTriggerStay(Collider other){

		if (other.gameObject.tag == "Player") {
			GameManager.instance.currentLocation = this.gameObject;
			timeOfVisit += Time.deltaTime;
		}
	}

	void OnTriggerExit(){
		Debug.Log ("Time of visit in " + this.gameObject + " --- " + timeOfVisit);
		timeOfVisit = 0;
		actionFlag = true;
	}

}
