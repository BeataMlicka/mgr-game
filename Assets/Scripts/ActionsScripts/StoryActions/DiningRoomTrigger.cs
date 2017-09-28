using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiningRoomTrigger : MonoBehaviour {

	public Light firstLamp;
	//public Light secondLamp;
	public GameObject doorLocking;

	public AudioSource audioSource;

	private float time;
	private bool playerIsInside;


	// Use this for initialization
	void Start () {
		playerIsInside = false;
		audioSource.enabled = false;
		time = 0;
		doorLocking.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		if(StoryGameManager.instance.sideHallwayFirstTrigger){
			
			time += Time.deltaTime;

			if(time > 20){
				firstLamp.GetComponent<Lamps> ().isOn = true;
			}

			if(playerIsInside){
				firstLamp.enabled = false;
				StoryGameManager.instance.diningRoomCheckpoint = true;
				doorLocking.SetActive (true);
				//Debug.Log (StoryGameManager.instance.diningRoomCheckpoint);
				Destroy (this);
			}
		}
	}


	void OnTriggerEnter(){
		this.playerIsInside = true;
	}
}
