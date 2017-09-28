using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	//publiczna zmienna statyczna, która jest punktem dostępu do zawartości klasy
	public static GameManager instance;

	//kind of gameplay
	public string currentGameVersion;
	public GameObject currentLocation;

	public GameObject mainCamera;
	public GameObject gameManagers;
	public GameObject player;


	public float fullGameTime;
	public bool actionFlag;

	private AffectiveGameManager affectiveGameManager;
	private StoryGameManager storyGameManager;

	public bool changeScene;

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
		currentGameVersion = GameStateManager.instance.getCurrentGameVersion();

		Debug.Log ("CURRENTGAME: " + currentGameVersion);

		actionFlag = false;

		storyGameManager = gameObject.GetComponent<StoryGameManager>();
		affectiveGameManager = gameObject.GetComponent<AffectiveGameManager>();
		changeScene = false;
	}

	//--------------------------------------------------------------------------------------------------------//

	void FixedUpdate(){

		//Debug.Log (fullGameTime);
		this.fullGameTime += Time.deltaTime;

		if(changeScene){
			SceneManager.LoadScene("TheEnd");
			gameManagers.SetActive (false);
			mainCamera.SetActive (false);
			player.SetActive (false);
		}

		//Debug.Log ("Current = " + currentLocation);
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

	//--------------------------------------------------------------------------------------------------------//

}

