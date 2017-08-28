using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpChangeingLightScript : MonoBehaviour {

	public Light mainHallLight;
	public Light corridorLight;
	public Light officeLight;
	public Light officeRoomLight;

	//funkcja zmieniająca kolor światła
	public void changeLightColor(Light light){
		
	}
	
	// Update is called once per frame
	void Update () {
		
	//	mainHallLight.color = Color.white;

		corridorLight.color = Color.white;
		officeLight.color = Color.yellow;
		officeRoomLight.color = Color.blue;
	}


}

//mainHallLight.intensity = 0.1F;  //zmiana intensywności światła
