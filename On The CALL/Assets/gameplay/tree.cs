using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour {

	public float delta = 1.0f;
	public float size = 1.0f;

	// Use this for initialization
	void Start () {
		float sizze = Random.Range (size - delta, size + delta);
		gameObject.GetComponent<Transform> ().localScale = new Vector3 (sizze, sizze, 0);
		gameObject.GetComponent<Transform> ().localRotation = Quaternion.Euler (new Vector3(0,0,Random.Range (0.0f, 360.0f)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
