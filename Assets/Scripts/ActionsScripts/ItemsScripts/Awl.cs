using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awl : ItemAbstract {

	public GameObject awl;
	private AwlData awlData;

	void Start(){
		awlData = awl.GetComponent<AwlData> ();
	}

	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		awlData.objectIsSelected = true;
		Debug.Log ("Jestem na klamce.");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		awlData.objectIsSelected = false;
	}

	//-------------------------------------------------------------------------------------------------------//

	public override void action(){
	}
}
