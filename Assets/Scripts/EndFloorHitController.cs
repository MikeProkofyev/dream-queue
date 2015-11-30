using UnityEngine;
using System.Collections;

public class EndFloorHitController : MonoBehaviour {

	public Material redMat;

	private Renderer materialRenderer;
	private ShowPanels showPanelsController;

	void Awake() {
		materialRenderer = GetComponent<Renderer>();
		showPanelsController = GameObject.FindGameObjectWithTag("UIManagerObject").GetComponent<ShowPanels>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		materialRenderer.material = redMat;
		showPanelsController.HideSpaceMashPanel();
		Invoke ("LoadCredits", 2f);
	}

	void LoadCredits() {
		showPanelsController.ShowCreditsPanel();
	}
}