using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryKey : ItemAbstract {

	public GameObject key;
	private LaboratoryKeyData keyData;

	void Start(){
		keyData = key.GetComponent<LaboratoryKeyData> ();
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
