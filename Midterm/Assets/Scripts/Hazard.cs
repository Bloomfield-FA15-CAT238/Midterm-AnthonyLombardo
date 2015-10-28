using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hazard : MonoBehaviour {
	public GameObject respawnPoint;
	public Slider healthBarSlider;
	public Text dead;
	bool startGame;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider other) {
		other.gameObject.transform.position = respawnPoint.transform.position;
			GameController.Instance.timeD += 1;
	} 	

}