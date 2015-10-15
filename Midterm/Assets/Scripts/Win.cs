using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	public ParticleSystem particleCannon;

	// Use this for initialization
	void Start () {
		particleCannon.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		particleCannon.Play();
	}
}
