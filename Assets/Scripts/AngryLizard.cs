using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngryLizard : MonoBehaviour {
	public int timesUntilAngry;

	public GameObject descriptionTextObject;
	private Text dText;
	private DescriptionTimer dTimer;
	public GameObject player;

	private float timer;

	// Use this for initialization
	void Start () {
		this.timesUntilAngry = 3;


		this.dTimer = descriptionTextObject.GetComponent<DescriptionTimer> ();
		this.dText = descriptionTextObject.GetComponent<Text> ();

		this.timer = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.timer != -1) {
			this.timer -= Time.deltaTime;
			if (this.timer <= 0) {
				Application.LoadLevel ("room");
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
			print ("Lizard collided with Player");
			this.timesUntilAngry--;


			switch (this.timesUntilAngry) {
			case 0:
				this.dText.text = "Yowch! Your iguana bites you. You'll be going to the emergency room as a patient this time.";
				this.timer = 2;
				break;
			case 1:
				this.dText.text = "Your iguana bares its fangs and hisses. You probably shouldn't step on it again.";
				dTimer.startTimer ();
				break;
			case 2:
				this.dText.text = "You step on something squishy. It's your iguana. It hisses softly.";
				dTimer.startTimer ();
				break;
			}

		}
	}

}
