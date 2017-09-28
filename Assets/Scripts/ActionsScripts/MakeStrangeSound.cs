using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStrangeSound : ActionsAbstract {

	public GameObject source;
	public AudioSource audioSource;
	public AudioClip sound;

	//----------------------------------------------------------------------------------------------------------------

	public override void action(){
		audioSource.PlayOneShot (sound);
	}
}
