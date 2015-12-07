using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MashSpaceController : MonoBehaviour {

	private Text mashText;
	private Vector3 maxLocalScale = Vector3.one * 2;
	private float coolTime = .25f;
	private float currcoolTime;

	// Use this for initialization
	void Start () {
		mashText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		mashText.color = RandomColor();

		if (Input.GetButtonDown("Jump")){
			currcoolTime = coolTime;
		}

		if (currcoolTime > 0) {
			currcoolTime -= Time.deltaTime;
			mashText.transform.localScale = Vector3.Lerp(Vector3.one, maxLocalScale, currcoolTime/coolTime);
		}




	}


	Color RandomColor() {
		return new Color(Random.value, Random.value, Random.value);
	}
}
