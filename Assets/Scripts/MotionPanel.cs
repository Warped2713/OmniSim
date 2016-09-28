using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Based on Unity Docs on Vector3.Lerp
[RequireComponent(typeof(RectTransform))]
public class MotionPanel : MonoBehaviour {

	private Transform startMarker;
	private Transform endMarker;

	public enum SideEnum{ Left, Right, Top, Bottom };
	public SideEnum side = SideEnum.Left;
	public float speed = 1.0F;

	private float startTime;
	private float journeyLength;

	private bool inMotion = false;
	private bool moveForward = true;

	// Use this for initialization
	void Start () {
		startMarker = this.GetComponent<RectTransform> ().transform;
		endMarker = new GameObject().transform;

		float width = this.GetComponent<RectTransform> ().rect.width;
		float height = this.GetComponent<RectTransform> ().rect.height;

		// Calculate what the (offscreen) endmarker should be
		switch (side) {
			default:
			case SideEnum.Left:
				endMarker.position = new Vector3 (-startMarker.position.x , startMarker.position.y, startMarker.position.z);
				endMarker.transform.rotation = Quaternion.identity;
				break;

			case SideEnum.Right:
				endMarker.position = new Vector3 (startMarker.position.x, startMarker.position.y, startMarker.position.z);
				endMarker.transform.rotation = Quaternion.identity;
				break;

			case SideEnum.Top:
				endMarker.position = new Vector3 (startMarker.position.x, startMarker.position.y, startMarker.position.z);
				endMarker.transform.rotation = Quaternion.identity;
				break;

			case SideEnum.Bottom:
				endMarker.position = new Vector3 (startMarker.position.x, startMarker.position.y, startMarker.position.z);
				endMarker.transform.rotation = Quaternion.identity;
				break;
		}

		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {

		if ( inMotion ) {
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			// Linearly interpolate the position, either forward or in reverse
			if ( moveForward ) {
				this.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
			} else {
				this.transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fracJourney);
			}
			// Stop moving if we're done
			if ( (moveForward && this.transform.position == endMarker.position) ||
				 (!moveForward && this.transform.position == startMarker.position) ) {
				inMotion = false;
				moveForward = !moveForward;
			}
		}
	}

	// Tell us to move and whether to go from Start-to-End or not
	public void SetInMotion( ) {
		inMotion = true;
	}
}
