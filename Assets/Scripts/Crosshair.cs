﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
	Rect crosshairRect;
	Texture crosshairTexture;

	// Use this for initialization
	void Start () {
		float crosshairSize = Screen.width * 0.01f;
		crosshairTexture = Resources.Load ("Textures/crosshair") as Texture;
		crosshairRect = new Rect (Screen.width / 2 - crosshairSize / 2,
									Screen.height / 2 - crosshairSize / 2, 
									crosshairSize, crosshairSize);
	}
	
	// Update is called once per frame
	void OnGUI()
	{
		GUI.DrawTexture (crosshairRect, crosshairTexture);
	}
}
