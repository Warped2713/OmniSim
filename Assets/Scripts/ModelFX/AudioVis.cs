using UnityEngine;
using System.Collections;

public class AudioVis : MonoBehaviour {

	AudioSource audioSource;
	public static float[] samples = new float[512];
	public static float[] freqBand = new float[8];

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	void Update() 
	{
		GetSpectrumAudioSource ();
		MakeFrequencyBands ();
	}

	void GetSpectrumAudioSource() 
	{
		audioSource.GetSpectrumData (samples, 0, FFTWindow.Blackman);
	}

	void MakeFrequencyBands()
	{
		int count = 0;
		for (int i = 0; i < freqBand.Length; i++) {
			float avg = 0;
			int sampleCount = (int)Mathf.Pow (2, i) * 2;

			if (i == freqBand.Length - 1) {
				sampleCount += 2;
			}

			for (int j = 0; j < sampleCount; j++) {
				avg += samples [count] * (count + 1);
				count++;
			}

			avg /= count;
			freqBand [i] = avg;
		}
	}
}
