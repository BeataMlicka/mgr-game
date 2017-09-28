using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenBox : ItemAbstract {

	public GameObject awl;
	public GameObject woodenBox;
	public GameObject openBox;
	public OpenBox openBoxScript;


	private Animator animator;

	public AudioSource audioSource;

	public bool awlIsActive;
	public bool isUsed;

	void Start(){
		objectIsSelected = false;
		awlIsActive = false;
		animator = woodenBox.GetComponent<Animator> ();
		isUsed = false;
		audioSource.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		if(!isUsed){
			if (objectIsSelected && Input.GetMouseButtonDown (0) && awl.GetComponent<AwlData>().takeAwlFromInventory) {
				audioSource.enabled = true;
				animator.SetTrigger ("open");
				StoryGameManager.instance.theBoxIsOpen = true;
				isUsed = true;
				Destroy (awl);
			}
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
