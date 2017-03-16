using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviePlayer : MonoBehaviour {
	MovieTexture mt;	//this is the MovieTexture that is placed on the inside of the sphere
	AudioSource aSource;
	public static float timeElapsed;


	// Use this for initialization
	void Start () {
		// this line of code will make the Movie Texture begin playing
		mt = (MovieTexture)GetComponent<Renderer> ().material.mainTexture;
		mt.Play ();

		aSource = this.GetComponent<AudioSource>();
		aSource.clip = mt.audioClip;
		aSource.Play ();



		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
		if (mt.isPlaying) {
			timeElapsed += Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (mt.isPlaying)
				mt.Pause ();
			else
				mt.Play ();
		}
	}

	public void Pause () {
		mt.Pause ();
	}

	public void Play () {
		mt.Play ();
	}
}
