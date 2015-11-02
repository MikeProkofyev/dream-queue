using UnityEngine;
using System.Collections;

public class KickController : MonoBehaviour {


	private float physicalForce = 10f;

	// Use this for initialization
	void Start () {
		GetComponent<SphereCollider>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	

	void OnTriggerEnter(Collider other)
	{
		Rigidbody otherRBody = other.gameObject.GetComponent<Rigidbody>();
		if (otherRBody) {
			otherRBody.SendMessage("RecieveDamage", 50f, SendMessageOptions.DontRequireReceiver);
			otherRBody.AddForce((transform.right + transform.forward) * physicalForce, ForceMode.Impulse);
		}
	}
}