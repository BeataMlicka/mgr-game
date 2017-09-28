using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLocking : ActionsAbstract {

	public GameObject door;
	public AudioSource audioSource;
	public AudioSource ghost;

	public GameObject labolatoryDoor;

	private bool playerIsInside;
	private float time;

	private bool action1;
	private bool action2;

	void Start(){
		playerIsInside = false;
		audioSource.enabled = false;
		action1 = true;
		action2 = true;
	}


	void Update(){

		if(StoryGameManager.instance.laboratoryKey && playerIsInside){
			time += Time.deltaTime;

			if(action1){
				door.GetComponent<Doors> ().slam ();
				ghost.enabled = false;
				door.SetActive (false);
				audioSource.enabled = true;
				action1 = false;
			}

			if(time > 15 && action2){
				audioSource.enabled = true;
				ghost.enabled = true;
				door.SetActive (true);
				action2 = false;

			}

			if(time > 30){
				labolatoryDoor.GetComponent<Doors> ().creak ();
				action ();
				Destroy (this);
			}
		}
	}


	public override void action(){
		StoryGameManager.instance.setConditions (7, true);
	}


	void OnTriggerEnter(){
		this.playerIsInside = true;
		Debug.Log ("trigger");
	}
}
