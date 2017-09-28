using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorbell : ActionsAbstract {


	public AudioSource audioSource;
	private float time;

	void Start(){
		audioSource.enabled = false;
		time = 0;
	}


	void Update(){

		if(StoryGameManager.instance.keyIsTaken){
			time += Time.deltaTime;

			if(time > 5){
				action ();
				Destroy (this);
			}
	
		}
	}


	public override void action(){
		audioSource.enabled = true;
		StoryGameManager.instance.setConditions (4, true);
	}
}
