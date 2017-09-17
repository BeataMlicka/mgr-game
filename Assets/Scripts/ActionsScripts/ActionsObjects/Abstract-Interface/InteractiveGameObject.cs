using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveGameObject : MonoBehaviour {

	public AudioSource audioSource;

	public AudioClip openSound;
	public AudioClip closeSound;
	public AudioClip slamSound;
	public AudioClip creakSound;

	public bool isOpen;
	public bool isLocked;

	public GameObject gameObject;
	public Animator animator;

	public void openObject(){
		
		audioSource.PlayOneShot (openSound);
	}

	public void closeObject(){

		audioSource.PlayOneShot (closeSound);
	}

	public void slamObject(){

		audioSource.PlayOneShot (slamSound);
	}


	public void creakObject(){

		audioSource.PlayOneShot (creakSound);
	}

}
