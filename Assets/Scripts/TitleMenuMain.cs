using UnityEngine;
using System.Collections;

public class TitleMenuMain : MonoBehaviour {

	public string deviceCSV;
	public string alienCSV;
	public string presetCSV;

	private float initialLightRange;

	// Preloader stuff
	void Awake() {
		// Initialize the global variables
		GlobalVars.Instance.initializeData( deviceCSV, alienCSV, presetCSV );
	}

	// Use this for initialization
	void Start () {
		initialLightRange = GameObject.FindWithTag ("PulsatingLight").GetComponent<Light> ().range;
	}
	
	// Update is called once per frame
	void Update () {

		// Pulsate the light in the device on display
		float lightRange = GameObject.FindWithTag ("PulsatingLight").GetComponent<Light> ().range;
		// mulitiplier = A * Cos( B * time ) + D where
		// A is amplitude, which is initialLightRange/2 to control the max/min multiplier values
		// B is 0 < period < 1, which is 2 to make the pulsating happen 2x as fast
		// D is vertical shift, which is 10 to make sure the multiplier stays a fair amount above 0
		lightRange = initialLightRange * 0.5f * ( Mathf.Cos ( 2f * Time.timeSinceLevelLoad ) + 2f );
		GameObject.FindWithTag ("PulsatingLight").GetComponent<Light> ().range = lightRange;

	}
}
