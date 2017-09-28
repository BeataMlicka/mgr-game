using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : InteractiveGameObject {

	public GameObject drawer;
	private bool objectIsSelected;

	void Start(){
		animator = drawer.GetComponent<Animator> ();
		isOpen = false;
		isLocked = false;
		objectIsSelected = false;
	}
		
	void Update(){

		if (objectIsSelected && Input.GetMouseButtonDown(2) && !isLocked) {

			if(isOpen){

				animator.SetTrigger ("close");
				audioSource.PlayOneShot (closeSound);
				isOpen = !isOpen;
			}
			else if(!isOpen){

				animator.SetTrigger ("open");
				audioSource.PlayOneShot (openSound);
				isOpen = !isOpen;
			}
		}
	}


	void OnMouseEnter(){

		objectIsSelected = true;
	}

	void OnMouseExit(){

		objectIsSelected = false;
	}

}
