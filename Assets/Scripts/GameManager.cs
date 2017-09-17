using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//publiczna zmienna statyczna, która jest punktem dostępu do zawartości klasy
	public static GameManager instance;

	//kind of gameplay
	public string currentGameVersion;

	public float fullGameTime;
	public bool actionFlag;

	private AffectiveGameManager affectiveGameManager;
	private StoryGameManager storyGameManager;

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
		this.fullGameTime = 0;
		currentGameVersion = "";

		actionFlag = false;

		affectiveGameManager = gameObject.GetComponent<AffectiveGameManager>();
		storyGameManager = gameObject.GetComponent<StoryGameManager>();
	}

	//--------------------------------------------------------------------------------------------------------//

	void Update(){

		//Debug.Log (fullGameTime);
		this.fullGameTime += Time.deltaTime;

		if (actionFlag) {
			affectiveGameManager.action ();
			actionFlag = false;
		}
	}
		

	//--------------------------------------------------------------------------------------------------------//

	//getters and setters
	public void setCurrentGameVersion(string gameVersion){
		this.currentGameVersion = gameVersion;
	}

	//getters

	public string getCurrentGameVersion(){
		return this.currentGameVersion;
	}

	public float getFullGameTime(){
		return this.fullGameTime;
	}

}

