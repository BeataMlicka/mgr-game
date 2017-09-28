using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : ItemAbstract {
	
	public Texture2D batteryIcon;

	private int addEnergy = 10;

	void Start(){
		objectIsSelected = false;
		itemCounter = 0;
		itemName = "Battery";
	}
	/*

	private bool testFlag;*/

	// Update is called once per frame
	void Update () {

		if(objectIsSelected && Input.GetMouseButtonDown(0)){
			setIcon (batteryIcon);
			InventoryScript.instance.addItem (this);
			itemCounter++;
			Destroy (gameObject);
		}
	}

	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		this.objectIsSelected = true;
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		this.objectIsSelected = false;
	}


	//--------------------------------------------------------------------------------------------------------//
	public void setItemCounter(int value){
		this.itemCounter = value;
	}


	//--------------------------------------------------------------------------------------------------------//

	public override void action(){
		//Debug.Log ("JESTEM W BATERII");
		FlashlightLight.instance.setBatteryLoadingLevel (20);
		itemCounter--;
	}
}
