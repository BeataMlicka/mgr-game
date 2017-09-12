using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsTrigger : MonoBehaviour {

	private Animator animator;
	public GameObject door;
	public bool openDoor;

	public AudioSource audioSource;

	public AudioClip open;
	public AudioClip close;
	public AudioClip slam;
	public AudioClip creak;

	// Use this for initialization
	void Start () {
		animator = door.GetComponent<Animator> ();
		openDoor = false;
	}
	

	void OnTriggerStay(Collider other){

		Debug.Log ("Jesteś na terenie drzwi");

		if (Input.GetKeyDown (KeyCode.Q)) {

			if(openDoor){
				
				animator.SetTrigger ("close");
				audioSource.PlayOneShot (close);
				openDoor = !openDoor;
			}
			else if(!openDoor){

				animator.SetTrigger ("open");
				audioSource.PlayOneShot (open);
				openDoor = !openDoor;
			}
		}

	}

	void OnTriggerExit(Collider other){

	}
		

}
