using UnityEngine;
using System.Collections;

public class FreqBandReact : MonoBehaviour {

	public int band = 0;
	public float multiplier;
	public float spikeRange = 0.0f;

	float lastValue = 0.0f;
	float newLightRange = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("band: " + band + ", freq: " + Mathf.InverseLerp(0.1f, 1.0f, AudioVis.freqBand[band] * 10f).ToString());
		//transform.position = new Vector3( transform.position.x, transform.position.y, AudioVis.freqBand[band] * 1000f - multiplier);

		newLightRange = AudioVis.freqBand[band] * 100f * multiplier;

		// Only update the light if the difference between updates is large enough for a spike (drumbeat)
		if ( Mathf.Abs(this.GetComponent<Light>().range - lastValue) > spikeRange ) {
			// TODO spawn a particle in the circuit
			this.GetComponent<Light>().range = newLightRange;
		}

		lastValue = newLightRange;
	}
}
