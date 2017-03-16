using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ProfQuestions : MonoBehaviour {

	//public GameObject movie;

	//MoviePlayer mp;

	public GameObject button0;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;

	public int correct;

	ProfQuestion [] qArray;

	public Text actualQuestion;

	public GameObject FPSObject;

	public Text objectiveText;

	void Awake () {
		this.hideQuestions ();

		qArray = new ProfQuestion[1];



		qArray[0] = new ProfQuestion ("How many compressions and breaths per CPR cycle?", "30 compressions, 2 breaths.", "15 compressions, 2 breaths.", "40 compressions, 3 breaths.", "20 compressions, 1 breath.", 0);
		//qArray[1] = new Question ("Okay, here's the second question. Do you want to be here?", "Yes", "No", "help me i've been stuck on this project for 3 years help", "i want to go to las vegas", 1, 20);
	}

	// Use this for initialization
	void Start () {
		//mp = movie.GetComponent<MoviePlayer> ();
		//mp.Play ();

		this.hideQuestions ();

		changeQuestionText ("Do this", "Do that", "Don't do anything", "Help, I'm stuck on this project");
		correct = 2;


		
		FPSObject.GetComponent<FirstPersonController>().enabled = false;

		this.hideQuestions ();
	}

	// Update is called once per frame
	void Update () {
		foreach (ProfQuestion q in qArray) {
			if (MoviePlayer.timeElapsed >= q.getTime ()) {
				this.activateQuestion (q);
			}
		}
	}

	void activateQuestion (ProfQuestion q) {
		//mp.Pause ();
		this.changeQuestionText (q);
		this.showQuestions ();
		q.disableTime ();

	}

	void showQuestions () {
		button0.SetActive (true);
		button1.SetActive (true);
		button2.SetActive (true);
		button3.SetActive (true);

	}

	void hideQuestions () {
		button0.SetActive (false);
		button1.SetActive (false);
		button2.SetActive (false);
		button3.SetActive (false);

		actualQuestion.text = "";
	}

	void changeQuestionText (string a, string b, string c, string d) {
		button0.GetComponentInChildren<Text> ().text = a;
		button1.GetComponentInChildren<Text> ().text = b;
		button2.GetComponentInChildren<Text> ().text = c;
		button3.GetComponentInChildren<Text> ().text = d;
	}

	void changeQuestionText (ProfQuestion q) {
		button0.GetComponentInChildren<Text> ().text = q.getAnswer (0);
		button1.GetComponentInChildren<Text> ().text = q.getAnswer (1);
		button2.GetComponentInChildren<Text> ().text = q.getAnswer (2);
		button3.GetComponentInChildren<Text> ().text = q.getAnswer (3);

		actualQuestion.text = q.questionText;
	}


	void correctAnswer () {
		//mp.Play ();
		this.hideQuestions ();
		FPSObject.GetComponent<FirstPersonController>().enabled = true;
		objectiveText.text = " Go back to apartment";

	}

	void incorrectAnswer () {
		//mp.Play ();
		this.hideQuestions ();
		FPSObject.GetComponent<FirstPersonController>().enabled = true;
		objectiveText.text = " Go back to apartment";

	}

	public void option0 () {
		print ("0 selected");
		if (correct == 0)
			correctAnswer ();
		else
			this.incorrectAnswer ();
	}


	public void option1 () {
		print ("1 selected");

		if (correct == 1)
			this.correctAnswer ();
		else
			this.incorrectAnswer ();
	}	

	public void option2 () {
		print ("2 selected");

		if (correct == 2)
			this.correctAnswer ();
		else
			this.incorrectAnswer ();
	}	

	public void option3 () {
		print ("3 selected");

		this.loadVegas ();

		if (correct == 3)
			this.correctAnswer ();
		else
			this.incorrectAnswer ();
	}

	public void loadVegas () {
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("MovieSphere")) {
			Destroy (o);
		}

		//movie = (GameObject)Instantiate (Resources.Load ("LasVegasMovie"));
	}

}


class ProfQuestion {
	public string questionText;
	string [] answers = new string[4];
	int correctAnswer;

	float triggerTime;

	public ProfQuestion (string q, string a0, string a1, string a2, string a3, int correct) {
		questionText = q;
		answers [0] = a0;
		answers [1] = a1;
		answers [2] = a2;
		answers [3] = a3;
		correctAnswer = correct;
		//triggerTime = time;
	}


	public string getAnswer (int ID) {
		return answers [ID];
	}

	public int getCorrectAnswer () {
		return this.correctAnswer;
	}

	public float getTime () {
		return this.triggerTime;
	}

	public void disableTime () {
		this.triggerTime = 9999999;
	}
}