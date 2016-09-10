using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeviceViewMain : MonoBehaviour {

	public float distanceToCamera;

	private Device device;
	private Vector3 initDevicePos;

	private int numAliens;
	private int timer;

	// CAUTION: This code will raise NULL REFERENCE ERROR if the preview does not start on TitleMenu (where GlobalVars gets initialized)
	// Use this for initialization
	void Start () {
		
		this.timer = 100;

		if (GlobalVars.Instance.currentMode == "TimeOut") {
			GameObject.Find ("CurrentMode").GetComponent<Text> ().text = "Current Mode: Recharging";
			GameObject.Find ("BtnMode_Reset").GetComponent<Button> ().interactable = true;
			GameObject.Find ("BtnMode_Activate").GetComponent<Button> ().interactable = false;
			GameObject.Find ("BtnMode_TimeOut").GetComponent<Button> ().interactable = false;
			GameObject.Find ("BtnLeft").GetComponent<Button> ().interactable = false;
			GameObject.Find ("BtnRight").GetComponent<Button> ().interactable = false;
			GameObject.Find ("BtnTransform").GetComponent<Button> ().interactable = false;
		}

		//TODO make this related to the button clicks that change mode text
		//GlobalVars.Instance.currentMode = "Idle"; 

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

		// Reset Alien Panel
		ResetCurrentAlien ();
	}
	
	// Update is called once per frame
	void Update () {

		// Handle TimeOut Mode
		if (GlobalVars.Instance.currentMode == "TimeOut") {
			if (this.timer > 0) {
				this.timer--;
				GameObject.Find("CurrentMode").GetComponent<Text>().text = "Current Mode: Recharging... " + this.timer.ToString();
			} else {
				this.timer = 100;
				GlobalVars.Instance.currentMode = "Idle";
				GameObject.Find("CurrentMode").GetComponent<Text>().text = "Current Mode: Idle";
				GameObject.Find ("BtnMode_Reset").GetComponent<Button> ().interactable = false;
				GameObject.Find ("BtnMode_Activate").GetComponent<Button> ().interactable = true;
				GameObject.Find ("BtnMode_TimeOut").GetComponent<Button> ().interactable = true;
			}
		}

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

	public void SetMode(string mode) {
		GlobalVars.Instance.currentMode = mode;
	}
}
