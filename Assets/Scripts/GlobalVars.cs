using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVars : Singleton<GlobalVars> {

	public SortedList<string, Device> devices;
	public SortedList<string, Alien> aliens;
	public SortedList<string, string[]> alienPresets;

	public int currentDevice;
	public int currentAlien;
	public string currentPreset;
	public string currentMode;

	public void initializeData(string dfile, string afile, string pfile) {
		devices = new SortedList<string, Device> ();
		aliens = new SortedList<string, Alien> ();
		alienPresets = new SortedList<string, string[]> ();
		initializeDeviceData (dfile);
		initializeAlienData (afile);
		initializePresetData (pfile);
		currentDevice = 0;
		currentAlien = -1;
		currentPreset = "None";
		currentMode = "Idle";
	}

	public Device getCurrentDevice() {
		return devices.Values [currentDevice];
	}

	public Alien getCurrentAlien() {
		string nameKey = getCurrentPreset () [currentAlien];
		//print ( "A key: " + nameKey );
		return aliens [nameKey.Trim()];
	}

	public string[] getCurrentPreset() {
		if (currentPreset == "None") {
			string presetKey = getCurrentDevice ().DefaultPreset;
			//print ( "P key: " + presetKey );
			return alienPresets[presetKey];
		} else {
			//print ( "Current P key: " + currentPreset );
			return alienPresets[currentPreset];
		}
	}

	private void initializeDeviceData(string file) {
		string data = System.IO.File.ReadAllText (file);
		string[] rows = data.Split ("\n"[0]);
		for (int i=0; i<rows.Length; i++) {
			if ( !string.IsNullOrEmpty(rows[i]) ) {
				string[] rowData = rows[i].Trim().Split("|"[0]);
				Device d = new Device();
				d.ID = i;
				d.DeviceName = rowData[0].Trim();
				d.Series = rowData[1].Trim();
				d.Description = rowData[2].Trim();
				d.DefaultPreset = rowData[3].Trim();
				d.PrefabFilename = rowData[4].Trim();
				devices.Add(d.DeviceName, d);
				//print ( "Device : " + d.ToString() );
			}
		}
	}

	private void initializeAlienData(string file) {
		string data = System.IO.File.ReadAllText (file);
		string[] rows = data.Split ("\n"[0]);
		for (int i=0; i<rows.Length; i++) {
			if ( !string.IsNullOrEmpty(rows[i]) ) {
				string[] rowData = rows[i].Trim().Split("|"[0]);
				Alien a = new Alien ();
				a.ID = i;
				a.AlienName = rowData [0].Trim ();
				a.Species = rowData [1].Trim ();
				a.Homeworld = rowData [2].Trim ();
				a.Description = rowData [3].Trim ();
				a.PrefabFilename = rowData[4].Trim();
				aliens.Add(a.AlienName, a);
				//print ("Alien : " + a.ToString ());
			}
		}
	}

	private void initializePresetData(string file) {
		string data = System.IO.File.ReadAllText (file);
		string[] rows = data.Split ("\n"[0]);
		for (int i=0; i<rows.Length; i++) {
			if ( !string.IsNullOrEmpty(rows[i]) ) {
				string[] rowData = rows[i].Trim().Split("|"[0]);
				alienPresets.Add( rowData[0].Trim(), rowData[1].Trim().Split(","[0]) );
			}
		}
	}


}
