using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OmniSim {

	public class Game: MonoBehaviour {

		public static Game Instance{ set; get; }

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

		public Scenes currentSceneType;

		// On first load
		void Awake() {
			Instance = this;

			// Initialize data

			// Initialize managers
			this.sceneManager.setGame(this);


		}

		// Use this for initialization
		void Start () {			
			// Load initial scene
			sceneManager.Load ( (int)this.currentSceneType );
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}

}
