using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace OmniSim.Behaviors.Input {

	public class ModeChange : MonoBehaviour {

		public string IdleModeTrigger;  // An OmniSim.InputManager value to check (set each update by a custom monobehavior)
		public string IdleModeCallback;  // A DeviceView function to call, identified by a string

		public string ActiveModeTrigger;
		public string ActiveModeCallback;

		public string TimeoutModeTrigger;
		public string TimeoutModeCallback;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {



			// Activate Device: Only in IDLE mode
			// Button Down: Num1 (1 or numpad 1)
			// Mouse Click on model's button
			// disables activate button, enables alien buttons, pops core


			// Timeout Device: Only in ACTIVE mode
			// Button Down: Num2 (2 or numpad 2)
			// sets timeout, disables activate button, disables alien buttons, RED FLASH, resets core


			// Reset Device: Only in ACTIVE mode or TIMEOUT mode
			// Button Down: Num0 (0 or numpad 0)
			// Mouse Click on model's button
			// clears timeout, enables activate button, disables alien buttons, resets core


			// Select Alien (CW or CCW): Only in ACTIVE mode
			// Button Down: LEFT or RIGHT (arrows or numpad 4/6)
			// Mouse click-N-drag on model's dial
			// rotate dial and swap faceplate


			// Transform: Only in ACTIVE mode with a 0+ currentAlien
			// Button Down: ACTION (spacebar, enter, numpad 5)
			// Mouse click on model's faceplate
			// GREEN FLASH and transition to Alien View


			//float d = UnityEngine.Input.GetAxis ("");
			//UnityEngine.Input.GetButtonDown("")


		}


	}

}