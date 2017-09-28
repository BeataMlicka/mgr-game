using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : ItemAbstract {


	public GameObject handle;
	private HandleData handleData;

	void Start(){
		handleData = handle.GetComponent<HandleData> ();
	}

	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		handleData.objectIsSelected = true;
		Debug.Log ("Jestem na klamce.");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		handleData.objectIsSelected = false;
	}

	//-------------------------------------------------------------------------------------------------------//

	public override void action(){
	}
}
