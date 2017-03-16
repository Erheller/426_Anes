using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetController : MonoBehaviour {
	public GameObject door1;
	public GameObject door2;
	bool closed;

	// Use this for initialization
	void Start () {
		this.closed = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void openDoors () {
		door1.transform.Rotate (Vector3.forward * 130);
		door2.transform.Rotate (Vector3.forward * 130);
		this.closed = false;
	}

	void closeDoors() {
		door1.transform.Rotate (Vector3.back * 130);
		door2.transform.Rotate (Vector3.back * 130);
		this.closed = true;
	}

	public void toggleDoors () {
		if (this.closed == true) {
			this.openDoors ();
		} else {
			this.closeDoors ();
		}
	}
}
