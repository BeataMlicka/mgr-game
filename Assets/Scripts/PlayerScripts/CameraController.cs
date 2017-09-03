using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class CameraController : MonoBehaviour {

	public static CameraController instance; 

	public double gameTimeCounter; 

	public Texture2D pointerCursor;
	public Texture2D handCursor;
	public Texture2D holdingHandCursor;
	public Texture2D pointerHandCursor;

	//zmienen kursora
	private bool cursorIsLock; //sp.z
	private bool cursorOnObject;

	private int cursorSizeX = 40;
	private int cursorSizeY = 40;

	public FirstPersonController fpc;

	//private bool lockCursor = true;

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
		cursorOnObject = false;
		cursorIsLock = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		fpc = GameObject.FindObjectOfType<FirstPersonController> ();

		gameTimeCounter = 0;
	}

	//--------------------------------------------------------------------------------------------------------//

	// Update is called once per frame
	void Update () {

		gameTimeCounter += Time.deltaTime;


		UpdateCursor ();

		if (Input.GetMouseButtonDown (1)) {
			fpc.enabled = !fpc.enabled;
		}
	}

	//--------------------------------------------------------------------------------------------------------//
	void OnGUI(){

		//jeżeli kursor jest zablokowany i nie jest na obiekcie
		if (cursorIsLock && !cursorOnObject) {
			GUI.DrawTexture (new Rect (Input.mousePosition.x - cursorSizeX / 2, (Screen.height - Input.mousePosition.y - cursorSizeY / 2), 
				cursorSizeX, cursorSizeY), pointerCursor);
		}

		//kursor na obiekcie i unieruchomiony
		else if (cursorIsLock && cursorOnObject && !Input.GetMouseButtonDown(0)) {
			GUI.DrawTexture (new Rect (Input.mousePosition.x - cursorSizeX / 2, (Screen.height - Input.mousePosition.y - cursorSizeY / 2), 
				cursorSizeX, cursorSizeY), handCursor);			
		}

		//kursor odblokowany
		else if (!cursorIsLock) {
			GUI.DrawTexture (new Rect (Input.mousePosition.x - cursorSizeX / 2, (Screen.height - Input.mousePosition.y - cursorSizeY / 2), 
				cursorSizeX, cursorSizeY), handCursor);
		}
	}

	//--------------------------------------------------------------------------------------------------------//

	public void setCursorOnObject(bool value){
		this.cursorOnObject = value;
	}
		

	public void setLockCursor(bool value) {
		this.cursorIsLock = value;
	}

	//--------------------------------------------------------------------------------------------------------//

	//funkcja aktualizująca wygląd kursora
	public void UpdateCursor() {

		if(Input.GetKeyUp (KeyCode.Escape)) {
			setLockCursor (false);
			Cursor.lockState = CursorLockMode.None;
		}

		else if (Input.GetMouseButtonUp(0)) {
			setLockCursor (true);
			Cursor.lockState = CursorLockMode.Locked;
		}

		else if (Input.GetMouseButtonDown(1)) {
			
			setLockCursor (!this.cursorIsLock);

			if (this.cursorIsLock) {
				Cursor.lockState = CursorLockMode.Locked;
			} else {
				Cursor.lockState = CursorLockMode.None;
			}
		}

	}
}
