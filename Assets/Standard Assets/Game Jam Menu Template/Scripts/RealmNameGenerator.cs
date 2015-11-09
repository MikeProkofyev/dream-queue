using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript : MonoBehaviour {

	List <string> realms = new List<string> {"Puffy clouds", "Laura"};


	public string GetRealmName () {
		return realms[Random.Range(0, realms.Count)];
	}
}
