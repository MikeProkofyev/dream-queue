using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

	bool excited = false;
	public float health = 100f;
	Wander wanderController;
	Rigidbody rb;
	NavMeshAgent navAgent;
	bool jumping = false;


	void Awake () {
		wanderController = GetComponent<Wander> ();
		rb = GetComponent<Rigidbody>();
		navAgent = GetComponent<NavMeshAgent>();
	}

	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Die();
		}

		if (jumping) {
//			navAgent.enabled = true;
			jumping = false;
		}

		if (Input.GetButtonDown("Jump")) {
			Debug.Log ("Jumping" + transform.up);
			jumping = true;
			navAgent.enabled = false;
			wanderController.enabled = false;	
//			navAgent.Stop(true);
			rb.AddForce(transform.TransformDirection(transform.up) * 10, ForceMode.Impulse);

		}
	}
	

	void Die () {
		Destroy(gameObject);
		//Spawn some particles
	}

	void RecieveDamage (float damage) {
		health -= damage;
		if (!excited) {
			GetExcited();
			ExciteNearby();	
		}
	}

	void OnCollisionEnter(Collision other) {
		if (rb.velocity.y == 0) {
			navAgent.enabled = true;
			wanderController.enabled = true;	
		}
	}



	void GetExcited () {
		excited = true;
		wanderController.enabled = true;
	}

	void ExciteNearby () {
		float radius = 5f;
		GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");

		for (int npcIdx = 0; npcIdx < NPCs.Length; npcIdx++) {
			Vector3 npcPosition = NPCs[npcIdx].GetComponent<Transform>().position;
			float npcDistance = Vector3.Distance(transform.position, npcPosition);
			bool nearbyNPC = npcDistance < radius && npcDistance != 0;
			if (nearbyNPC) {
				NPCs[npcIdx].GetComponent<NPCController>().GetExcited();
			}

		}

	}
	
}