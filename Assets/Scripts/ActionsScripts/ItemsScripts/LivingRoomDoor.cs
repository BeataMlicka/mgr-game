using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomDoor : ItemAbstract {

	public GameObject key;
	public GameObject doorTrigger;

	public bool handleIsActive;
	private bool isUnlock;

	void Start(){
		objectIsSelected = false;
		doorTrigger.SetActive (false);

		handleIsActive = false;
		isUnlock = false;
	}

	// Update is called once per frame
	void Update () {

		if(!isUnlock){
			if (objectIsSelected && Input.GetMouseButtonDown (0) && key.GetComponent<KeyData>().takeHandleFromInventory) {
				
				isUnlock = true;
				StoryGameManager.instance.handleIsUsed = true;
				doorTrigger.SetActive (true);
				this.gameObject.SetActive (false);
				Destroy (key);
			}
		}
	}


	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		this.objectIsSelected = true;
		Debug.Log ("Jestem na drzwiach :D ;]");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		this.objectIsSelected = false;
	}

	//--------------------------------------------------------------------------------------------------------//

	public override void action(){
		Debug.Log ("Drawer Action!");
	}
}
