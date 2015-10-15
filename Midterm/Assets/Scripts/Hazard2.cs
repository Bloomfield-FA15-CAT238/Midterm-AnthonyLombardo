using UnityEngine;
using System.Collections;

public class Hazard2 : MonoBehaviour {
	public GameController gameControler;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		gameControler.RespawnPlayer();
	}
}
