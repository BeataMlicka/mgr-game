using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ax : ItemAbstract {

	public GameObject ax;
	private AxData axData;

	void Start(){
		axData = ax.GetComponent<AxData> ();
	}

	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		axData.objectIsSelected = true;
		Debug.Log ("Jestem na siekierze.");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		axData.objectIsSelected = false;
	}

	//-------------------------------------------------------------------------------------------------------//

	public override void action(){
	}
}
