using UnityEngine;
using System.Collections;

public class CircuitLight : MonoBehaviour {

	Vector3 startPos;
	Vector3 endPos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// If target is reached
		if (transform.position - endPos > Vector3.zero) {
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
