using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour {

	public static CheckPointManager instance;

	public GameObject currentTrigger;

	//w momencie wystąpienia 

	private bool[] actionsControler; //tablica sprawdzająca czy dane wydarzenie miało już miejsce


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

		actionsControler = new bool[10];
		//inicjalizacja tablicy na false
		for(int i = 0; i < actionsControler.Length; i++){
			actionsControler [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
