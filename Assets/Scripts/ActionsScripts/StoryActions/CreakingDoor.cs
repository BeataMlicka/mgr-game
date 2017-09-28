using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreakingDoor : ActionsAbstract {

	public GameObject door;
	private Doors doorsScript;

	void Start(){
		doorsScript = door.GetComponent<Doors> ();
	}

	void OnTriggerStay(Collider other){
		action ();
		Destroy (this);
	}


	public override void action(){
		doorsScript.creak();
		StoryGameManager.instance.setConditions (0, true);
	}
}
