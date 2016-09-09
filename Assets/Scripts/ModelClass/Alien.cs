using UnityEngine;
using System.Collections;

public class Alien {
	int id;
	string alienName;
	string species;
	string homeworld;
	string description;
	GameObject model;

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

	public override string ToString ()
	{
		return string.Format ("[Alien: ID={0}, AlienName={1}, Species={2}, Homeworld={3}, Description={4}]", ID, AlienName, Species, Homeworld, Description);
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
			return this.alienName;
		}
		set {
			this.alienName = value.Trim();
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
