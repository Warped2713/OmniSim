using UnityEngine;
using System.Collections;

public class ZoomToPosition : MonoBehaviour {

	public Vector3 targetPosition = Vector3.zero;
	public float minDistance = 5f;
	public float initialStepDistance = 2f;

	float distanceRemaining = 0f;
	float stepDistance;
	float initialDistance;

	// Use this for initialization
	void Start () {
		stepDistance = initialStepDistance;
		initialDistance = Vector3.Distance(transform.position, targetPosition);
	}
	
	// Update is called once per frame
	void Update () {

		distanceRemaining = Vector3.Distance(transform.position, targetPosition);

		if (distanceRemaining > minDistance + initialStepDistance * 5f) {
			stepDistance = initialStepDistance * (distanceRemaining / initialDistance);
		}

		if ( distanceRemaining > minDistance ) {
			transform.position = Vector3.MoveTowards (transform.position, targetPosition, stepDistance);
		}

	}
}
