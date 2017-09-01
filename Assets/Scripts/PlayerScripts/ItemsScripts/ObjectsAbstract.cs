using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsAbstract : MonoBehaviour {

	public string itemName;
	public string description;
	public bool isOpen;
	public bool objectIsSelected;

	//--------------------------------------------------------------------------------------------------------//
	void OnMouseEnter() {}

	//--------------------------------------------------------------------------------------------------------//
	void OnMouseExit() {}

	//--------------------------------------------------------------------------------------------------------//
	//getters

	public string getItemName() {
		return this.itemName;
	}

	public string getDescription() {
		return this.description;
	}

	public abstract void action ();




}
