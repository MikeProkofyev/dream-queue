using UnityEngine;
using System.Collections;

public class WellLogicController : MonoBehaviour {


	public Collider triggerCollider;
	public Collider[] wallsColliders;
	public GameObject[] objectsToTurnOff;
	public Collider[] msg1ViewPoints;
	public Collider[] msg2ViewPoints;
	public GameObject wellLid;
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;
	public GameObject secondMessage;
	public MusicController musicController;

	private Animator animatorController;
	private bool msg1TriggerActive = false;
	private bool msg2TriggerActive = false;
	private Plane[] cameraPlanes;

	void Awake () {
		animatorController = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (msg1TriggerActive) {
			if (MessageVisible(msg1ViewPoints)) {
				msg1TriggerActive = false;
				msg2TriggerActive = true;
				secondMessage.SetActive(true);
				Debug.Log("Well message 1 seen");
			}
		}
		if (msg2TriggerActive) {
			if (MessageVisible(msg2ViewPoints)) {
				Debug.Log("Well message 2 seen");
				msg2TriggerActive = false;
				Invoke("InitiateFall", 2f);
			}
		}
	}

	void InitiateFall() {
		wellLid.SetActive(false);
		fpsController.falling = true;
		musicController.playFallingTheme();
	}

	bool MessageVisible(Collider[] messagePoints) {

		cameraPlanes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		foreach (var vP in messagePoints) {
			if (!GeometryUtility.TestPlanesAABB(cameraPlanes, vP.bounds)) {
				return false;
			}
		}
		return true;
	}

	void OnTriggerEnter(Collider other) {
		animatorController.SetTrigger("triggerEntered");
		triggerCollider.enabled = false;
		foreach (var wallCollider in wallsColliders) {
			wallCollider.enabled = true;
		}
		foreach (var badObj in objectsToTurnOff) {
			badObj.SetActive(false);
		}
		msg1TriggerActive = true;

	}
}
