using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxData : ItemAbstract {

	public Texture2D axIcon;
	public Texture2D axMiniature;
	public GameObject ax;

	public bool takeAxFromInventory;

	public bool isInInventory;
	public bool isUsed;
	private bool isTaken;

	void Start(){
		objectIsSelected = false;


		isTaken = false;
		itemName = "Handle";
		takeAxFromInventory = false;
		isInInventory = true;
	}


	// Update is called once per frame
	void Update () {

		if(objectIsSelected && Input.GetMouseButtonDown(0) && !isTaken){
			isTaken = true;
			StoryGameManager.instance.handleIsTaken = true;
			Debug.Log ("Klamka zabrana");
			setIcon (axIcon);
			InventoryScript.instance.addItem (this);
			Destroy (ax);
		}
	}

	void OnGUI(){

		if (takeAxFromInventory) {
			//klamka zabrana
			GUI.DrawTexture (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), axMiniature);
			isInInventory = false;
		}

		if (Input.GetMouseButtonDown (2) && !isInInventory) {
			setIcon (axIcon);
			takeAxFromInventory = false;
			InventoryScript.instance.addItem (this);
			isInInventory = true;
		}

	}

	//-------------------------------------------------------------------------------------------------------//

	public override void action(){
		this.takeAxFromInventory = true;
	}
}
