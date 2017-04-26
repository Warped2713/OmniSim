using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using OmniSim.Behaviors;
using OmniSim.Models;

namespace OmniSim.Views {

	public class DeviceView : ViewController {

		public float distanceToCamera;

		private Device device;
		private Vector3 initDevicePos;

		private int numAliens;
		private int timer;

		private DeviceAnim animScript;
		private DeviceExtra extraScript;


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

			if (this.game == null) { // In the event that Game is not initialized, set stuff up here
				// Load the master scene
				UnityEngine.SceneManagement.SceneManager.LoadScene (0, UnityEngine.SceneManagement.LoadSceneMode.Single);
				return;
			}

			this.timer = 100;

			if (base.game.getData ().currentMode == "TimeOut") {
				GameObject.Find ("CurrentMode").GetComponent<Text> ().text = "Current Mode: Recharging";
				GameObject.Find ("BtnMode_Reset").GetComponent<Button> ().interactable = true;
				GameObject.Find ("BtnMode_Activate").GetComponent<Button> ().interactable = false;
				GameObject.Find ("BtnMode_TimeOut").GetComponent<Button> ().interactable = false;
				GameObject.Find ("BtnLeft").GetComponent<Button> ().interactable = false;
				GameObject.Find ("BtnRight").GetComponent<Button> ().interactable = false;
				GameObject.Find ("BtnTransform").GetComponent<Button> ().interactable = false;
			}

			//TODO make this related to the button clicks that change mode text
			//GlobalVars.Instance.currentMode = "Idle"; 

			this.numAliens = base.game.getData ().getCurrentPreset ().Length;

			// Load in the current device
			this.device = base.game.getData ().getCurrentDevice();
			string prefabFilepath = "Prefabs/Devices/Colorized/" + this.device.PrefabFilename;
			Object dmod = Resources.Load(prefabFilepath, typeof(GameObject));
			if ( !dmod ) {
				prefabFilepath = "Prefabs/Devices/" + this.device.PrefabFilename;
				dmod = Resources.Load(prefabFilepath, typeof(GameObject));
			}
			this.device.Model = Instantiate (dmod, base.containerObj) as GameObject;

			// Set the position of model to distanceToCamera from camera position and centered on XY plane
			Vector3 campos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
			this.device.Model.transform.position = this.initDevicePos = new Vector3( campos.x, device.Model.transform.localScale.y / 2 - campos.y, campos.z + this.distanceToCamera );

			// Set rotation
			if ( this.device.Model.GetComponent<DeviceExtra>() ) {
				this.extraScript = this.device.Model.GetComponent<DeviceExtra>();
				extraScript.resetToViewRotation ();
			}

			// Set as the target of the camera manipulator
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<OmniSim.Behaviors.Camera.CameraManipulatorFixedPoint>().target = this.device.Model.transform;

			// Set color scheme
			if ( this.device.Model.GetComponent<DeviceAnim>() ) {
				this.animScript = this.device.Model.GetComponent<DeviceAnim>();
				animScript.setColorScheme(1);

				// Populate Colors Tab
				GameObject btnA = GameObject.Find("Canvas/CustomizePanel/Tab_ChangeColor/Btn_Color_A");
				btnA.GetComponent<Button>().onClick.AddListener ( delegate { animScript.setColorScheme (1); } );
				btnA.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0.2f, 0.8f);

				GameObject btnB = GameObject.Find("Canvas/CustomizePanel/Tab_ChangeColor/Btn_Color_B");
				btnB.GetComponent<Button>().onClick.AddListener ( delegate { animScript.setColorScheme (2); } );
				btnB.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0.4f, 0.8f);

				GameObject btnC = GameObject.Find("Canvas/CustomizePanel/Tab_ChangeColor/Btn_Color_C");
				btnC.GetComponent<Button>().onClick.AddListener ( delegate { animScript.setColorScheme (3); } );
				btnC.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0.6f, 0.8f);

				GameObject btnD = GameObject.Find("Canvas/CustomizePanel/Tab_ChangeColor/Btn_Color_D");
				btnD.GetComponent<Button>().onClick.AddListener ( delegate { animScript.setColorScheme (4); } );
				btnD.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0.8f, 0.8f);

				GameObject btnE = GameObject.Find("Canvas/CustomizePanel/Tab_ChangeColor/Btn_Color_E");
				btnE.GetComponent<Button>().onClick.AddListener ( delegate { animScript.setColorScheme (5); } );
				btnE.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0.0f, 0.6f);

				GameObject btnF = GameObject.Find("Canvas/CustomizePanel/Tab_ChangeColor/Btn_Color_F");
				btnF.GetComponent<Button>().onClick.AddListener ( delegate { animScript.setColorScheme (6); } );
				btnF.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0.2f, 0.6f);

				GameObject btnG = GameObject.Find("Canvas/CustomizePanel/Tab_ChangeColor/Btn_Color_G");
				btnG.GetComponent<Button>().onClick.AddListener ( delegate { animScript.setColorScheme (11); } );
				btnG.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0.2f, 0.4f);

				GameObject btnH = GameObject.Find("Canvas/CustomizePanel/Tab_ChangeColor/Btn_Color_H");
				btnH.GetComponent<Button>().onClick.AddListener ( delegate { animScript.setColorScheme (14); } );
				btnH.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0.8f, 0.4f);

				GameObject btnI = GameObject.Find("Canvas/CustomizePanel/Tab_ChangeColor/Btn_Color_I");
				btnI.GetComponent<Button>().onClick.AddListener ( delegate { animScript.setColorScheme (20); } );
				btnI.GetComponentInChildren<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0.0f, 0.0f);
			}

			// Populate the Presets Tab

			// Populate the Aliens Tab

			// Reset Alien Panel
			ResetCurrentAlien ();
		}

		// Update is called once per frame
		void Update () {
			
			// Handle TimeOut Mode
			if (base.game != null && base.game.getData ().currentMode == "TimeOut") {
				if (this.timer > 0) {
					this.timer--;
					GameObject.Find("CurrentMode").GetComponent<Text>().text = "Current Mode: Recharging... " + this.timer.ToString();
				} else {
					this.timer = 100;
					base.game.getData ().currentMode = "Idle";
					GameObject.Find("CurrentMode").GetComponent<Text>().text = "Current Mode: Idle";
					GameObject.Find ("BtnMode_Reset").GetComponent<Button> ().interactable = false;
					GameObject.Find ("BtnMode_Activate").GetComponent<Button> ().interactable = true;
					GameObject.Find ("BtnMode_TimeOut").GetComponent<Button> ().interactable = true;
				}
			}

			// Handle camera zoom for when panels are all collapsed/expanded
		}

		public void ChangeCurrentAlien( int dir ) {
			base.game.getData ().currentAlien += dir;

			if (base.game.getData ().currentAlien <= -1) {
				base.game.getData ().currentAlien = this.numAliens - 1;
			}
			else if (base.game.getData ().currentAlien >= this.numAliens) {
				base.game.getData ().currentAlien = 0;
			}
			Text alienName = GameObject.Find("CurrentAlien").GetComponent<Text>();
			Alien current = base.game.getData ().getCurrentAlien ();
			alienName.text = current.AlienName;
			if (animScript) animScript.setFaceplateAlienTex (current.ID);

		}

		public void ResetCurrentAlien() {
			base.game.getData ().currentAlien = -1;
			Text alienName = GameObject.Find("CurrentAlien").GetComponent<Text>();
			alienName.text = "No Alien Selected";
			if (animScript) animScript.resetFaceplate ();
		}

		public void SetMode(string mode) {
			base.game.getData ().currentMode = mode;
		}

	}

}