using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanel : MonoBehaviour {

	public Camera left;
	public Camera right;

	public GameObject sidebarPanel;

	public float dividerClose = 0.9f;
	public float dividerOpen = 0.625f;

	public bool isSideOpen = true;

	// Use this for initialization
	void Start () {
		if (isSideOpen) {
			setDividerPos (dividerOpen);
		} else {
			setDividerPos (dividerClose);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setDividerPos(float divider) {
		left.rect = new Rect (divider - 1f, 0f, 1f, 1f);
		right.rect = new Rect (divider, 0f, 1f - divider, 1f);
	}

	public void closeSidebar() {
		setDividerPos (dividerClose);
		sidebarPanel.SetActive (false);
	}

	public void openSidebar() {
		setDividerPos (dividerOpen);
		sidebarPanel.SetActive (true);
	}
}
