using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberOfUsersController : MonoBehaviour {

	public TextMesh numberOfUsersText;
	private int usersOnline = 6345;
	private float changeTimeout;

	// Use this for initialization
	void Start () {
		usersOnline = Random.Range(4000, 12000);
		StartCoroutine("UpdatePlayersCount");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator UpdatePlayersCount() {
		while(true) {
			changeTimeout = Random.Range(1f, 3f);
			numberOfUsersText.text = "Users online: " + (usersOnline + Random.Range(-12,12));
			yield return new WaitForSeconds(changeTimeout);
		}
	}
}
