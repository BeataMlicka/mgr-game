using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGameManager : MonoBehaviour {


	private bool catchData;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (UnityEngine.Random.Range (0, 10) > 9) {
			catchData = true;
		} else {
			catchData = false;
		}
		
	}



	public bool getCatchData(){
		return this.catchData;
	}
}
