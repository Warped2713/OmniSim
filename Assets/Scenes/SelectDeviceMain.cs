using UnityEngine;
using System.Collections;

public class SelectDeviceMain : MonoBehaviour {

	public int startDistance = 50;
	public int menuRadius = 60;
	public int numDevices = 8; // TODO get number of devices from data file

	private float theta = 0;

	// Use this for initialization
	void Start () {

		#region	[GENERATE DEVICES] 
		// Generate all the device objects and place them evenly around a point Z units in front of the main scene camera

		// Get the main camera position
		Vector3 campos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;

		// Calculate angle for equally distributing devices around a point
		theta = 2 * Mathf.PI / numDevices;

		// Generate a device object and position it evenly around a point startDistance in front of the camera position
		for ( int i = 0; i < numDevices; i++  ) {
			GameObject device = Instantiate (Resources.Load("Prefabs/Devices/SampleDevice", typeof(GameObject))) as GameObject;

			Vector3 pos = new Vector3 (0f, 0f, 0f);
			// X component around the XZ plane circle
			pos.x = 0 + menuRadius * Mathf.Cos(i * theta);
			// Center the device on the y axis in front of camera
			pos.y = device.transform.localScale.y / 2 + campos.y;
			// Z component around the XZ plane circle
			pos.z = (startDistance + menuRadius) + menuRadius * Mathf.Sin(i * theta);

			device.transform.position = pos;
			//print (pos.ToString () + "; " + i.ToString() );
		}
		#endregion
		

	}
	
	// Update is called once per frame
	void Update () {

	}
}
