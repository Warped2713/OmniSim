using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonTextEffects : MonoBehaviour {

	public string initialText;
	public string altText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region Hover Effects
	// Swaps Initial Text with Alt Text (and vice versa)
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

	// Changes the text of the button
	public void ChangeText(string txt) {

	}

	// Changes the color of button text and image
	public void ChangeColor(Color txtCol, Color buttonCol) {
		
	}

	// Swaps the button image with a given texture
	public void ChangeImage(Texture img) {

	}

	// Resizes the button to magnitude of initial size
	public void ChangeScale(float magnitude) {

	}

	// Flips the button horizontally or vertically
	public void ChangeOrientation(int dir) {

	}

	// Moves the button along the x,y,z axes
	public void ChangePosition(Vector3 deltapos) {

	}

	// Rotates the button around x,y,z axes
	public void ChangeRotation(Vector3 rot) {

	}
	#endregion Hover Effects


}
