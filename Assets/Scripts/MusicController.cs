using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public AudioClip mainTheme;
	public AudioClip fallingTheme;
	AudioSource audioSource;

	void Awake () {
		audioSource = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void playMainTheme () {
		audioSource.clip = mainTheme;
		audioSource.Play();
	}

	public void playFallingTheme () {
		audioSource.clip = fallingTheme;
		audioSource.Play();
	}

	public void stopPlayingMusic () {
		audioSource.Stop();
	}
}
