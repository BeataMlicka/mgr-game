using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstThunder : ActionsAbstract {

	public GameObject flashlight;
	//public Flashlight flashlightScript;

	public AudioSource audioSource;
	public AudioClip thunderSound;

	private float time;

	// Use this for initialization
	void Start () { 

		time = 0;
	}

	
	// Update is called once per frame
	void Update () {

		if(InventoryScript.instance.flashlightIsInside){

			if (time < 5) {
				time += Time.deltaTime;
			} else {
				action ();
			}
		}
	}

	public override void action(){
		audioSource.PlayOneShot (thunderSound);
		setConditions (1, true);
	}
}
