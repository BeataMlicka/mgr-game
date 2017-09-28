using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public static Monster instance;
	public bool attack;

	public AudioSource audioSource;
	public AudioClip pterodactyl;
	public AudioClip swoosh;

	public Texture2D claws1Img;
	public Texture2D claws2Img;
	public Texture2D claws3Img;
	public Texture2D claws4Img;

	public Texture2D face1Img;
	public Texture2D face2Img;
	public Texture2D face3Img;

	private bool claws1;
	private bool claws2;
	private bool claws3;
	private bool claws4;

	private bool face1;
	private bool face2;
	private bool face3;

	private float time;
	private float lastAttackTime;
	public bool ghostAtack;
	//--------------------------------------------------------------------------------------------------------//

	void Awake(){

		if (instance == null) {

			DontDestroyOnLoad (gameObject);
			instance = this;

		} else if(instance != this) {
			Destroy (gameObject);
		}
	}

	//--------------------------------------------------------------------------------------------------------//
	void Start(){
		attack = false;

		claws1 = false;
		claws2 = false;
		claws3 = false;
		claws4 = false;

		face1 = false;
		face2 = false;
		face3 = false;

		time = 0;
		lastAttackTime = 0;

		ghostAtack = false;
	}

	//--------------------------------------------------------------------------------------------------------//
	void Update(){

		lastAttackTime += Time.deltaTime;

		if(attack && lastAttackTime > 15){
			ghostAtack = true;
			lastAttackTime = 0;
		}


		if (ghostAtack) {

			time += Time.deltaTime;

			if(time > 0 && time < 0.25){
				face1 = true;
				audioSource.PlayOneShot (pterodactyl);
			}
			if(time > 0.2f && time < 0.5f){
				face1 = false;
				face2 = true;
				claws1 = true;
				audioSource.PlayOneShot (swoosh);

			}
			if(time > 0.4f && time < 0.65f){
				claws1 = false;
				claws2 = true;
				audioSource.PlayOneShot (swoosh);
			}
			if(time > 0.6f && time < 0.85f){
				claws2 = false;
				claws3 = true;
				audioSource.PlayOneShot (swoosh);

			}
			if(time > 0.8 && time < 1.05f){
				claws3 = false;
				face2 = false;
				PlayerData.instance.damage (1f);
				ghostAtack = false;
				time = 0;
			}
		}
	}

	//--------------------------------------------------------------------------------------------------------//

	void OnGUI(){

		if(claws1){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), claws1Img);
		}
		if(claws2){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), claws2Img);
		}
		if(claws3){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), claws3Img);
		}
		if(claws4){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), claws4Img);
		}
		if(face1){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), face1Img);
		}
		if(face2){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), face2Img);
		}
		if(face3){
			GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), face3Img);
		}
	}
}
