using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaboratoryKeyData : ItemAbstract {

	public Texture2D keyIcon;
	public Texture2D keyMiniature;
	public GameObject key;

	public bool takeKeyFromInventory;

	public bool isInInventory;
	public bool isUsed;
	private bool isTaken;
	public GameObject lockingDoorTrigger;

	void Start(){
		
		objectIsSelected = false;
		isTaken = false;
		itemName = "KeyLab";
		takeKeyFromInventory = false;
		isInInventory = true;

		lockingDoorTrigger.SetActive (false);
	}


	// Update is called once per frame
	void Update () {

		if(objectIsSelected && Input.GetMouseButtonDown(0) && !isTaken){
			isTaken = true;
			StoryGameManager.instance.keyIsTaken = true;
			Debug.Log ("Klucz zabrany");
			setIcon (keyIcon);
			InventoryScript.instance.addItem (this);
			StoryGameManager.instance.laboratoryKey = true;
			lockingDoorTrigger.SetActive (true);
			Destroy (key);
		}
	}

	void OnGUI(){

		if (takeKeyFromInventory) {
			//klamka zabrana
			GUI.DrawTexture (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), keyMiniature);
			isInInventory = false;
			Debug.Log ("Klucz wyjęty z inwentarza");
		}

		if (Input.GetMouseButtonDown (2) && !isInInventory) {
			setIcon (keyIcon);
			takeKeyFromInventory = false;
			InventoryScript.instance.addItem (this);
			isInInventory = true;
		}

	}

	//-------------------------------------------------------------------------------------------------------//

	public override void action(){
		this.takeKeyFromInventory = true;
	}
}
