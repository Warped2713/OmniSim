using UnityEngine;
using System.Collections;

public class DeviceExtra : MonoBehaviour {

	public Vector3 viewRotation;
	public Vector3 selectRotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void resetToViewRotation() {
		//TODO fix this
		//gameObject.transform.rotation.eulerAngles.Set(selectRotation.x, selectRotation.y, selectRotation.z);
	}

	public void resetToSelectRotation() {
		//TODO fix this
		//gameObject.transform.rotation.eulerAngles.Set(selectRotation.x, selectRotation.y, selectRotation.z);
	}
}
