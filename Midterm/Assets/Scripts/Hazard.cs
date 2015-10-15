using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {
	public GameObject respawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		other.gameObject.transform.position = respawnPoint.transform.position;
	}
}
