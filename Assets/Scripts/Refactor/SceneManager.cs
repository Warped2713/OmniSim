using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OmniSim {

	public class SceneManager : MonoBehaviour {

		public static SceneManager Instance{ set; get; }

		private void Awake()
		{
			Instance = this;
		}

		public void Load( int sceneID )
		{
			if (!UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex (sceneID).isLoaded) {
				UnityEngine.SceneManagement.SceneManager.LoadScene (sceneID, UnityEngine.SceneManagement.LoadSceneMode.Additive);
			}
		}

		public void Unload( int sceneID )
		{
			if (UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex (sceneID).isLoaded) {
				UnityEngine.SceneManagement.SceneManager.UnloadScene (sceneID);
			}
		}
	}
}