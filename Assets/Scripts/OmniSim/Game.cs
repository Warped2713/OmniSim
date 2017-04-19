using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OmniSim {

	public class Game: MonoBehaviour {

		public static Game Instance{ set; get; }

		//public GameObject sceneManagerObj;
		//public GameObject audioManagerObj;

		public OmniSim.SceneManager sceneManager;
		public OmniSim.AudioManager audioManager;

		// Enumerated Scenes
		public enum Scenes
		{
			Master, 		// 0, this
			Intro, 			// 1, undefined (old title for now)
			TitleMenu, 		// 2 formerly the main scene
			SelectDevice, 	// 3
			DeviceView, 	// 4
			AlienView  		// 5 
		};

		//public string[] viewScenes = new string[6];

		public Scenes currentSceneType;
		public Views.ViewController currentScene;

		// On first load
		void Awake() {
			Instance = this;

			// Initialize data

			// Initialize managers
			this.sceneManager.setGame(this);
			//this.sceneManager = this.sceneManagerObj.GetComponent<OmniSim.SceneManager>();
			//this.audioManager = this.audioManagerObj.GetComponent<OmniSim.AudioManager>();


		}

		// Use this for initialization
		void Start () {			
			// Load initial scene
			sceneManager.Load ( (int)this.currentSceneType );
			// Set current scene
			//this.currentScene = this.sceneManager.GetScene( (int)this.currentSceneType );
			// Start up scene stuff
			//this.currentScene.onInitScene ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}

}
