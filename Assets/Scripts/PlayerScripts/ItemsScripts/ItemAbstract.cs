using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//klasa abstrakcyjna - klasa, która ma jakąś swoją budowę, ale nie może posiadać instancji
//zawiera informacje wspólne dla kilku obiektów

public abstract class ItemAbstract : MonoBehaviour {

	public Texture2D itemIcon;

	public string itemName;
	public int itemCounter;
	public string description;
	public string type;
	public bool disposable;

	//--------------------------------------------------------------------------------------------------------//
	void OnMouseEnter() {}

	//--------------------------------------------------------------------------------------------------------//
	void OnMouseExit() {}

	//--------------------------------------------------------------------------------------------------------//
	//getters

	public Texture2D getItemIcon (){
		return this.itemIcon;
	}

	public string getItemName() {
		return this.itemName;
	}

	public string getDescription() {
		return this.description;
	}

	public string getType() {
		return this.type;
	}

	public bool getDisposable() {
		return this.disposable;
	}

	public abstract void action ();


	//--------------------------------------------------------------------------------------------------------//

	public void setIcon(Texture2D itemIcon){
		this.itemIcon = itemIcon;
	}

	public void setItemCounter(int value){
		this.itemCounter = value;
	}


}
