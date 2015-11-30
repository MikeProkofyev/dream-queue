using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public AudioClip mainTheme;
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
//		audioSource.clip = mainTheme;
		audioSource.PlayOneShot(mainTheme);
	}
}
