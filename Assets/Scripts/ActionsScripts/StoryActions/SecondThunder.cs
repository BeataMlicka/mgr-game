using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondThunder : ActionsAbstract {
	
	public AudioSource secondThunder;
	public AudioSource backgroundMusic;

	private float time;

	// Use this for initialization
	void Start () { 
		time = 0;
		secondThunder.enabled = false;
		backgroundMusic.enabled = false;
	}


	// Update is called once per frame
	void Update () {

		if(StoryGameManager.instance.handleIsUsed){

			if (time < 15) {
				time += Time.deltaTime;
			} else {
				//LightManager.instance.setLampsState(false);
				action ();
			}

			if(time < 7){
				secondThunder.enabled = true;
			}
		}
	}

	public override void action(){
	
		backgroundMusic.enabled = true;
		StoryGameManager.instance.setConditions (2, true);
		Destroy (this);
	}
}
