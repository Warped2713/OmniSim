using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OmniSim;

namespace OmniSim.Views {

	public class ViewController : MonoBehaviour {
		
		public Game.Scenes sceneType;
		public string BGM_Name;
		public bool hasSoloBGM = false;
		public bool restartBGM = false;

		public Transform containerObj;

		protected Game game;
		private bool wasLoadedBefore = false;

		// Use this for initialization
		void Start () {
			if (this.game == null) { // In the event that Game is not initialized, set stuff up here
				// Load the master scene
				UnityEngine.SceneManagement.SceneManager.LoadScene (0, UnityEngine.SceneManagement.LoadSceneMode.Single);
			}
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		// When loaded for the first time, initialize state
		public virtual  void onInitScene()
		{
			
		}

		// When reloaded, initialize to the previously saved state
		public virtual void onReloadScene()
		{

		}

		public virtual void onLoadScene(Game game)
		{
			this.game = game;
			if (this.wasLoadedBefore) {
				this.onReloadScene();

			} else {
				this.onInitScene();
				this.wasLoadedBefore = true;
			}
			this.game.audioManager.PlayAudio (this.BGM_Name, this.hasSoloBGM, this.restartBGM);
		}

		// When unloaded, save state
		public virtual void onUnloadScene()
		{
			
		}

		// Switch to the specified scene
		public void SwitchScene (int scene) {  // TODO: change the param to be of type Game.Scenes when Unity finally supports enum params
			this.game.sceneManager.Unload ( (int)this.sceneType );
			this.game.sceneManager.Load ( scene );
		}

		public void CloseApplication() {
			Application.Quit ();
		}
	}

}