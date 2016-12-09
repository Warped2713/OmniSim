using UnityEngine;
using System.Collections;

public class PaceAlongAxis : MonoBehaviour {

	public GameObject obj;
	public Vector3 deltaPos = new Vector3( 0.0f, 0.0f, 1.0f );
	public bool doReverse = false;

	Vector3 posOffset = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//posOffset += deltaPos * Time.deltaTime;

		// Use trigonometry to define the speed and size of the motion
		// mulitiplier = A * Cos( B * time ) + D where
		// A is amplitude, which is initialLightRange/2 to control the max/min multiplier values
		// B is 0 < period < 1, which is 2 to make the pulsating happen 2x as fast
		// D is vertical shift, which is 0 to keep positive and negative motion
		if (doReverse) {
			// Use Sin Wave and shift by -pi/2
			posOffset = deltaPos * 0.5f * (Mathf.Sin (2f * Time.timeSinceLevelLoad - Mathf.PI * 0.5f) );
		} else {
			// Use Cos Wave
			posOffset = deltaPos * 0.5f * (Mathf.Cos (2f * Time.timeSinceLevelLoad) );
		}

		obj.GetComponent<Transform>().position += posOffset;
	}
}
