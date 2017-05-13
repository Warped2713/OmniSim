using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	public Material material;

	public int[] posX = new int[6];
	public int[] posY = new int[6];
	public Color[] colorSchemeA = new Color[6];
	public Color[] colorSchemeB = new Color[6];

	private Color[] scheme = new Color[6];
	private Texture2D texture;

	// Use this for initialization
	void Start () {
		texture = new Texture2D (256, 8, TextureFormat.ARGB32, false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			this.scheme = this.colorSchemeA; 
			updatePixels ();
		} else if (Input.GetKeyDown(KeyCode.B)) {
			this.scheme = this.colorSchemeB; 
			updatePixels ();
		}
	}

	private void updatePixels() {
		for (int i=0; i < 6; i++) {
			for ( int x = 1; x < 4; x++ ) {
				for (int y = 1; y < 4; y++) {
					texture.SetPixel (posX[i] + x, posY[i] + y, scheme[i]);
				}
			}
		}
		texture.Apply ();
		material.SetTexture ("_IndexTex", texture);
	}
}
