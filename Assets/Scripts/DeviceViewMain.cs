using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeviceViewMain : MonoBehaviour {

	public float distanceToCamera;

	private Device device;
	private Vector3 initDevicePos;

	private int numAliens;

	// CAUTION: This code will raise NULL REFERENCE ERROR if the preview does not start on TitleMenu (where GlobalVars gets initialized)
	// Use this for initialization
	void Start () {

		this.numAliens = GlobalVars.Instance.getCurrentPreset ().Length;

		// Load in the current device
		this.device = GlobalVars.Instance.getCurrentDevice();
		string prefabFilepath = "Prefabs/Devices/" + this.device.PrefabFilename;
		this.device.Model = Instantiate (Resources.Load(prefabFilepath, typeof(GameObject))) as GameObject;

		// Set the position of model to distanceToCamera from camera position and centered on XY plane
		Vector3 campos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
		this.device.Model.transform.position = this.initDevicePos = new Vector3( campos.x, device.Model.transform.localScale.y / 2 - campos.y, campos.z + this.distanceToCamera );

		// Populate the Presets Tab

		// Populate the Aliens Tab
	}
	
	// Update is called once per frame
	void Update () {
		// Handle camera zoom for when panels are all collapsed/expanded
	}

	public void ChangeCurrentAlien( int dir ) {
		//print ( "Old: " + GlobalVars.Instance.currentAlien );
		GlobalVars.Instance.currentAlien += dir;

		if (GlobalVars.Instance.currentAlien <= -1) {
			GlobalVars.Instance.currentAlien = this.numAliens - 1;
		}
		else if (GlobalVars.Instance.currentAlien >= this.numAliens) {
			GlobalVars.Instance.currentAlien = 0;
		}
		//print ( "+dir: " + GlobalVars.Instance.currentAlien );
		Text alienName = GameObject.Find("CurrentAlien").GetComponent<Text>();
		Alien current = GlobalVars.Instance.getCurrentAlien ();
		alienName.text = current.AlienName;

	}

	public void ResetCurrentAlien() {
		GlobalVars.Instance.currentAlien = -1;
		Text alienName = GameObject.Find("CurrentAlien").GetComponent<Text>();
		alienName.text = "No Alien Selected";
	}
}
