using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

	int id;
	string name;
	string species;
	string homeworld;
	string description;
	GameObject model;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Alien() {
		this.ID = 0;
		this.AlienName = "";
		this.Species = "";
		this.Homeworld = "";
		this.Description = "";
		this.model = null;
	}

	public Alien (int iD, string name, string species, string homeworld, string description)
	{
		this.ID = iD;
		this.AlienName = name;
		this.Species = species;
		this.Homeworld = homeworld;
		this.Description = description;
		this.model = null;
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

	public string AlienName {
		get {
			return this.name;
		}
		set {
			this.name = value.Trim();
		}
	}

	public string Species {
		get {
			return this.species;
		}
		set {
			this.species = value.Trim();
		}
	}

	public string Homeworld {
		get {
			return this.homeworld;
		}
		set {
			this.homeworld = value.Trim();
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
	#endregion
}
