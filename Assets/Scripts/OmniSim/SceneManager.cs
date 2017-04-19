﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OmniSim {

	public class SceneManager : MonoBehaviour {

		public static SceneManager Instance{ set; get; }

		delegate void loadedSceneDelegate();
		delegate void unloadedSceneDelegate();

		private OmniSim.Game game;

		private void Awake()
		{
			Instance = this;

			// Set delegates to be notified of load/unload changes
			//this.loadedSceneDelegate = this.DetectLoad;
			//this.unloadedSceneDelegate = this.DetectUnload;
			UnityEngine.SceneManagement.SceneManager.sceneUnloaded += DetectUnload;
			UnityEngine.SceneManagement.SceneManager.sceneLoaded += DetectLoad;
		}

		public void setGame(OmniSim.Game game) 
		{
			this.game = game;
		}

		private void DetectLoad(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode) {
			System.Console.Write ("finished loading");
			//scene.GetRootGameObjects () [0].GetComponent<Views.ViewController> ().onLoadScene (this.game);
		}

		private void DetectUnload(UnityEngine.SceneManagement.Scene scene) {
			System.Console.Write ("finished unloading");
		}

		public void Load( int sceneID )
		{
			UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex (sceneID);

			if (!scene.IsValid() || !scene.isLoaded ) {
				System.Console.Write ("preparing to load");
				UnityEngine.SceneManagement.SceneManager.LoadScene (sceneID, UnityEngine.SceneManagement.LoadSceneMode.Additive);
			}
		}

		public void Unload( int sceneID )
		{
			UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex (sceneID);

			if (scene.isLoaded && scene.IsValid()) {
				//scene.GetRootGameObjects () [0].GetComponent<Views.ViewController> ().onUnloadScene ();
				UnityEngine.SceneManagement.SceneManager.UnloadScene (sceneID);
			}

		}
	}
}