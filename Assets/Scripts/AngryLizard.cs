using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngryLizard : MonoBehaviour {
	public int timesUntilAngry;

	public GameObject descriptionTextObject;
	private Text dText;
	private DescriptionTimer dTimer;

	// Use this for initialization
	void Start () {
		this.timesUntilAngry = 3;


		this.dTimer = descriptionTextObject.GetComponent<DescriptionTimer> ();
		this.dText = descriptionTextObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
