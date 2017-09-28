using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyData : ItemAbstract {

	public Texture2D keyIcon;
	public Texture2D keyMiniature;
	public GameObject key;

	public bool takeHandleFromInventory;

	public bool isInInventory;
	public bool isUsed;
	private bool isTaken;
	private bool isMissing;

	void Start(){
		objectIsSelected = false;

		isTaken = false;
		itemName = "Handle";
		takeHandleFromInventory = false;
		isInInventory = true;

		key.SetActive (false);

		isMissing = true;
	}


	// Update is called once per frame
	void Update () {

		if(isMissing){
			if (StoryGameManager.instance.paintingFallen) {
				key.SetActive (true);
				isMissing = false;
			}
		}

		if(objectIsSelected && Input.GetMouseButtonDown(0) && !isTaken){
			isTaken = true;
			StoryGameManager.instance.keyIsTaken = true;
			Debug.Log ("Klucz zabrany");
			setIcon (keyIcon);
			InventoryScript.instance.addItem (this);
			Destroy (key);
		}
	}

	void OnGUI(){

		if (takeHandleFromInventory) {
			//klamka zabrana
			GUI.DrawTexture (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), keyMiniature);
			isInInventory = false;
		}

		if (Input.GetMouseButtonDown (2) && !isInInventory) {
			setIcon (keyIcon);
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
