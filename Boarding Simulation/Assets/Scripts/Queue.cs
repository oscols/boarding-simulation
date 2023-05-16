using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Queue : MonoBehaviour {

	internal List<Agent> agents;
	internal int numOfAgents;
	internal float timer;
	internal bool calcTime;

	// Use this for initialization
	void Start () {
        agents = new List<Agent>();
		numOfAgents = 0;
		timer = 0;
		calcTime = false;
		UpdateStats();
	}
	
	void UpdateStats () {
		Debug.Log(numOfAgents + " entered, " + GetRemaining() + " remaining, " + timer + "s passed");
	}

	int GetRemaining() {
		return 72 - (numOfAgents - agents.Count);
	}

	// Update is called once per frame
	void Update () {
		if(agents.Count > 0){
			 foreach (Agent agent in agents.ToList()) {
				if(agent == null) {
					agents.Remove(agent);
					UpdateStats();
				}
			}
		}

		if(calcTime) {
			if(GetRemaining() == 0) {
				calcTime = false;
				Debug.Log("Timer stopped! All agents have found their seats!");
				Debug.Log("Time taken: " + timer);
			} else {
				timer += Time.deltaTime;

				for(int i = 1; i < agents.Count; i++) {
					if((agents[i-1].stop || agents[i-1].tempStop) && Vector3.Distance(agents[i-1].gameObject.transform.position, agents[i].gameObject.transform.position) < 3) {
						agents[i].tempStop = true;
					} else {
						agents[i].tempStop = false;
					}
				}
			}
		}

		// we can now check if an agent is stopped through agents which contains all agents in order
		// we can then tell each agent after the one stopped to also stop
	}

	void OnTriggerEnter(Collider other) {
		if(!calcTime) {
			calcTime = true; // Start Timer
			Debug.Log("Timer Started!");
		}
		numOfAgents++;
		agents.Add(other.GetComponent<Agent>());
		UpdateStats();
	}

}
