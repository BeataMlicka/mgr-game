using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

	//menu objects
	public GameObject introPanelHolder;

	//--------------------------------------------------------------------------------------------------------//
	void Start(){
		Debug.Log ("HELLO: " + GameManager.instance.currentGameVersion);
	}

	//--------------------------------------------------------------------------------------------------------//

	public void SkipIntroButton(){

		SceneManager.LoadScene ("FirstStandardScene");
	}
		
}
