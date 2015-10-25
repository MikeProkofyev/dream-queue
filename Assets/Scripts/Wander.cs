using UnityEngine;
using System.Collections;



//[RequireComponent(typeof (ThirdPersonCharacter))]
public class Wander : MonoBehaviour {
	


	public float directionChangeInterval = 1f;
	public float speed = 5;
	float maxHeadingChange = 360;
	int rotationDirection = 1;
	float nextYRotation;
	NavMeshAgent navAgent;


	void Awake() {
		navAgent = GetComponent<NavMeshAgent> ();
	}

	// Use this for initialization
	void Start () {
		directionChangeInterval = Random.Range(0.6f, .2f);
     	speed = Random.Range (3f, 6f);
		maxHeadingChange = Random.Range(60f, 120f);
		StartCoroutine(NewHeading());
	}
	
	// Update is called once per frame
	void Update () {
		float smallRotation = Mathf.LerpAngle(transform.eulerAngles.y, nextYRotation, Time.deltaTime * 10 * directionChangeInterval);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x,  smallRotation, transform.eulerAngles.z);

		var forward = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, forward * speed, Color.green);
		navAgent.SetDestination(forward * speed);

	}


	IEnumerator NewHeading () {
		while(true) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}

	void NewHeadingRoutine () {
		nextYRotation =  Random.Range(nextYRotation - maxHeadingChange, nextYRotation + maxHeadingChange) % 360;
		rotationDirection = Random.Range(-1, 1) < 0 ? -1 : 1;
//		Debug.Log (rotationDirection);
	}


}