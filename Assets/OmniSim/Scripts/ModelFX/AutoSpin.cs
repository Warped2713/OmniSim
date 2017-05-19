using UnityEngine;
using System.Collections;

public class AutoSpin : MonoBehaviour {

	public float degPerFrame = 5.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, degPerFrame, 0);
	}
}
