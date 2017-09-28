using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPainting : ActionsAbstract {

	public AudioSource audioSource;
	private Animator animator;

	public GameObject triggerPainting;

//	private FallingPaintingTrigger fallingPaintingTrigger;
	public bool fall;

	// Use this for initialization
	void Start () { 

		fall = false;
		animator = this.GetComponent<Animator> ();
		audioSource.enabled = false;
		triggerPainting.SetActive (false);
	}

	void Update(){

		if(StoryGameManager.instance.theBoxIsOpen){
			triggerPainting.SetActive (true);
		}

		if (fall) {
			action ();
		}

	}

	//-------------------------------------------------------------------------------------------------------

	public override void action(){
		animator.SetTrigger ("fall");
		audioSource.enabled = true;
		fall = false;
	}
}
