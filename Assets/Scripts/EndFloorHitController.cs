using UnityEngine;
using System.Collections;

public class EndFloorHitController : MonoBehaviour {


	public MusicController musicController;
//	public Material redMat;

//	private Renderer materialRenderer;
	private ShowPanels showPanelsController;
	public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;

	void Awake() {
//		materialRenderer = GetComponent<Renderer>();
		showPanelsController = GameObject.FindGameObjectWithTag("UIManagerObject").GetComponent<ShowPanels>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
//		materialRenderer.material = redMat;
		showPanelsController.HideSpaceMashPanel();
		fpsController.enabled = false;
		musicController.stopPlayingMusic();
		LoadCredits();
	}

	void LoadCredits() {
		showPanelsController.ShowCreditsPanel();
	}
}