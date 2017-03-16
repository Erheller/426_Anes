using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {

	public GameObject boss;
	public Transform[] spawns;
	// Use this for initialization
	void Start () {
		Instantiate (boss, spawns [0].position, spawns [0].rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
