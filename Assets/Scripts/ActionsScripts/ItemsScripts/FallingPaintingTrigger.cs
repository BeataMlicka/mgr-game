using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPaintingTrigger : ItemAbstract {

	//
	public GameObject painting;
	private FallingPainting fallingPainting;


	void Start(){
		fallingPainting = painting.GetComponent<FallingPainting> ();
		objectIsSelected = false;
	}


	void Update(){

		if(objectIsSelected && Input.GetMouseButtonDown(0)){
			StoryGameManager.instance.paintingFallen = true;
			action ();
		}
	}


	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		objectIsSelected = true;
		Debug.Log ("Jestem na Kluczu.");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		objectIsSelected = false;
	}

	//-------------------------------------------------------------------------------------------------------//

	public override void action(){
		fallingPainting.fall = true;
		Destroy (this);
	}
}
