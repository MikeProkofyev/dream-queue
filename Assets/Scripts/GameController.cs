using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour {


	public bool playStartSequence = true;
	public Camera playerCamera;
	public FirstPersonController firstPersonController;

	LightsController lightsController;
	WallMsgController messageController;
	int oldCullingMask;


	void Awake() {
		lightsController = GetComponent<LightsController>();
		messageController = GetComponent<WallMsgController>();
	}

	// Use this for initialization
	void Start () {
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
			//LIGHTS
			playerCamera.cullingMask = oldCullingMask;
			lightsController.EnableLightMaps();
			//PLAYER CONTROLS
			firstPersonController.enabled = true;

			//START THE MUSIC
		}
	}
}
