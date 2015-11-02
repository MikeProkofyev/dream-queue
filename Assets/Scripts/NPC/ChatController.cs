using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ChatController : MonoBehaviour {

	public UnityEngine.UI.Text chatText;
	public UnityEngine.UI.Text brownText;
	public UnityEngine.UI.Text whiteText;
	public ScrollRect chatRect;
	public float verticalPos = 0;


	Dictionary<string, List<string>> chatLines = new Dictionary <string, List<string>> {

			{"brown", new List<string> {
					"How long i've been wainting here? 4ever?",
					"Faster pussycat, Kill! Kill!"
			}},
			{"white", new List<string> {
					"I think I'll die here waiting.",
					"Like so many young men at Khe Sanh, at Langdok, at Hill 364.",
					"Goodbye evening with kids.",

			}},

	};



	// Use this for initialization
	void Start () {
		StartCoroutine(UpdatePhraseFor("brown", brownText));
		StartCoroutine(UpdatePhraseFor("white", whiteText));





	}
	
	IEnumerator UpdatePhraseFor (string name, UnityEngine.UI.Text textField) {
		float updateDelay = Random.Range(8f, 18f);
		for (int phraseIdx = 0; phraseIdx < chatLines[name].Count; phraseIdx++) {
			yield return new WaitForSeconds(updateDelay);
			textField.text = chatLines[name][phraseIdx];
			AddPhraseToChat(name, chatLines[name][phraseIdx]);
			StartCoroutine(RemovePhraseFor(textField));
			updateDelay = Random.Range(8f, 18f);
		}
	}

	IEnumerator RemovePhraseFor (UnityEngine.UI.Text guiText) {
		yield return new WaitForSeconds(6f); //Wait for 3 seconds before clearing speech bubble
		guiText.text = "";
	}

	void AddPhraseToChat (string name, string phrase) {
		chatText.text += "[" + name + "]: " + phrase + "\n";
	}
	
	// Update is called once per frame
	void Update () {
		chatRect.verticalNormalizedPosition = 0;
	}
}
