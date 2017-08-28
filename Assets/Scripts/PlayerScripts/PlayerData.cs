using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	public static PlayerData instance; 

	private int playerHealth;

	//--------------------------------------------------------------------------------------------------------//

	void Awake(){

		if (instance == null) {

			DontDestroyOnLoad (gameObject);
			instance = this;

		} else if(instance != this) {
			Destroy (gameObject);
		}

	}


	// Use this for initialization
	void Start () {
		playerHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
