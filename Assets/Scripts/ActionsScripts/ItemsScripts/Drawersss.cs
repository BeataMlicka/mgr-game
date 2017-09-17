using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawersss : ObjectsAbstract {

	Vector3 displacement;
	private float counter;

	public AudioSource audioSource;
	public AudioClip openingDrawer;
	public AudioClip closingDrawers;
	public AudioClip lockDrawer;

	public bool isLock;

	void Start(){
		objectIsSelected = false;
		isOpen = false;
		displacement = new Vector3 (0, 0, 0.002f);
	}

	// Update is called once per frame
	void Update () {

		if (objectIsSelected && Input.GetMouseButtonDown (0)) {
				
			if (!isOpen && !isLock) {

				audioSource.PlayOneShot (openingDrawer);
				open ();
				isOpen = !isOpen;

			} else if (isOpen) {

				audioSource.PlayOneShot (closingDrawers);
				close ();
				isOpen = !isOpen;
			} else {
				audioSource.PlayOneShot (lockDrawer);
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
		Debug.Log ("BINGOO!!");
	}


	public void waitFunction(double waitTime){

		for (double time = waitTime; waitTime > 0;) {
			Debug.Log ("");
			waitTime -= Time.deltaTime;
		}
	}
}


