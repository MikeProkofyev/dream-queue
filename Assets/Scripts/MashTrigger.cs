using UnityEngine;
using System.Collections;

public class MashTrigger : MonoBehaviour {

	private ShowPanels showPanelsController;

	// Use this for initialization
	void Start () {
		showPanelsController = GameObject.FindGameObjectWithTag("UIManagerObject").GetComponent<ShowPanels>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		//Play music here ?
		EnableMash();
	}

	void EnableMash() {
		showPanelsController.ShowSpaceMashPanel();
	}
}
