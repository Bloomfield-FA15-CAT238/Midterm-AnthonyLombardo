using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class flightTrigger : MonoBehaviour {
	public Canvas pickUp;
	bool inZone = false;
	public Light flashLight;
	public GameObject light;
	public GameObject tableStand;
	public GameObject trigger;
	public RawImage flashUI;

	void Start(){
		pickUp.enabled = false;
	}

	void Update() { 
		if (Input.GetKey (KeyCode.E) && inZone == true) {
			flashLight.enabled = true;
			pickUp.enabled = false;
			flashUI.enabled = true;
			Destroy(light);
			Destroy(tableStand);
			Destroy(trigger);
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "FPSController")
			pickUp.enabled = true;
			inZone = true;
	}

	void OnTriggerExit(Collider other) {
		pickUp.enabled = false;
		inZone = false;
	}

}