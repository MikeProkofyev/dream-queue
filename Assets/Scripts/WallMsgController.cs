﻿using UnityEngine;
using System.Collections;

public class WallMsgController : MonoBehaviour {

	public TextMesh textMesh;
	public bool finishedWriting = false;

	string msg1 = "You are here because you are afraid";
	string msg2 = "Otherwise, you wouldn't be\n HERE";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}


	public void StartUpdatingText () {
		StartCoroutine("TextMeshUpdates");
	}


	IEnumerator TextMeshUpdates() {
		yield return StartCoroutine("UpdateMessage", msg1);
		yield return new WaitForSeconds(2f);
		textMesh.text="";
		yield return StartCoroutine("UpdateMessage", msg2);
		finishedWriting = true;
	}



	IEnumerator UpdateMessage (string message) {
		int charIndex = 0;
		while(charIndex != message.Length) {
			textMesh.text += message[charIndex++];
			yield return new WaitForSeconds(0.05f);
		}
	}
}






//Here should be the text, explaning everything
//	and at the same time,
//	noting. 