using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//publiczna zmienna statyczna, która jest punktem dostępu do zawartości klasy
	public static GameManager instance;

	//kind of gameplay
	public string currentGameVersion = "Buka";

	//time counting var
	private float counter = 0;
	private int time = 1;
	private int actionCounter = 3;

	//sensors objects
	private GalvanicSkinResponse gsr;
	private Pulse pulse;
	//private int gsrInput; //zmienna właściwa do arduino
	//private int pulseInput; //zmienna właściwa do arduino
	//private Arduino arduino; 
	private int gsrTestInput; //zmienna pomocnicza
	private int pulseTestInput; //zmienna pomocnicza

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
		gsr = gameObject.GetComponent<GalvanicSkinResponse>();
		pulse = gameObject.GetComponent<Pulse>();
		//arduino = gameObject.GetComponent<Arduino>;
	}

	//--------------------------------------------------------------------------------------------------------//

	void FixedUpdate(){

		if (counter < time) {
			counter += Time.deltaTime;

		} else {

			//example pulse generator 
			gsrTestInput = Random.Range(450, 650); //zmienna pomocnicza
			pulseTestInput = Random.Range (40, 110); //zmienna pomocnicza
			Debug.Log ("gsrTest: " + gsrTestInput); //zmienna pomocnicza
			Debug.Log ("pulseTest: " + pulseTestInput); //zmienna pomocnicza
			pulse.addInput(pulseTestInput);
			gsr.addInput(gsrTestInput);

			if (pulse.getResultsTableSize() >= actionCounter && gsr.getResultsTableSize() >= actionCounter) {
				pulse.checkingResults ();
				gsr.checkingResults ();
				actionCounter += 3;
				Debug.Log ("WYNIKI P: " + pulse.checkingResults());
				Debug.Log ("WYNIKI G: " + pulse.checkingResults());

			}

			counter = 0;
		}
	}

	//--------------------------------------------------------------------------------------------------------//

	//getters and setters
	public void setCurrentGameVersion(string gameVersion){
		this.currentGameVersion = gameVersion;
	}

	public string getCurrentGameVersion(){
		return this.currentGameVersion;
	}
}