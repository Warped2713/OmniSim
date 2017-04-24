using UnityEngine;
using UnityEngine.UI;

using System.Collections;

using OmniSim.Models;

namespace OmniSim.Views {
	
	public class AlienView : ViewController {

		public float positionX;
		public float positionY;
		public float positionZ;

		public Vector3 initRotation;

		private Alien alien;

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

			this.alien = base.game.getData ().getCurrentAlien ();

			// Load Alien Model
			this.alien = base.game.getData ().getCurrentAlien();
			string prefabFilepath = "Prefabs/Aliens/" + this.alien.PrefabFilename;
			this.alien.Model = Instantiate (Resources.Load(prefabFilepath, typeof(GameObject))) as GameObject;

			// Set the position of model 
			//Vector3 campos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
			//this.device.Model.transform.position = this.initDevicePos = new Vector3( this.positionX, this.positionY, this.positionZ );
			this.alien.Model.transform.position = new Vector3( this.alien.Model.transform.position.x + this.positionX, this.alien.Model.transform.position.y + this.positionY, this.alien.Model.transform.position.z + this.positionZ );
			this.alien.Model.transform.Rotate(initRotation);

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
			base.game.getData ().currentMode = "TimeOut";
		}

	}

}