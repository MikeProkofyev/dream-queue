using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

	bool excited = false;
	bool dead = false;
	public float health = 100f;
	Wander wanderController;


	void Awake () {
		wanderController = GetComponent<Wander> ();
	}

	// Use this for initialization
	void Start () {
		EnableRagdoll(false);	 
	}

	
	// Update is called once per frame
	void Update () {
		if (health <= 0 && !dead) {
			Die();
		}
	}

	void EnableRagdoll (bool enableRagdoll) {
		Collider[] colChildren =  gameObject.GetComponentsInChildren< Collider >();
		for (int colIdx = 0; colIdx < colChildren.Length; colIdx++) {
			if ( colChildren[colIdx].gameObject != gameObject ) {
				colChildren[colIdx].enabled = enableRagdoll;
			}
		}
	}

	void Die () {
		GetComponent<CapsuleCollider>().enabled = false;
		GetComponent<Animator>().enabled = false;
		GetComponent<NavMeshAgent>().enabled = false;
		MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
		foreach(MonoBehaviour c in comps)
		{
			c.enabled = false;
		}
		EnableRagdoll(true);
		dead = true;
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
				NPCs[npcIdx].SendMessage("GetExcited",  SendMessageOptions.DontRequireReceiver);
			}

		}

	}
	
}