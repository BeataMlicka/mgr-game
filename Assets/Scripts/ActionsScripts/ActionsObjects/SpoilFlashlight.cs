using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoilFlashlight : ActionsAbstract {

	public Light flashlight;



	public override void action(){}


	//-------------------------------------------------------------------------------------------------//
	private void isOff(){

		FlashlightLight.instance.setBatteryLoadingLevel (-200);
	}

	private void unchargedBattery(){

		FlashlightLight.instance.setBatteryLoadingLevel (-20);
	}
}
