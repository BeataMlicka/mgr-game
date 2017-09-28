
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ItemAbstract {

	public GameObject key;
	private KeyData keyData;

	void Start(){
		keyData = key.GetComponent<KeyData> ();
	}

	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		keyData.objectIsSelected = true;
		Debug.Log ("Jestem na Kluczu.");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		keyData.objectIsSelected = false;
	}

	//-------------------------------------------------------------------------------------------------------//

	public override void action(){
	}
}
