using UnityEngine;
using System.Collections;

public class CircuitLight : MonoBehaviour {

	Vector3 startPos;
	Vector3 endPos;

	Vector3 diffPos;

	// Use this for initialization
	void Start () {
		diffPos = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

		diffPos = transform.position - endPos;

		// If target is reached
		if (diffPos.magnitude > 0.0f) {
			// Reset position
			transform.position = startPos;
			// TODO: Turn light off

			// TODO: Return to queue
		} else {
			// TODO: Keep moving toward the target
		}
	}

	void setLightPath ( Vector3 start, Vector3 end ) {
		this.startPos = start;
		this.endPos = end;
	}

}
