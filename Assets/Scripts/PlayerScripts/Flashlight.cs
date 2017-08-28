using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

	public Light flashlight;
	public bool isActive;

	// Use this for initialization
	void Start () {
		flashlight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {

		flashlight.enabled = isActive;

		if(Input.GetKeyDown("f")){

			isActive = !isActive;			/*
			if (isActive == false) {
				flashlight.enabled == true;
				isActive = true;
			}

/
			else if (isActive == true) {
				
				flashlight.enabled == false;
				isActive = false;
			}*/
		}

	}
}
