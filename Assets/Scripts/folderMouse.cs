using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class folderMouse : MonoBehaviour {
	public GameObject examineTextObject;
	public GameObject descriptionTextObject;

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

			GameObject tempObject = hitInfo.transform.gameObject;

			//cabinet opening and closing
			CabinetController tempCabinet = tempObject.GetComponent<CabinetController> ();
			if (tempCabinet != null) {
				text.text = "Open\n" + tempObject.name;

				if (Input.GetMouseButtonDown (0)) {
					tempCabinet.toggleDoors ();
				}
			}



			else {
				//picking up items
				PickUp tempPick = tempObject.GetComponent<PickUp> ();
				if (tempPick != null) {
					this.pickUpItem (tempPick);
				}


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
					} else if (tempObject.tag == "Door") {
						text.text = "Go to Professor's office";
						if (Input.GetMouseButtonDown (0)) {
							print ("Door Clicked!");
							this.loadOffice ();
						}
					} else {
						text.text = "";
					}
				}
			}

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
		

	void getText() {

		this.text = examineTextObject.GetComponent<Text> ();
		this.descText = descriptionTextObject.GetComponent<Text> ();
	}
}
