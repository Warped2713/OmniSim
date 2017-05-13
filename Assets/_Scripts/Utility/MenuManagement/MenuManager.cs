using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public void TogglePanel (GameObject panel) {
		panel.SetActive ( !panel.activeSelf );
	}

	public void HidePanel (GameObject panel) {
		panel.SetActive ( false );
	}

	public void ShowPanel (GameObject panel) {
		panel.SetActive ( true );
	}

}
