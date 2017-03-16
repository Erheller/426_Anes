using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour {
	public string desc;

	void Awake() {
		//desc = "";
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public string getDescription() {
		return this.desc;
	}
}
