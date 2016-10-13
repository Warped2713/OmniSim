using UnityEngine;
using System.Collections;

public class DeviceAnim : MonoBehaviour {

	public int texWidth = 198;
	public int texHeight = 198;
	public int padX = 1;
	public int padY = 1;
	public int bboxL = 220;
	public int bboxR = 1018;
	public int bboxT = 0;
	public int bboxB = 798;
	public int[] animActivate = {0, 1, 2, 3, 4, 6};
	public int[] animRecharge = {5};
	public int[] animRoster = {6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
	public string alienPreset = "Original 10";
	public Texture initialTex;
	public Texture animTex;
	public GameObject core;
	public GameObject dial;
	public GameObject lights;

	enum AnimMode { Idle, AnimActivate, Activated, AnimDeactivate, Deactivated, AnimRecharge, Recharged };
	AnimMode mode = AnimMode.Idle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (mode) {

		case AnimMode.AnimActivate:
			
			break;

		case AnimMode.Activated:
			break;

		case AnimMode.AnimDeactivate:
			break;

		case AnimMode.Deactivated:
			break;

		case AnimMode.AnimRecharge:
			break;

		case AnimMode.Recharged:
			break;

		case AnimMode.Idle:
		default:
			break;
		}
	}

	void setTexActivate() {
		core.GetComponent<Material> ().mainTexture = initialTex;
		dial.GetComponent<Material> ().mainTexture = initialTex;
		lights.GetComponent<Material> ().mainTexture = initialTex;
	}

	void setTexDeactivate() {
		core.GetComponent<Material> ().mainTexture = animTex;
		dial.GetComponent<Material> ().mainTexture = animTex;
		lights.GetComponent<Material> ().mainTexture = animTex;
	}

	public void AnimActivate() {
		mode = AnimMode.AnimActivate;
	}

	public void AnimDeactivate() {
		mode = AnimMode.AnimDeactivate;
	}

	public void AnimRecharge() {
		mode = AnimMode.AnimRecharge;
	}
}
