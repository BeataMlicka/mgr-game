using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerWithoutHandle : ItemAbstract {


	public GameObject drawerWithHandle;
	public GameObject handle;

	public AudioSource audioSource;
	public AudioClip lockDrawer;

	public bool handleIsActive;

	void Start(){
		objectIsSelected = false;
		drawerWithHandle.SetActive (false);

		handleIsActive = false;
	}

	// Update is called once per frame
	void Update () {

		if (objectIsSelected && Input.GetMouseButtonDown (0) && handle.GetComponent<HandleData>().takeHandleFromInventory) {
			Destroy (handle);
			StoryGameManager.instance.handleIsUsed = true;
			drawerWithHandle.SetActive (true);
			this.gameObject.SetActive (false);
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

	public override void action(){
		Debug.Log ("Drawer Action!");
	}

}
