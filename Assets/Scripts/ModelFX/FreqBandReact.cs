using UnityEngine;
using System.Collections;

public class FreqBandReact : MonoBehaviour {

	public int band = 0;
	public float multiplier;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("band: " + band + ", freq: " + Mathf.InverseLerp(0.1f, 1.0f, AudioVis.freqBand[band] * 10f).ToString());
		//transform.position = new Vector3( transform.position.x, transform.position.y, AudioVis.freqBand[band] * 1000f - multiplier);
		this.GetComponent<Light>().range = AudioVis.freqBand[band] * 100f * multiplier;
		if ( this.GetComponent<Light>().range > 20.0f) {
			// TODO spawn a particle in the circuit

		}
	}
}
