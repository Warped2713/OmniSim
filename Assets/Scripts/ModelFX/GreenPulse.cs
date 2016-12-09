using UnityEngine;
using System.Collections;

public class GreenPulse : MonoBehaviour {

	public GameObject pulseLight;
	public float initialLightRange = 10f;
	public bool doReverse = false;


	// Use this for initialization
	void Start () {
		//initialLightRange = pulseLight.GetComponent<Light> ().range;
	}
	
	// Update is called once per frame
	void Update () {
		// Pulsate the light by modifying the light range based on timeSinceLevelLoad

		float lightRange = pulseLight.GetComponent<Light> ().range;

		// Use trigonometry to define the speed and size of the pulse
		// mulitiplier = A * Cos( B * time ) + D where
		// A is amplitude, which is initialLightRange/2 to control the max/min multiplier values
		// B is 0 < period < 1, which is 2 to make the pulsating happen 2x as fast
		// D is vertical shift, which is defaulted to 10 to make sure the multiplier stays a fair amount above 0
		if (doReverse) {
			// Use Sin Wave and shift by -pi/2
			lightRange = initialLightRange * 0.5f * (Mathf.Sin (2f * Time.timeSinceLevelLoad - Mathf.PI * 0.5f) + 2f);
		} else {
			// Use Cos Wave
			lightRange = initialLightRange * 0.5f * (Mathf.Cos (2f * Time.timeSinceLevelLoad) + 2f);
		}

		pulseLight.GetComponent<Light> ().range = lightRange;
	}
}
