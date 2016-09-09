using UnityEngine;
using System.Collections;

public class Device : MonoBehaviour {

	int id;
	string name;
	string series;
	string description;
	string defaultPreset;
	GameObject model;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Device ()
	{
		this.ID = 0;
		this.DeviceName = "";
		this.Series = "";
		this.Description = "";
		this.DefaultPreset = "";
		this.model = null;
	}

	public Device (int id, string name, string series, string description, string defaultPreset)
	{
		this.ID = id;
		this.DeviceName = name;
		this.Series = series;
		this.Description = description;
		this.DefaultPreset = defaultPreset;
		this.model = null;
	}
	

	public int ID {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}

	public string DeviceName {
		get {
			return this.name;
		}
		set {
			name = value.Trim();
		}
	}

	public string Series {
		get {
			return this.series;
		}
		set {
			series = value.Trim();
		}
	}

	public string Description {
		get {
			return this.description;
		}
		set {
			description = value.Trim();
		}
	}

	public string DefaultPreset {
		get {
			return this.defaultPreset;
		}
		set {
			defaultPreset = value.Trim();
		}
	}
}
