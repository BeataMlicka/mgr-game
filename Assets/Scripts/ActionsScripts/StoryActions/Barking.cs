using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barking : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip barking;


	void OnTriggerEnter(Collider other){

		audioSource.PlayOneShot (barking);
	}
		
}
