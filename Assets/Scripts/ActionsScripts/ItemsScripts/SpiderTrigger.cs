using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTrigger : ActionsAbstract {

	public AudioSource audioSource;

	private bool spider1;
	private bool spider2;
	private bool spider3;

	public Texture2D spiderImage1;
	public Texture2D spiderImage2;
	public Texture2D spiderImage3;

	private float time;
	private bool playerInTrigger;

	void Start(){
		audioSource.enabled = false;

		spider1 = false;
		spider2 = false;
		spider3 = false;

		playerInTrigger = false;
		time = 0; 
	}


	void Update(){

		if(playerInTrigger){

			time += Time.deltaTime;
			Debug.Log ("time - " + time);
			audioSource.enabled = true;

			if(time > 1.5f){
				spider1 = true;
			}

			if(time > 2){
				spider1 = false;
				spider2 = true;
			}

			if(time > 2.5f){
				spider2 = false;
				spider3 = true;
			}

			if (time > 3) {
				Destroy (this);
			}
		}
	}

	public override void action(){
		StoryGameManager.instance.setConditions (5 ,true);
		StoryGameManager.instance.spiderAttacked = true;
	}
		

	void OnGUI(){

		if(spider1){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), spiderImage1);
		}
		if(spider2){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), spiderImage2);
		}
		if(spider3){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), spiderImage3);
		}
	}

	void OnTriggerEnter(){
		Debug.Log ("Jestem w trigerze");
		action ();
		playerInTrigger = true;
	}
}
