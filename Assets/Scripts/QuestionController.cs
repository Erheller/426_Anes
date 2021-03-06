﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionController : MonoBehaviour {

	public GameObject movie;

	MoviePlayer mp;

	public GameObject button0;
	public GameObject button1;
	public GameObject button2;
	public GameObject button3;

	public int correct;

	Question [] qArray;

	public Text actualQuestion;
	public TextMeshProUGUI resultText;
	private float resultTimer;

	void Awake () {
		this.hideQuestions ();

		qArray = new Question[5];



		qArray [0] = new Question ("There is no pulse. What do you do?", "Advanced Airway treatement", "Treat with Amiodarone", "Continue chest compressions and shock with AED", "Administer morphine", 2, 62);
		qArray [1] = new Question ("The baby weighs 14 kilos. How many joules should you set the defibrilator to?", "56 J", "14 J", "10 J", "28 J", 3, 100);
		qArray [2] = new Question ("The patient is suffering from hypovolemia. Which one of these in IV fluid cannot be used to treat it?", "Insulin and dextrose", "Sodium Chloride", "Calcium gluninate", "Albumin", 1, 205);
		qArray [3] = new Question ("Second defibrilation. How many joules will you set the defibrilator to?", "7 J", "14 J", "28 J", "40 J", 3, 259); 
		qArray [4] = new Question ("Is there anything else you would like to administer?", "Solids", "Fluids", "More epinephrine", "Nothing", 1, 282);
		this.resultTimer = 0;
	}

	// Use this for initialization
	void Start () {
		mp = movie.GetComponent<MoviePlayer> ();
		mp.Play ();

		this.hideQuestions ();

		//changeQuestionText ("Do this", "Do that", "Don't do anything", "Help, I'm stuck on this project");
		//correct = 2;

		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		this.hideQuestions ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Question q in qArray) {
			if (MoviePlayer.timeElapsed >= q.getTime ()) {
				this.activateQuestion (q);
			}
		}

		if (resultTimer > MoviePlayer.timeElapsed) {
			resultText.enabled = true;
		} else {
			resultText.enabled = false;
		}
	}

	void activateQuestion (Question q) {
		mp.Pause ();
		this.changeQuestionText (q);
		this.correct = q.getCorrectAnswer ();
		print (q.getCorrectAnswer ().ToString ());
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

	void changeQuestionText (Question q) {
		button0.GetComponentInChildren<Text> ().text = q.getAnswer (0);
		button1.GetComponentInChildren<Text> ().text = q.getAnswer (1);
		button2.GetComponentInChildren<Text> ().text = q.getAnswer (2);
		button3.GetComponentInChildren<Text> ().text = q.getAnswer (3);

		actualQuestion.text = q.questionText;
	}


	void correctAnswer () {
		print ("Correct!");
		mp.Play ();
		this.hideQuestions ();

		resultText.text = "Correct!";
		resultTimer = MoviePlayer.timeElapsed + 2;
	}

	void incorrectAnswer () {
		print ("Incorrect!");

		mp.Play ();
		this.hideQuestions ();

		resultText.text = "Inorrect...";
		resultTimer = MoviePlayer.timeElapsed + 2;

	}

	public void option0 () {
		if (correct == 0)
			correctAnswer ();
		else
			this.incorrectAnswer ();
	}


	public void option1 () {
		if (correct == 1)
			this.correctAnswer ();
		else
			this.incorrectAnswer ();
	}	

	public void option2 () {
		if (correct == 2)
			this.correctAnswer ();
		else
			this.incorrectAnswer ();
	}	

	public void option3 () {
		//this.loadVegas ();

		if (correct == 3)
			this.correctAnswer ();
		else
			this.incorrectAnswer ();
	}

	public void loadVegas () {
		foreach (GameObject o in GameObject.FindGameObjectsWithTag("MovieSphere")) {
			Destroy (o);
		}

		movie = (GameObject)Instantiate (Resources.Load ("LasVegasMovie"));
	}

}


class Question {
	public string questionText;
	string [] answers = new string[4];
	int correctAnswer;

	float triggerTime;

	public Question (string q, string a0, string a1, string a2, string a3, int correct, float time) {
		questionText = q;
		answers [0] = a0;
		answers [1] = a1;
		answers [2] = a2;
		answers [3] = a3;
		correctAnswer = correct;
		triggerTime = time;
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