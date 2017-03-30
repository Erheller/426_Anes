﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class folderMouse : MonoBehaviour {
	public GameObject examineTextObject;
	public GameObject descriptionTextObject;
	public GameObject ProfQuestions;
	public GameObject Objective;
	public GameObject sphere;


	private Text objectiveText;
	private Text text;
	private Text descText;
	private DescriptionTimer dTimer;

	private float descTimeLeft; 

	int[] items;

	// Use this for initialization
	void Start () {
		getText ();
		this.descTimeLeft = 0;
		this.dTimer = descriptionTextObject.GetComponent<DescriptionTimer> ();

		this.items = new int[3];	//inventory size of 3
	}
	
	// Update is called once per frame
	void Update () 
	{


		RaycastHit hitInfo = new RaycastHit();
		bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

		if (hit) {
			text.text = "";
			GameObject tempObject = hitInfo.transform.gameObject;

			//cabinet opening and closing
			CabinetController tempCabinet = tempObject.GetComponent<CabinetController> ();
			if (tempCabinet != null) {
				text.text = "Open\n" + tempObject.name;

				if (Input.GetMouseButtonDown (0)) {
					tempCabinet.toggleDoors ();
				}
			}



			//else {
				//picking up items
			//	PickUp tempPick = tempObject.GetComponent<PickUp> ();
			//	if (tempPick != null) {
			//		this.pickUpItem (tempPick);
			//	}


				else {
					//examining objects
					Description tempDesc = tempObject.GetComponent<Description> ();
					//objects that have descriptions
					if (tempDesc != null) {
						//special folder exception
						if (tempObject.tag == "Folder") {
							text.text = "Go to simulation";
							if (Input.GetMouseButtonDown (0)) {
								print ("Folder Clicked!");
								this.load ();
							}
						}
							

						//general items with descriptions
						else {
							text.text = "Examine\n" + tempObject.name;

							if (Input.GetMouseButtonDown (0)) {
								descText.text = tempDesc.getDescription ();
								this.dTimer.startTimer ();
							}
						}

					}
					else if (tempObject.tag == "Door") {
						text.text = "Go to Professor's office";
						if (Input.GetMouseButtonDown (0)) {
							print ("Door Clicked!");
							this.loadOffice ();
						}
					} else if (tempObject.tag == "OfficeDoor") {
						text.text = "Go to Apartment";
						if (Input.GetMouseButtonDown (0)) {
							print ("Door Clicked!");
							this.loadRoom ();
						}
					} else if (tempObject.tag == "Professor") {
						text.text = "Talk to Professor";
						if (Input.GetMouseButtonDown (0)) {
							Cursor.visible = true;
							Cursor.lockState = CursorLockMode.None;

							ProfQuestions.SetActive (true);
						}
					} else if (tempObject.tag == "Stethoscope") {
						text.text = "Take Stethoscope";
						if (Input.GetMouseButtonDown (0)) {
							PickUp tempPick = tempObject.GetComponent<PickUp> ();
							if (tempPick != null) {
								this.pickUpItem (tempPick);
							tempObject.SetActive (false);
							objectiveText.text = "Proceed to simulation";
						}
					}
					/*
					else {
						text.text = "";
					}
					*/
				}
			}

		}


		if (Input.GetMouseButtonDown(1))
		{
			var ball = GameObject.Instantiate (sphere, this.transform.position, Quaternion.identity) as GameObject;

			Vector3 value=new Vector3(0, 1 ,0);
			ball.transform.position=transform.position + value;
			ball.GetComponent<Rigidbody> ().velocity = transform.forward * 3;
			ball.GetComponent<Rigidbody> ().velocity += Vector3.up * 1;

		}

	}

	public void pickUpItem (PickUp pick) {
		this.items [pick.id] = 1;
	}

	public void load()
	{
		Application.LoadLevel("test");
	}

	public void loadOffice()
	{
		Application.LoadLevel ("Office");
	}

	public void loadRoom()
	{
		Application.LoadLevel ("room");
	}

	void getText() {

		this.text = examineTextObject.GetComponent<Text> ();
		this.descText = descriptionTextObject.GetComponent<Text> ();
		this.objectiveText = Objective.GetComponent<Text> ();
	}
}
