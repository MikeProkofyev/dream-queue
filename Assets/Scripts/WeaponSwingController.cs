using UnityEngine;
using System.Collections;

public class WeaponSwingController : MonoBehaviour {

	public SphereCollider dmgCollider;
	public Animator attackAnimator;
	private float swingDuration = 0.003333333f;
	private float timeLeft;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft <= 0 && dmgCollider.enabled) {
			dmgCollider.enabled = false;
		} else {
			timeLeft -= Time.deltaTime;
		}

		if (Input.GetButtonDown("Fire1")) {
			dmgCollider.enabled = true;
			attackAnimator.SetTrigger("attacking");
			timeLeft = swingDuration;
		}
	}


	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "NPC") {
			float new_z = Mathf.Clamp(GetComponent<Rigidbody>().velocity.z, -Mathf.Infinity, 0f);
			Vector3 new_velocity = GetComponent<Rigidbody>().velocity;
			new_velocity.z = new_z;
			GetComponent<Rigidbody>().velocity =  new_velocity;
		}
	}
}
