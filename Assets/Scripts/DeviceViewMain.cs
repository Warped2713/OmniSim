using UnityEngine;
using System.Collections;

public class DeviceViewMain : MonoBehaviour {

	public float distanceToCamera;

	private Device device;
	private Vector3 initDevicePos;

	// Use this for initialization
	void Start () {

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
}
