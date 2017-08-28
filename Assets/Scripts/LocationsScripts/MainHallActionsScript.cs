using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHallActionsScript : MonoBehaviour {

	public Light mainHallLight;

	public void changeLight(){

		mainHallLight.color = Color.red;
	}

}
