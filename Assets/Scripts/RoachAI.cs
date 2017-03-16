using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoachAI : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () 
	{

		 
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.gameObject == player)
		{
			print ("trigger");

			Rigidbody rb =  this.GetComponent<Rigidbody> ();
			Vector3 tempVector = player.transform.position - this.GetComponent<Transform> ().position; 
			tempVector.y = 0;
			rb.AddForce (-tempVector * -10);
		}
	}
}
