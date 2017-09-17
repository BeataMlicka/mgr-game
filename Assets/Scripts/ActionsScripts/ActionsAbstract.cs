using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionsAbstract : MonoBehaviour {

	public GameObject gameObject;


	public void setConditions(int i, bool value){

		StoryGameManager.instance.setConditions (i, value);
	}

	public abstract void action();
}
