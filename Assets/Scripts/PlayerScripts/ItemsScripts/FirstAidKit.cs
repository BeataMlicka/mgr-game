using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : ItemAbstract {

	public Texture2D firstAidKitIcon;
	private bool objectIsSelected;

	void Start(){
		objectIsSelected = false;
		itemCounter = 0;
		itemName = "FirstAidKit";
	}
	/*

	private bool testFlag;*/

	// Update is called once per frame
	void Update () {

		if(objectIsSelected && Input.GetMouseButtonDown(0)){
			setIcon (firstAidKitIcon);
			InventoryScript.instance.addItem (this);
		}
	}

	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		this.objectIsSelected = true;
		Debug.Log ("Jestem na klocku ;]");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		this.objectIsSelected = false;
	}

}
