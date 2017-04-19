using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmniSim;

namespace OmniSim.Views {

	public class ViewController : MonoBehaviour {
		
		public OmniSim.Game.Scenes sceneType;
		public string BGM_Name;
		public bool hasSoloBGM = false;
		public bool restartBGM = false;

		private OmniSim.Game game;
		private bool wasLoadedBefore = false;

		// Use this for initialization
		void Start () {
			//this.game.audioManager.PlayAudio (this.BGM_Name);
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		// When loaded for the first time, initialize state
		public void onInitScene()
		{
			
		}

		// When reloaded, initialize to the previously saved state
		public void onReloadScene()
		{

		}

		public void onLoadScene(OmniSim.Game game)
		{
			this.game = game;
			if (this.wasLoadedBefore) {
				this.onReloadScene();

			} else {
				this.onInitScene();
			}
			this.game.audioManager.PlayAudio (this.BGM_Name, this.hasSoloBGM, this.restartBGM);
		}

		// When unloaded, save state
		public void onUnloadScene()
		{
			
		}
	}

}