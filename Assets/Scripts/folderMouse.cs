using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class folderMouse : MonoBehaviour {
	public GameObject examineTextObject;
	public GameObject descriptionTextObject;

	private Text text;
	private Text descText;

	private float descTimeLeft; 

	// Use this for initialization
	void Start () {
		getText ();
		this.descTimeLeft = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (descTimeLeft > 0) {
			descTimeLeft -= Time.deltaTime;
		} else {
			descText.text = "";
		}


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
			} else {
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
							this.descTimeLeft = 3;
						}
					}
				}

			//no description
				else {
					text.text = "";
				}
			}

		}

		else {
			text.text = "";
		}
	}

	public void load()
	{
		Application.LoadLevel("test");
	}

	void getText() {

		this.text = examineTextObject.GetComponent<Text> ();
		this.descText = descriptionTextObject.GetComponent<Text> ();
	}
}
