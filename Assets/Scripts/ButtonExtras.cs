using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonExtras : MonoBehaviour {

	public string initialText;
	public string altText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AlternateText() {
		if (this.altText != "" && this.initialText != "") {
			
			Text t = this.GetComponentInChildren<Text> ();

			if (t.text == this.initialText) {
				t.text = this.altText;
			} else {
				t.text = this.initialText;
			}

		}
	}


}
