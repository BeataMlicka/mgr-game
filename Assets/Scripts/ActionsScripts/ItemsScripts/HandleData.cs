using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleData : ItemAbstract {

	public Texture2D handleIcon;
	public Texture2D handleMiniature;
	public GameObject handle;

	public bool takeHandleFromInventory;

	public bool isInInventory;
	public bool isUsed;
	private bool isTaken;

	void Start(){
		objectIsSelected = false;


		isTaken = false;
		itemName = "Handle";
		takeHandleFromInventory = false;
		isInInventory = true;
	}


	// Update is called once per frame
	void Update () {

		if(objectIsSelected && Input.GetMouseButtonDown(0) && !isTaken){
			isTaken = true;
			StoryGameManager.instance.handleIsTaken = true;
			Debug.Log ("Klamka zabrana");
			setIcon (handleIcon);
			InventoryScript.instance.addItem (this);
			Destroy (handle);
		}
	}
		
	void OnGUI(){

			if (takeHandleFromInventory) {
				//klamka zabrana
				GUI.DrawTexture (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), handleMiniature);
				isInInventory = false;
			}

			if (Input.GetMouseButtonDown (2) && !isInInventory) {
				setIcon (handleIcon);
				takeHandleFromInventory = false;
				InventoryScript.instance.addItem (this);
				isInInventory = true;
			}

	}

	//-------------------------------------------------------------------------------------------------------//

	public override void action(){
		this.takeHandleFromInventory = true;
	}
}
