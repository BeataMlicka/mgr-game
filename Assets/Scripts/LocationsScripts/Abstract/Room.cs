using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour {

	public Queue<GameObject> actionQueue;
	public int register;
	public float timeOfVisit;

	public abstract void action ();

	void OnTriggerEnter(){}
	void OnTriggerStay(){}
	void OnTriggerExit(){}
}
