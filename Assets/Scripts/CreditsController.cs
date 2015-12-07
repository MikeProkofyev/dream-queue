using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour {


	public CanvasGroup creditsItem0;
	public Text endText;
	public CanvasGroup creditsItem1;
	public CanvasGroup creditsItem2;

	public GameObject backButton;


	private float fadeTime = 1f;
	private float waitForShowTime = 4f;
	private float currFadeTime = 0f;
	private bool showing0 = false;
	private bool hiding0 = false;
	private bool showing1 = false;
	private bool hiding1 = false;
	private bool showing2 = false;
	private bool hiding2 = false;


	private string[] phrases = new string[]{"Well, you've failed and hit the ground.",  "What are you going to do next?", "What are you going to do after each fall?"};


	// Use this for initialization
	void Start () {
		StartCoroutine("StartShowingCredits");
	}
	



	void Update () {




		if (showing0) {
			currFadeTime += Time.deltaTime;
			creditsItem0.alpha = Mathf.Lerp(0f, 1f, currFadeTime/fadeTime);
		}else if (hiding0) {
			currFadeTime += Time.deltaTime;
			creditsItem0.alpha = Mathf.Lerp(1f, 0f, currFadeTime/fadeTime);
		}else if (showing1) {
			currFadeTime += Time.deltaTime;
			creditsItem1.alpha = Mathf.Lerp(0f, 1f, currFadeTime/fadeTime);
		}else if (hiding1) {
			currFadeTime += Time.deltaTime;
			creditsItem1.alpha = Mathf.Lerp(1f, 0f, currFadeTime/fadeTime);
		}else if (showing2) {
			currFadeTime += Time.deltaTime;
			creditsItem2.alpha = Mathf.Lerp(0f, 1f, currFadeTime/fadeTime);
		}else if (hiding2) {
			currFadeTime += Time.deltaTime;
			creditsItem2.alpha = Mathf.Lerp(1f, 0f, currFadeTime/fadeTime);
		}

	}


	IEnumerator StartShowingCredits() {
		yield return new WaitForSeconds(1f);
		foreach (string phrase in phrases) {
			yield return StartCoroutine("UpdateMessage", phrase);
			yield return new WaitForSeconds(1.5f);
			endText.text = "";
		}

		backButton.SetActive(true);
//		showing0 = true;
//		yield return new WaitForSeconds(fadeTime); //OH MY GOD, THIS IS LIKE WHAT GOD HATES EVERY DAY
//		showing0 = false;
//		currFadeTime = 0f;
//		yield return new WaitForSeconds(waitForShowTime);
//		hiding0 = true;
//		yield return new WaitForSeconds(fadeTime);
//		hiding0 = false;
		currFadeTime = 0f;
		showing1 = true;
		yield return new WaitForSeconds(fadeTime); //OH MY GOD, THIS IS LIKE WHAT GOD HATES EVERY DAY
		showing1 = false;
		currFadeTime = 0f;
		yield return new WaitForSeconds(waitForShowTime);
		hiding1 = true;
		yield return new WaitForSeconds(fadeTime);
		hiding1 = false;
		currFadeTime = 0f;
		showing2 = true;
		yield return new WaitForSeconds(fadeTime); //OH MY GOD, THIS IS LIKE WHAT GOD HATES EVERY DAY
		showing2 = false;
		currFadeTime = 0f;
		yield return new WaitForSeconds(waitForShowTime);
		hiding2 = true;
		yield return new WaitForSeconds(fadeTime);
		hiding2 = false;
		currFadeTime = 0f;

		ChangeToMenu();
	}

	public void ChangeToMenu () {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().MakePlayerBlind();
		Destroy(GameObject.FindGameObjectWithTag("UIManagerObject"));
		Application.LoadLevel("Menu");
	}


	IEnumerator UpdateMessage (string message) {
		int charIndex = 0;
		while(charIndex != message.Length) {
			endText.text += message[charIndex++];
			yield return new WaitForSeconds(0.05f);
		}
	}

//	void Update () {
//		if (!crawling)
//			return;
//		transform.Translate(Vector3.up * Time.deltaTime * speed);
//		if (gameObject.transform.position.y > 1700)
//		{
//			ChangeToMenu();
//		}
//	}
//
}
