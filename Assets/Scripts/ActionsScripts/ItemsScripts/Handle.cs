using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : ItemAbstract {

	public Texture2D handleIcon;
	public Texture2D handleMiniature;

	public GameObject handle;

	private bool takeHandleFromInventory;
	public bool isInInventory;

	void Start(){
		objectIsSelected = false;
		itemCounter = 0;
		itemName = "Handle";
		takeHandleFromInventory = false;

		isInInventory = true;
	}


	// Update is called once per frame
	void Update () {

		if(objectIsSelected && Input.GetMouseButtonDown(0)){
			setIcon (handleIcon);
			InventoryScript.instance.addItem (this);
			Destroy (handle);
		}
	}

	void OnGUI(){

		if (takeHandleFromInventory) {
			GUI.DrawTexture (new Rect(Screen.width/2 - 50, Screen.height/2 - 50, 100, 100), handleMiniature);
			isInInventory = false;
		}

		if (Input.GetMouseButtonDown (2)) {
			setIcon (handleIcon);
			takeHandleFromInventory = false;
			InventoryScript.instance.addItem (this);
			isInInventory = true;
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


	//--------------------------------------------------------------------------------------------------------//

	public override void action(){
		this.takeHandleFromInventory = true;
	}
}
