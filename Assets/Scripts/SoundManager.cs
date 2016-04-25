using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;
	public AudioSource musicSource;
	public static SoundManager instance = null;

	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;
	public Slider Slider;


	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void SetVolume()
	{
		musicSource.volume = Slider.value;
		efxSource.volume = Slider.value;
	}

	public void PlaySingle(AudioClip clip)
	{
		efxSource.clip = clip;
		efxSource.Play ();
	}

	public void RandomizeSfx (params AudioClip[] clips)
	{
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		efxSource.pitch = randomPitch;
		efxSource.clip = clips[randomIndex];
		efxSource.Play ();
	}
}
