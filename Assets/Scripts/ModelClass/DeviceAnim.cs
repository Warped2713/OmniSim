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
	public GameObject faceplate;
	public GameObject tube;

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
		core.GetComponent<MeshRenderer> ().material.mainTexture = initialTex;
		dial.GetComponent<MeshRenderer> ().material.mainTexture = initialTex;
		lights.GetComponent<MeshRenderer> ().material.mainTexture = initialTex;
	}

	void setTexDeactivate() {
		core.GetComponent<MeshRenderer> ().material.mainTexture = animTex;
		dial.GetComponent<MeshRenderer> ().material.mainTexture = animTex;
		lights.GetComponent<MeshRenderer> ().material.mainTexture = animTex;
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

	public void setFaceplateAlienTex(int i) {
		Vector2 uv = new Vector2 ();
		uv.x = (float)((i + 6) % 4) * 0.25f;
		uv.y = 1.0f - (float)((i + 6) / 4 + 1) * 0.25f;
		faceplate.GetComponent<MeshRenderer> ().material.mainTextureOffset = uv;
	}

	public void resetFaceplate() {
		faceplate.GetComponent<MeshRenderer> ().material.mainTextureOffset = new Vector2 (0f, 0.75f);
	}

	public void setColorScheme(int i) {
		faceplate.GetComponent<MeshRenderer>().material.SetFloat("_SwapIndex", 1.0f - ( (2.0f + (float)i * 5.0f) / 105.0f ) );
		core.GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_SwapIndex", 1.0f - ( (2.0f + (float)i * 5.0f) / 105.0f ) );
		//print ("set colors to " + i.ToString());
	}
}
