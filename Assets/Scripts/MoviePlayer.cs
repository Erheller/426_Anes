using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviePlayer : MonoBehaviour {
	MovieTexture mt;	//this is the MovieTexture that is placed on the inside of the sphere


	// Use this for initialization
	void Start () {
		// this line of code will make the Movie Texture begin playing
		mt = (MovieTexture)GetComponent<Renderer> ().material.mainTexture;
		mt.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (mt.isPlaying)
				mt.Pause ();
			else
				mt.Play ();
		}
	}
}
