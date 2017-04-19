using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OmniSim {
	
	public class AudioManager : MonoBehaviour {

		public static AudioManager Instance{ set; get; }

		public AudioSource BGM_Intro;
		public AudioSource BGM_Title;
		public AudioSource BGM_SelectDevice;
		public AudioSource BGM_DeviceView;
		public AudioSource BGM_AlienView;

		private void Awake()
		{
			Instance = this;
		}

		public void PlayAudio( string sndName ) 
		{
			AudioSource snd = (AudioSource) this.transform.Find (sndName).GetComponent<AudioSource>();
			if (!snd.isPlaying && snd.clip != null) {
				snd.Play ();
			}
		}

		public void StopAudio( string sndName ) 
		{
			AudioSource snd = this.transform.FindChild (sndName).GetComponent<AudioSource>();
			if (snd.isPlaying && snd.clip != null) {
				snd.Stop ();
			}
		}
	}

}