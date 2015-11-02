using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	void Update () {
		Vector3 v = Camera.main.transform.position - transform.position;
		v.x = v.z = 0.0f;
		transform.rotation = Camera.main.transform.rotation;
	}
}
