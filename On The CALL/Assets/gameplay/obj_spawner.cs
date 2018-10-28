using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_spawner : MonoBehaviour {

	public string in_hand = "gants";
	GameObject near_cone;
	public GameObject cone_model;
	bool listenC = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.C)){
			listenC = true;
		}

		if (Input.GetKeyDown (KeyCode.C) && listenC == true) {
			if (near_cone == null) {
				Instantiate (cone_model, new Vector3 (gameObject.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y + 1.0f, -2.0f), new Quaternion (0, 0, 0, 0));
			} else {
				Destroy (near_cone);
				near_cone = null;
			}
		}
	}

	void OnTriggerStay(Collider otherobj){
		if (otherobj.gameObject.GetComponent<EventNamer> () != null && otherobj.gameObject.GetComponent<EventNamer> ().eventname == "cone") {
			near_cone = otherobj.gameObject;
		}
	}

	void OnTriggerExit(Collider otherobj){
		if (otherobj.gameObject.GetComponent<EventNamer> () != null && otherobj.gameObject.GetComponent<EventNamer> ().eventname == "cone") {
			near_cone = null;
		}
	}
}
