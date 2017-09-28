using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwlData : ItemAbstract {

	public Texture2D awlIcon;
	public Texture2D awlMiniature;
	public GameObject awl;

	public bool takeAwlFromInventory;

	public bool isInInventory;
	public bool isUsed;
	private bool isTaken;

	void Start(){
		objectIsSelected = false;
		isTaken = false;
		itemName = "Awl";
		takeAwlFromInventory = false;
		isInInventory = true;
	}


	// Update is called once per frame
	void Update () {

		if(objectIsSelected && Input.GetMouseButtonDown(0) && !isTaken){
			isTaken = true;
			Debug.Log ("Szydło zabrane");
			setIcon (awlIcon);
			InventoryScript.instance.addItem (this);
			Destroy (awl);
		}
	}

	void OnGUI(){

		if (takeAwlFromInventory) {
			//klamka zabrana
			GUI.DrawTexture (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), awlMiniature);
			isInInventory = false;
		}

		if (Input.GetMouseButtonDown (2) && !isInInventory) {
			setIcon (awlIcon);
			takeAwlFromInventory = false;
			InventoryScript.instance.addItem (this);
			isInInventory = true;
		}

	}

	//-------------------------------------------------------------------------------------------------------//

	public override void action(){
		this.takeAwlFromInventory = true;
	}
}
