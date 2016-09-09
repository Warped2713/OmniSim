using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalVars : Singleton<GlobalVars> {

	public Dictionary<string, Device> devices;
	public Dictionary<string, Alien> aliens;
	public Dictionary<string, string[]> alienPresets;


	public void initializeData(string dfile, string afile, string pfile) {
		devices = new Dictionary<string, Device> ();
		aliens = new Dictionary<string, Alien> ();
		alienPresets = new Dictionary<string, string[]> ();
		initializeDeviceData (dfile);
		initializeAlienData (afile);
		initializePresetData (pfile);
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
				d.DefaultPreset = rowData[3].Trim() ;
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
