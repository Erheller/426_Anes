using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngryLizard : MonoBehaviour {
	public int timesUntilAngry;
	public Text descriptionText;

	// Use this for initialization
	void Start () {
		this.timesUntilAngry = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
