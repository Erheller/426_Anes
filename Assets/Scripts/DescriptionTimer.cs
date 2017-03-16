using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionTimer : MonoBehaviour {
	private float descTimeLeft;
	private Text text;

	// Use this for initialization
	void Start () {
		this.descTimeLeft = 0;
		this.text = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (descTimeLeft > 0) {
			descTimeLeft -= Time.deltaTime;
		}

		else {
			text.text = "";
		}
			
	}


	public void startTimer () {
		this.descTimeLeft = 3;
	}
}
