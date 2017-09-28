using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFlashlight : ActionsAbstract {

	public GameObject gameManagers;
	public GameObject mainCamera;

	private float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if(StoryGameManager.instance.labolatoryAlarm){
		
			timer += Time.deltaTime;

			if(timer > 70 && timer < 10.5){
				FlashlightLight.instance.setBatteryLoadingLevel (-100);
			}

			if(timer > 100){
				
				Monster.instance.ghostAtack = true;
			}
			if(timer > 103){
				action ();
				GameManager.instance.changeScene = true;
				Destroy (this);
			}

		}
	}

	public override void action(){
		StoryGameManager.instance.setConditions (9, true);

	}
}
