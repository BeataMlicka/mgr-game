using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : ObjectsAbstract {

	Vector3 displacement;

	public GameObject monsterTrigger;

	public GameObject chest;
	public Animator animator;

	private float counter;
	public bool isLock;
	public bool isMoved;

	void Start(){
		animator = chest.GetComponent<Animator> ();

		objectIsSelected = false;
		counter = 0;
		isMoved = false;
		monsterTrigger.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if(StoryGameManager.instance.handleIsTaken){
			StoryGameManager.instance.chestIsMoved = true;
			animator.SetTrigger ("move");
			isMoved = true;
		}

		if (objectIsSelected && Input.GetMouseButtonDown (0) && isMoved) {
			if (counter == 0) {
				animator.SetTrigger ("one");
				monsterTrigger .SetActive(true);
				counter++;
			} else if (counter == 1) {
				animator.SetTrigger ("two");
				counter++;
			} else if (counter == 2) {
				animator.SetTrigger ("three");
				counter++;
			} else if (counter == 3) {
				animator.SetTrigger ("four");
				counter++;
			} else {
				Destroy (this);
			}
		}
	}


	void OnMouseEnter(){
		CameraController.instance.setCursorOnObject(true);
		this.objectIsSelected = true;
		Debug.Log ("Jestem na skrzyni :D ;]");
	}

	void OnMouseExit(){
		CameraController.instance.setCursorOnObject(false);
		this.objectIsSelected = false;
	}


	//--------------------------------------------------------------------------------------------------------//

	public override void action(){
		Debug.Log ("BINGOO!!");
	}
		
}
