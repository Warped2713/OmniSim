using UnityEngine;
using System.Collections;

public class TitleMenuMain : MonoBehaviour {

	public string deviceCSV;
	public string alienCSV;
	public string presetCSV;

	// Preloader stuff
	void Awake() {
		// Initialize the global variables
		GlobalVars.Instance.initializeData( deviceCSV, alienCSV, presetCSV );
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
