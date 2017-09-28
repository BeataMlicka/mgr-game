using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

	public static PlayerData instance; 

	public float currentHealth;
	public float maxHealth;

	public Slider healthbar;

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

	// Use this for initialization
	void Start () {
		maxHealth = 100f;
		currentHealth = maxHealth;

		healthbar.value = calculateHealth ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.H)){
			damage (20f);
		}	
	}


	public void damage(float damage){
		currentHealth -= damage;

		healthbar.value = calculateHealth ();
	}


	public float calculateHealth(){

		return currentHealth / maxHealth;
	}
}
