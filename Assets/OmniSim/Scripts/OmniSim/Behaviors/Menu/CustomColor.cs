using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using OmniSim.Data;

namespace OmniSim.Behaviors.Menu {
	
	public class CustomColor : MonoBehaviour {

		public Material[] materials; // An array so we can update both the device and the UI textures

		public int maxColorSlot = 50;
		public int maxColorScheme = 50;
		public int numSlotVisible = 6;
		public int slotFill = 3;
		public int slotPad = 1;

		private Texture2D tempTex;
		private int slotSize;

		private ColorScheme currentSet;
		private ColorScheme defaultColors;
		private ColorScheme customColors;
		private bool isDirty;

		private GameObject popup;
		private GameObject sidebar;
		private GameObject defaultScroll;
		private GameObject customScroll;
		private GameObject colorScroll;

		private ColorScheme.Scheme tempScheme;

		// Use this for initialization
		void Start () {

			// Initialization of color scheme data
			OmniSim.Game game = GameObject.Find("GameManager").GetComponent("Game") as OmniSim.Game;
			defaultColors = game.getData ().defaultColors;
			customColors = game.getData ().customColors;

			// Initialization of Parents
			popup = GameObject.Find("CustomColorPopup");
			sidebar = GameObject.Find("CustomColorSidebar");

			// Initialization of Scrollables
			InitColorSchemeScrollable(defaultColors);
			InitColorSchemeScrollable(customColors);

			if (game.getData ().currentSet == "custom") {
				defaultScroll.SetActive (false);
				customScroll.SetActive (true);
				currentSet = customColors;
			} else {
				defaultScroll.SetActive (true);
				customScroll.SetActive (false);
				currentSet = defaultColors;
			}


			// 
			slotSize = slotFill + 2 * slotPad;

			// Create our temporary texture
			tempTex = new Texture2D (
				maxColorSlot * slotFill, // Note: this should be 256
				maxColorScheme * slotFill, // Note: this should be a power of 2
				TextureFormat.ARGB32, 
				false);
			
			// Set up our materials

		}
		
		// Update is called once per frame
		void Update () {
			
		}

		// If temp data has not been saved, revert the pixels in the tempTex
		private void RevertTempPixIfDirty() {
			if (isDirty) {
				// TODO: set the pixels in tempTex to that of the currentSet's currentScheme


				isDirty = false;
			}
		}

		// 
		private void UpdateColorScheme() {

		}

		// Switch out current and temp schemes to that of the given index s in the current set
		private void SetColorScheme(int s) {

		}

		// Load the default color scheme set
		public void LoadDefaultColors() {
			RevertTempPixIfDirty ();
		}

		// Load the custom color scheme set
		public void LoadCustomColors() {

		}

		// Populate the left column in the pop up with color scheme data for each object in currentSet.data.schemes
		private void InitColorSchemeScrollable() {
			InitColorSchemeScrollable (currentSet);
		}

		private void InitColorSchemeScrollable(ColorScheme schemeSet) {
			

		}

		// Populate the right column in the pop up with color slider data for each object in currentScheme.colors
		private void InitColorSliderScrollable() {

		}

		// Encode tempTex as a readable ARGB32 PNG file
		private void SaveTextureToPNG() {
			byte[] texBytes = tempTex.EncodeToPNG ();
			System.IO.File.WriteAllBytes (Application.dataPath + "Data/ColorSchemes/OS_Custom.png", texBytes);
		}

		private void UpdateMaterials () {

		}
	}

}