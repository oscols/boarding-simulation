using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimTimer : MonoBehaviour {

	public float timer;
	public bool calcTime;

	// Use this for initialization
	void Start () {
		timer = 0;
		calcTime = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(calcTime)
			timer += Time.deltaTime;
	}
	
	void OnTriggerEnter(Collider other) {
		if(!calcTime) {
			calcTime = true; // Start Timer
			Debug.Log("Timer Started!");
		}
	}
}
