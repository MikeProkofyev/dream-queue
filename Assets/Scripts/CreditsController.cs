using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour {

	public bool crawling = false;
	public float speed = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!crawling)
			return;
		transform.Translate(Vector3.up * Time.deltaTime * speed);
		if (gameObject.transform.position.y > 1700)
		{
			ChangeToMenu();
		}
	}

	public void ChangeToMenu () {

		Destroy(GameObject.FindGameObjectWithTag("UIManagerObject"));
		Application.LoadLevel("Menu");
	}
}
