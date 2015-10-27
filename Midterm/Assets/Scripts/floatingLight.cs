using UnityEngine;
using System.Collections;

public class floatingLight : MonoBehaviour {

	public float hover = 10f;

	void OnTriggerStay (Collider other) {
		other.attachedRigidbody.AddForce (Vector3.up * hover, ForceMode.Acceleration);
	}
}
