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
}
