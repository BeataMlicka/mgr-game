using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : ItemAbstract {


	public Texture2D flashlightIcon;
	public GameObject handle;

	// Use this for initialization
	void Start(){
		objectIsSelected = false;
		handle.SetActive (false);
	}


	// Update is called once per frame
	void Update () {
		if (objectIsSelected && Input.GetMouseButtonDown (0)) {
			setIcon (flashlightIcon);
			InventoryScript.instance.addItem (this);
			handle.SetActive (true);
			InventoryScript.instance.flashlightIsInside = true;
			Destroy (gameObject);
		}
	}

	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		this.objectIsSelected = true;
		Debug.Log ("Jestem na latarce :D ;]");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		this.objectIsSelected = false;
	}

	public override void action(){

		FlashlightLight.instance.setIsActive (true);
		//Debug.Log ("Flashlight action!");
	}

}
