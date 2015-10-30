using UnityEngine;
using System.Collections;

public class SimpleWalkController : MonoBehaviour {


	float speed = 5.0F;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float vertical_movement = Input.GetAxis("Vertical") * speed;
		float horizontal_movement = Input.GetAxis("Horizontal") * speed;
		transform.Translate(horizontal_movement, 0, vertical_movement);



	}
}
