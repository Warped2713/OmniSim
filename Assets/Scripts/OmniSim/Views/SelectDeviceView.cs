using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

using OmniSim.Models;

namespace OmniSim.Views {

	public class SelectDeviceView : ViewController {

		public int startDistance = 50;
		public int menuRadius = 60;
		public int numDevices = 8; // TODO get number of devices from data file

		private float theta = 0;
		private Vector3 campos;

		// Extension from parent ViewController; called right after the scene is loaded
		public override void onInitScene () {
			base.onInitScene ();
		}
		public override void onReloadScene () {
			base.onReloadScene ();
		}
		public override void onLoadScene (OmniSim.Game game) {
			base.onLoadScene (game);
		}
		public override void onUnloadScene () {
			base.onUnloadScene ();
		}


		// Use this for initialization
		void Start () {

			// Initialize numDevices from GlobalVars
			this.numDevices = base.game.getData ().devices.Count;

			#region	[GENERATE DEVICES] 
			// Generate all the device objects and place them evenly around a point Z units in front of the main scene camera

			// Get the main camera position
			this.campos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;

			// Calculate angle for equally distributing devices around a point
			this.theta = 2 * Mathf.PI / this.numDevices;
			// Adjust angle to ensure "front" is the 0 on the unit circle of the XZ plane
			float angleAdj = Mathf.PI / -2;

			// Generate a device model for each device in GlobalVars and position it evenly around a point startDistance in front of the camera position
			foreach( KeyValuePair<string, Device> kvpDevice in base.game.getData ().devices ) {

				int i = base.game.getData ().devices.IndexOfKey(kvpDevice.Key);
				Device device = kvpDevice.Value;

				// Initialize the device's model using its prefab name
				string prefabFilepath = "Prefabs/Devices/" + device.PrefabFilename;
				device.Model = Instantiate (Resources.Load(prefabFilepath, typeof(GameObject)), base.containerObj) as GameObject;

				Vector3 pos = new Vector3 (0f, 0f, 0f);
				// X component around the XZ plane circle
				pos.x = device.Model.transform.position.x + 0 + this.menuRadius * Mathf.Cos( i * this.theta + angleAdj);
				// Center the device on the y axis in front of camera
				pos.y = device.Model.transform.position.y + device.Model.transform.localScale.y / 2 + this.campos.y;
				// Z component around the XZ plane circle
				pos.z = device.Model.transform.position.z + (this.startDistance + this.menuRadius) + this.menuRadius * Mathf.Sin( i * this.theta + angleAdj);

				device.Model.transform.position = pos;
				//print (pos.ToString () + "; " + i.ToString() );

				// Rotate the object so that it faces outwards from the center of the device ring
				Vector3 axis = new Vector3 (0f, 1f, 0f);
				device.Model.transform.RotateAround( device.Model.transform.position, axis, i * -360 / this.numDevices);
			}
			#endregion

			UpdateDeviceTexts ();

			// Load the current device as the frontmost option in the ring (if the currentDevice is already set)
			if (base.game.getData ().currentDevice > 0) {
				PreRotateDeviceRing ( base.game.getData ().currentDevice );
			} else {
				base.game.getData ().currentDevice = 0;
				base.game.getData ().currentAlien = -1;
				base.game.getData ().currentPreset = "None";
			}
		}

		// Update is called once per frame
		void Update () {

		}

		public void PreRotateDeviceRing( int dir ) {
			foreach( KeyValuePair<string, Device> kvpDevice in base.game.getData ().devices ) {
				Device device = kvpDevice.Value;

				Vector3 centerPoint = new Vector3 ( 0f, this.campos.y, this.startDistance + this.menuRadius );
				Vector3 axis = new Vector3 (0f, 1f, 0f);

				device.Model.transform.RotateAround( centerPoint, axis, Mathf.Rad2Deg * this.theta * dir);
			}
		}

		public void RotateDeviceRing( int dir ) {
			PreRotateDeviceRing( dir );

			// Update current device index
			//print ("Old: " + GlobalVars.Instance.currentDevice.ToString() );
			base.game.getData ().currentDevice += dir;
			if (base.game.getData ().currentDevice == -1) {
				base.game.getData ().currentDevice = this.numDevices - 1;
			}
			else if (base.game.getData ().currentDevice == this.numDevices) {
				base.game.getData ().currentDevice = 0;
			}
			//print ("+ Dir " + dir.ToString() + " : " + GlobalVars.Instance.currentDevice.ToString() );
			UpdateDeviceTexts ();
		}

		public void UpdateDeviceTexts( ) {
			Text dName = GameObject.Find("DeviceName").GetComponent<Text>();
			Text dDesc = GameObject.Find("DeviceDesc").GetComponent<Text>();
			Device current = base.game.getData ().getCurrentDevice ();
			dName.text = current.DeviceName;
			dDesc.text = current.Description;
		}

	}

}
