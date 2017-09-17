using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

	public static GameStateManager instance;
	private string currentGameVersion;

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
	public void setCurrentGameVersion(string version){

		this.currentGameVersion = version;
	}

	public string getCurrentGameVersion(){
	
		return this.currentGameVersion;
	}

}
