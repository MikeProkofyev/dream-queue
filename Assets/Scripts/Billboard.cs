using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	
	public Transform rotateAround;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = Camera.main.transform.position - transform.position;
		v.x = v.z = 0.0f;
//		transform.LookAt( Camera.main.transform.position - v ); 
//		transform.Rotate(0,180,0);
//		transform.RotateAroundLocal (rotateAround.position, Vector3.up, (Camera.main.transform.rotation.eulerAngles - transform.rotation.eulerAngles).y);
		transform.rotation = Camera.main.transform.rotation;
//		gameObject.transform
	}
}
