﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

	public void SwitchSceneByName (string name) {
		SceneManager.LoadScene (name, LoadSceneMode.Single);
	}

	public void CloseApplication() {
		Application.Quit ();
	}

}
