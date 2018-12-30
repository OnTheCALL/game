using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_manger : MonoBehaviour {

	public GameObject cone_model;
	public GameObject[] cones = new GameObject[100];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateCones (string raw = "&"){
		string[] list = raw.Split ('&');
		for (int i = 0; i < 100; i++) {
			if (list [i] != "") {
				string[] coord = list [i].Split ('#');
				if (cones [i] == null) {
					cones[i] = Instantiate (cone_model, new Vector3 (float.Parse (coord [0]), float.Parse (coord [1]), -2.0f), new Quaternion (0, 0, 0, 0));
				} else {
					if (cones [i].GetComponent<Transform> ().position.x != float.Parse (coord [0]) || cones [i].GetComponent<Transform> ().position.y != float.Parse (coord [1])) {
						Destroy (cones [i]);
						cones [i] = null;
						cones[i] = Instantiate (cone_model, new Vector3 (float.Parse (coord [0]), float.Parse (coord [1]), -2.0f), new Quaternion (0, 0, 0, 0));
					}
				}
			} else if (cones [i] != null) {
				Destroy (cones [i]);
				cones [i] = null;
			}
		}
	}
}
