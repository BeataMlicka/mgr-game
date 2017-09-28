using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangeSounds : ActionsAbstract {

	public static StrangeSounds instance;

	//--------------------------------------------------------------------------------------------------------//

	void Awake(){

		if (instance == null) {

			DontDestroyOnLoad (gameObject);
			instance = this;

		} else if(instance != this) {
			Destroy (gameObject);
		}

	}

	/// <summary>
	/// T///////////////	/// </summary>

	public Queue<GameObject> strangeSoundsQueue;

	public GameObject hornedOwl;

	public bool actionFlag;


	// Use this for initialization
	void Start () {

		strangeSoundsQueue = new Queue<GameObject> ();

		//dodanie elementów do kolejki
		strangeSoundsQueue.Enqueue(hornedOwl);

	}

	public override void action(){
		strangeSoundsQueue.Peek ().GetComponent<MakeStrangeSound> ().action();
	}
}
