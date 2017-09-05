using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalItemsCollision : MonoBehaviour {

	private GameObject chosenObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//--------------------------------------------------------------------------------------------------------//

	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		chosenObject = this.gameObject;
		Debug.Log ("ON MOUSE " + this.gameObject.tag);

		chosenObject.SendMessage ("action");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		Debug.Log ("EXIT MOUSE " + this.gameObject.tag);
	}
}
