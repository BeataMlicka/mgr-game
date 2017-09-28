using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : ItemAbstract {
	
	public GameObject key;
	public GameObject doorTrigger;

	//private bool isUnlock;

	void Start(){
		objectIsSelected = false;
		doorTrigger.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

			if (objectIsSelected && Input.GetMouseButtonDown (0) && key.GetComponent<LaboratoryKeyData>().takeKeyFromInventory) {

				Debug.Log ("Klucz jest na drzwiach");
				StoryGameManager.instance.handleIsUsed = true;
				doorTrigger.SetActive (true);
				this.gameObject.SetActive (false);
				Destroy (key);
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
