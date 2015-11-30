using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour {


	public bool playStartSequence = true;
	public Camera playerCamera;
	public FirstPersonController firstPersonController;

	bool shouldGivePlayerControl = false;
	LightsController lightsController;
	WallMsgController messageController;
	MusicController musicController;
	int oldCullingMask;


	void Awake() {
		lightsController = GetComponent<LightsController>();
		messageController = GetComponent<WallMsgController>();
		musicController = GetComponent<MusicController> ();
	}

	// Use this for initialization
	void Start () {
//		musicController.playMainTheme();
		if (playStartSequence) {
			//TEXT
			messageController.StartUpdatingText();
			//LIGHTS
			oldCullingMask = playerCamera.cullingMask;
			playerCamera.cullingMask = (1 << LayerMask.NameToLayer("StartUpVisible"));
			lightsController.DisableLightMaps();
			//PLAYER CONTROLS
			firstPersonController.enabled = false;
		}

	}
	
	// Update is called once per frame
	void Update () {
		///REMOVE, BAD THING, UPDATES EVERY TIME
		if (messageController.finishedWriting) {
			shouldGivePlayerControl = true;
			messageController.finishedWriting = false;
		}
		if (shouldGivePlayerControl) {
			//LIGHTS
			playerCamera.cullingMask = oldCullingMask;
			lightsController.EnableLightMaps();
			//PLAYER CONTROLS
			firstPersonController.enabled = true;
			musicController.playMainTheme();
			shouldGivePlayerControl = false;
		}
	}
}
