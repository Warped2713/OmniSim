using UnityEngine;
using System.Collections;

public class Device {
	int id;
	string deviceName;
	string series;
	string description;
	string defaultPreset;
	string prefabFilename;
	GameObject model;

	public Device ()
	{
		this.ID = 0;
		this.DeviceName = "";
		this.Series = "";
		this.Description = "";
		this.DefaultPreset = "";
		this.model = null;
		this.prefabFilename = "";
	}

	public Device (int id, string name, string series, string description, string defaultPreset, string prefabFilename, GameObject model)
	{
		this.ID = id;
		this.DeviceName = name;
		this.Series = series;
		this.Description = description;
		this.DefaultPreset = defaultPreset;
		this.model = model;
		this.prefabFilename = prefabFilename;
	}

	public override string ToString ()
	{
		return string.Format ("[Device: DeviceName={0}, Series={1}, Description={2}, DefaultPreset={3}, PrefabFilename={4}]", DeviceName, Series, Description, DefaultPreset, PrefabFilename);
	}

	#region Getters and Setters
	public int ID {
		get {
			return this.id;
		}
		set {
			this.id = value;
		}
	}

	public string DeviceName {
		get {
			return this.deviceName;
		}
		set {
			this.deviceName = value.Trim();
		}
	}

	public string Series {
		get {
			return this.series;
		}
		set {
			this.series = value.Trim();
		}
	}

	public string Description {
		get {
			return this.description;
		}
		set {
			this.description = value.Trim();
		}
	}

	public string DefaultPreset {
		get {
			return this.defaultPreset;
		}
		set {
			this.defaultPreset = value.Trim();
		}
	}
	public string PrefabFilename {
		get {
			return this.prefabFilename;
		}
		set {
			this.prefabFilename = value.Trim();
		}
	}
	public GameObject Model {
		get {
			return this.model;
		}
		set {
			this.model = value;
		}
	}
	#endregion
}
