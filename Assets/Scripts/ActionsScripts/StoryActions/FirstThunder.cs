using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstThunder : ActionsAbstract {

	public GameObject flashlight;
	//public Flashlight flashlightScript;

	public AudioSource firstThunder;
	public AudioSource storm;
	public AudioSource rain;

	private float time;

	// Use this for initialization
	void Start () { 

		time = 0;
		firstThunder.enabled = false;
		storm.enabled = false;
	}

	
	// Update is called once per frame
	void Update () {

		if(InventoryScript.instance.flashlightIsInside){

			if (time < 5) {
				time += Time.deltaTime;
			} else {
				LightManager.instance.setLampsState(false);
				action ();
			}
		}
	}

	public override void action(){

		rain.enabled = false;
		firstThunder.enabled = true;
		storm.enabled = true;
		StoryGameManager.instance.setConditions (1, true);
		Destroy (this);
	}
}
