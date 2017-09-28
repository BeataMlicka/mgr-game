using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : InteractiveGameObject {

	public GameObject door;

	void Start(){
		animator = door.GetComponent<Animator> ();
		isOpen = false;
		isLocked = false;
	}


	void OnTriggerStay(Collider other){

		if (Input.GetKeyDown(KeyCode.F)) {

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

	public void slam(){

		if (isOpen) {
			animator.SetTrigger ("slam");
			audioSource.PlayOneShot (slamSound);
			isOpen = !isOpen;
		} else {
			animator.SetTrigger ("open");
			isOpen = !isOpen;
			this.slam ();
		}
	}



	public void creak(){

		if (!isOpen) {
			animator.SetTrigger ("open");
			audioSource.PlayOneShot (creakSound);
			isOpen = !isOpen;
		}
	}
}
