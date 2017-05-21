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

		// Game Data (formerly from a GlobalVars singleton)
		public string deviceCSV;
		public string alienCSV;
		public string presetCSV;
		public string defaultColorJSON;
		public string customColorJSON;

		public int maxColorSlots = 50; // 256px / 5px = 51
		public int maxColorSchemes = 50; // 256px / 5px = 51


		private OmniSim.GameData data;

		// On first load
		void Awake() {
			Instance = this;

			// Initialize data
			this.data = new OmniSim.GameData( deviceCSV, alienCSV, presetCSV, defaultColorJSON, customColorJSON, maxColorSlots, maxColorSchemes );

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

		public OmniSim.GameData getData() {
			return this.data;
		}
	}

}
