using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawersInDeskOffice : ObjectsAbstract {

	Vector3 displacement;
	private float counter;

	public AudioSource audioSource;
	public AudioClip openingDrawer;
	public AudioClip closingDrawers;

	void Start(){
		objectIsSelected = false;
		isOpen = false;
		displacement = new Vector3 (0, 0, 0.003f);
	}

	// Update is called once per frame
	void Update () {

		if (objectIsSelected && Input.GetMouseButtonDown (0)) {
				
			if (!isOpen) {

				audioSource.PlayOneShot(openingDrawer);
				open ();
				isOpen = !isOpen;

			} else {

				audioSource.PlayOneShot(closingDrawers);
				close ();
				isOpen = !isOpen;
			}
		}
			
	}


	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		this.objectIsSelected = true;
		Debug.Log ("Jestem na szufladzie :D ;]");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		this.objectIsSelected = false;
	}

	//--------------------------------------------------------------------------------------------------------//
	public void open(){

		for (int i = 0; i < 15; i++) {

			waitFunction (0.3);
			this.transform.localPosition += displacement;
		}
	}

	public void close (){
		for (int i = 0; i < 15; i++) {

			waitFunction (0.3);
			this.transform.localPosition -= displacement;
		}
	}

	//--------------------------------------------------------------------------------------------------------//

	public override void action(){
	Debug.Log ("Drawer Action!");
	}


	public void waitFunction(double waitTime){

		for (double time = waitTime; waitTime > 0;) {

			Debug.Log ("");
			waitTime -= Time.deltaTime;
		}
	}
}


