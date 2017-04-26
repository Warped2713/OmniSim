using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OmniSim.Behaviors.Camera {

	/* 
	 * This is a behavior that lets the associated camera object move around a fixed transform position
	 * Camera can Zoom In/Out up to min/max zoom
	 * Camera can Pan Left/Right/Up/Down within fixed bounds
	 * Camera can Orbit Left/Right 360 around given position
	 * Camera can Orbit Up/Down  within fixed view angle 
	*/

	[RequireComponent(typeof(UnityEngine.Camera))]
	public class CameraManipulatorFixedPoint : MonoBehaviour {

		public Transform target;
		public Vector2 ZoomMinMaxFromTarget = new Vector2 (2.0f, 6.0f);
		public Vector2 PanBboxFromTarget = new Vector2 (3.0f, 3.0f);
		public Vector2 VerticalViewAngleMinMax = new Vector2 (-30.0f, 90.0f); // Max Angle below/above horizon
		public float multiplierZoom = 1f;
		public float multiplierPan = 1f;
		public float multiplierRot = 5f;
		public bool orbitHorizBasedOnTarget = false;

		// TODO: consider applying a collider to the camera (and models) so that we don't accidentally pass through

		private Vector3 targetPos = new Vector3 (0f,0f,0f);
		private Vector3 initialPos;
		private Quaternion initialRot;

		// Use this for initialization
		void Start () {
			if (target != null) {
				if (this.target.gameObject.GetComponent<Renderer>() != null) { // try to get the center of the target
					this.targetPos = this.target.gameObject.GetComponent<Renderer>().bounds.center;
				} else {
					this.targetPos = this.target.position;
				}

				// Adjust position to be close to target
				this.transform.LookAt (this.targetPos);
				this.transform.Translate ( new Vector3(0f, 0f, Vector3.Distance (this.targetPos, this.transform.position) - (ZoomMinMaxFromTarget.x + ZoomMinMaxFromTarget.y)/2 ) );
			}

			this.initialPos = this.transform.position;
			this.initialRot = this.transform.rotation;
		}
		
		// Update is called once per frame
		void Update () {

			float distance = Vector3.Distance (this.targetPos, this.transform.position);
			//Debug.Log ( distance );
			// ZOOM
			Vector2 zoom = UnityEngine.Input.mouseScrollDelta;
			if ( zoom.y != 0f && distance-zoom.y*this.multiplierZoom > ZoomMinMaxFromTarget.x && distance-zoom.y*this.multiplierZoom < ZoomMinMaxFromTarget.y) {
				this.transform.Translate ( new Vector3(0f, 0f, zoom.y * this.multiplierZoom) );
			}

			// TODO: clamp pan to bbox

			// PAN X
			float horiz = UnityEngine.Input.GetAxis("Horizontal");
			float mouseX = UnityEngine.Input.GetAxis ("Mouse X");
			if ( horiz != 0f ) {
				this.transform.Translate ( new Vector3(-horiz * this.multiplierPan, 0f, 0f) );
			} else if ( UnityEngine.Input.GetMouseButton(0) && mouseX != 0f ) {
				this.transform.Translate ( new Vector3(-mouseX * this.multiplierPan, 0f, 0f) );
			}

			// PAN Y
			float vert = UnityEngine.Input.GetAxis("Vertical");
			float mouseY = UnityEngine.Input.GetAxis ("Mouse Y");
			if ( vert != 0f ) {
				this.transform.Translate ( new Vector3(0f, -vert * this.multiplierPan, 0f) );
			} else if ( UnityEngine.Input.GetMouseButton(0) && mouseY != 0f ) {
				this.transform.Translate ( new Vector3(0f, -mouseY * this.multiplierPan, 0f) );
			}

			// TODO: clamp orbit to view angle

			// ORBIT
			if ( UnityEngine.Input.GetMouseButton(1) && mouseX != 0f) { // rotate around Y of target or camera based on settings
				if (this.orbitHorizBasedOnTarget) {
					this.transform.RotateAround (targetPos, this.target.up, mouseX * this.multiplierRot);
				} else {
					this.transform.RotateAround (targetPos, this.transform.up, mouseX * this.multiplierRot);
				}
			}
			if ( UnityEngine.Input.GetMouseButton(1) && mouseY != 0f) { // rotate around X of camera
				this.transform.RotateAround (targetPos, this.transform.right, -mouseY * this.multiplierRot);
			}

			// Reset Position and Translation
			if ( UnityEngine.Input.GetKeyDown(KeyCode.R) ) {
				this.transform.position = this.initialPos;
				this.transform.rotation = this.initialRot;
			}

		}
	}

}