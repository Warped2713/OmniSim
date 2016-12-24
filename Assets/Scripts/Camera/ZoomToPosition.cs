using UnityEngine;
using System.Collections;

public class ZoomToPosition : MonoBehaviour {

	public Vector3 targetPosition = Vector3.zero;
	public float minDistance = 5f;
	public float stepDistance = 2f;

	float distanceRemaining = 0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		distanceRemaining = Vector3.Distance(transform.position, targetPosition);

		if ( distanceRemaining > minDistance + stepDistance ) {
			Vector3.MoveTowards (transform.position, targetPosition, stepDistance);
		}

	}
}
