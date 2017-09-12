using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLamp : MonoBehaviour {

	private double intensity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		this.gameObject.transform.GetComponent<Light> ().intensity = 0;
	}
}
