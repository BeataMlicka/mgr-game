using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : ActionsAbstract {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(StoryGameManager.instance.theBoxIsOpen){
			action ();
			Destroy (this);
		}
	}

	public override void action(){
		StoryGameManager.instance.setConditions (3, true);
	}
}
