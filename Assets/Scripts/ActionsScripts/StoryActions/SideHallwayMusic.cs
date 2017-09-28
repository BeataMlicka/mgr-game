using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideHallwayMusic : ActionsAbstract {

	private float time;
	public GameObject doorTriger;
	public AudioSource ghost;
	public AudioSource hangerCrash;

	public GameObject hanger;
	public GameObject cape;
	public GameObject laboratoryKey;


	private Animator hangerMove;
	private Animator capeMove;

	// Use this for initialization
	void Start () {
		time = 0;
		doorTriger.SetActive (false);
		ghost.enabled = false;

		capeMove = cape.GetComponent<Animator> ();
		hangerMove = hanger.GetComponent<Animator> ();
		laboratoryKey.SetActive (false);

		hangerCrash.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		//otwarcie drzwi
		if(StoryGameManager.instance.spiderAttacked){

			time += Time.deltaTime;

			if(time > 30){
				doorTriger.SetActive (true);
				doorTriger.GetComponent<Doors> ().creak ();
			}
		}
	}

	void OnTriggerEnter(){
		action ();
	}

	public override void action(){
		StoryGameManager.instance.sideHallwayFirstTrigger = true;
		StoryGameManager.instance.setConditions (6, true);
		ghost.enabled = true;
		hangerMove.SetTrigger ("fall");
		capeMove.SetTrigger ("fall");
		laboratoryKey.SetActive (true);
		hangerCrash.enabled = true;
		Destroy (this);
	}
}
