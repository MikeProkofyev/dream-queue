using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

	bool excited = false;
	bool jumping = false;
	public float health = 100f;
	float nextJumpTime = 0;
	Wander wanderController;
	Rigidbody rb;
	NavMeshAgent navAgent;


	void Awake () {
		wanderController = GetComponent<Wander> ();
		rb = GetComponent<Rigidbody>();
		navAgent = GetComponent<NavMeshAgent>();
	}

	// Use this for initialization
	void Start () {
//		rb.detectCollisions = false;  //Uncomment, if interferes with navMeshAgent
	}

	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Die();
		}
		
		//		UpdateJumping();  //Sometimes mesh dissapears, and navAgent stops for no reason.
	}

	void UpdateJumping () {
		nextJumpTime -= Time.deltaTime;
		bool canJump = !jumping && nextJumpTime <= 0;//Input.GetButtonDown("Fire2")
		if (canJump) {
			nextJumpTime = Random.Range(3f, 6f);
			jumping = true;
			//			navAgent.Stop (true);
			navAgent.enabled = false;
			wanderController.enabled = false;	
			rb.AddRelativeForce(transform.TransformDirection(transform.up + transform.forward) * 120, ForceMode.Impulse);
			Invoke("TurnOnWalkSystems", 0.8f);
			
		}
	}

	void TurnOnWalkSystems() {
//		navAgent.Resume();
		navAgent.enabled = true;
		wanderController.enabled = true;	
		jumping = false;
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

	void OnCollisionEnter(Collision other) {

	}
	
}