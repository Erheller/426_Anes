using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public float secondsPerDay;
//	public int money;
//	public int day;
//	public bool shopping;
//
	private float secondsLeft;
//
//
//	public Text UI_day;
//	public Text UI_money;
//	public Text UI_reg;
//	public Text UI_org;
//	public Text UI_ost;
//	public Text UI_rot;
//	public Text UI_time;
//
//
//	//public PlayerController playerObject; 
	public UIManager UIController;
//
//
//	public int egg0cost = 20;
//	public int egg1cost = 50;
//	public int egg2cost = 100;
//	public int egg3cost = 120;
//
//	public int eggsPerBuy = 5;
//
//
//	//Use this for initialization
	void Start () {
//
		this.secondsPerDay = 60;	//change this for final release!
//		//this.money = 100;			//and this!
//		this.day = 0;
//		this.shopping = true;
//		this.secondsLeft = 0;
//
		DontDestroyOnLoad (this);

//
//
//
//
//		this.updateUI ();
//
	}
//
//	void updateUI() {
//float tempTime = Mathf.Round (this.secondsLeft * 100f) / 100f;
//		UI_day.text = "Day: " + this.day.ToString ();
//		UI_money.text = "ANARCHY POINTS: " + this.money.ToString ();
//		UI_reg.text = "Regular Eggs: " + playerObject.getNumEggs (0).ToString ();
//		UI_org.text = "Organic Eggs: " + playerObject.getNumEggs (1).ToString ();
//		UI_ost.text = "Ostrich Eggs: " + playerObject.getNumEggs (2).ToString ();
//		UI_rot.text = "Rotten Eggs: " + playerObject.getNumEggs (3).ToString ();
//		//UI_time.text = "Time: " + this.secondsLeft.ToString ();
//		UI_time.text = "Time: " + tempTime.ToString ();
//
//		int tempIndex = playerObject.getIndex ();
//		UI_reg.color = Color.black;
//		UI_org.color = Color.black;
//		UI_ost.color = Color.black;
//		UI_rot.color = Color.black;
//		switch (tempIndex) {
//		case 0:
//			UI_reg.color = Color.blue;
//			break;
//		case 1:
//			UI_org.color = Color.blue;
//			break;
//		case 2:
//			UI_ost.color = Color.blue;
//			break;
//		case 3:
//			UI_rot.color = Color.blue;
//			break;
//		}
//	}
//
//	public void addScore(int toAdd) {
//		this.money += toAdd;
//	}
//
//	public void buyEgg0() {
//		if (this.money < this.egg0cost)
//			return;
//
//		this.money -= this.egg0cost;
//		playerObject.addEgg (0, eggsPerBuy);
//	}
//
//	public void buyEgg1() {
//		if (this.money < this.egg1cost)
//			return;
//
//		this.money -= this.egg1cost;
//		playerObject.addEgg (1, eggsPerBuy);
//	}
//
//	public void buyEgg2() {
//		if (this.money < this.egg2cost)
//			return;
//
//		this.money -= this.egg2cost;
//		playerObject.addEgg (2, eggsPerBuy);
//	}
//
//	public void buyEgg3() {
//		if (this.money < this.egg3cost)
//			return;
//
//		this.money -= this.egg3cost;
//		playerObject.addEgg (3, eggsPerBuy);
//	}
//
//	public void nextDay() {
//		this.secondsLeft = this.secondsPerDay;
//		this.shopping = false;
//		this.day += 1;
//		UIController.hidePaused();
//	}
//
//	// Update is called once per frame
//	void Update () {
//		/*
//		if (this.secondsLeft >= 0)
//			this.shopping = false;
//		else
//			this.shopping = true;
//		*/
//
//
//		if (shopping == false) {
//			this.secondsLeft -= Time.deltaTime;
//			if (this.secondsLeft <= 0) {
//				secondsLeft = 0;
//				this.shopping = true;
//				UIController.showPaused ();
//
//
//				/*
//				 * 
//				 * KILL
//				 * ALL
//				 * ENEMIES
//				 * 
//				 * 
//				 * /
//				*/
//				//DestroyObject(GC1.gameObject);
//				//DestroyObject(GC2.gameObject);
//				//DestroyObject(GC3.gameObject);
//			}
//		}
//
//		this.updateUI ();
//
//
//
//		//if time is less than zero, go shop
//		if (this.secondsLeft <= 0) {
//			this.shopping = true;
//		}
//
//		//not shopping, playing game
//		if (this.shopping == false) {
//			this.secondsLeft -= Time.deltaTime;
//
//		}
//	}


}
