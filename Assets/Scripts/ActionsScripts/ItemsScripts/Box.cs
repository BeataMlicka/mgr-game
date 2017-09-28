using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ItemAbstract {

	public GameObject ax;
	public GameObject bixWoodenBox;

	public AudioSource audioSource;

	void Start(){
		objectIsSelected = false;
		audioSource.enabled = false;
	}

	// Update is called once per frame
	void Update () {

			if (objectIsSelected && Input.GetMouseButtonDown (0) && ax.GetComponent<AxData>().takeAxFromInventory) {
				audioSource.enabled = true;
				Destroy (this.gameObject);
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

	public override void action(){
		Debug.Log ("Drawer Action!");
	}

}
