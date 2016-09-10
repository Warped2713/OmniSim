using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlienViewMain : MonoBehaviour {

	public float positionX;
	public float positionY;
	public float positionZ;

	private Alien alien;

	// Use this for initialization
	void Start () {

		this.alien = GlobalVars.Instance.getCurrentAlien ();

		// Load Alien Model
		this.alien = GlobalVars.Instance.getCurrentAlien();
		string prefabFilepath = "Prefabs/Aliens/" + this.alien.PrefabFilename;
		this.alien.Model = Instantiate (Resources.Load(prefabFilepath, typeof(GameObject))) as GameObject;

		// Set the position of model 
		//Vector3 campos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
		//this.device.Model.transform.position = this.initDevicePos = new Vector3( this.positionX, this.positionY, this.positionZ );


		// Initialize Text Fields
		Text alienName = GameObject.Find("AlienName").GetComponent<Text>();
		alienName.text = this.alien.AlienName;
		Text alienS = GameObject.Find("AlienSpecies").GetComponent<Text>();
		alienS.text = this.alien.Species;
		Text alienH = GameObject.Find("AlienHome").GetComponent<Text>();
		alienH.text = this.alien.Homeworld;
		Text alienD = GameObject.Find("AlienDescription").GetComponent<Text>();
		alienD.text = this.alien.Description;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetModeTimeOut() {
		GlobalVars.Instance.currentMode = "TimeOut";
	}
}
