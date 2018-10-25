using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perso : MonoBehaviour {

	public float court = 2.7f;
	public float marche = 1.1f;
	public GameObject myself;
	public GameObject skin;
	float rotateSkin = 0.0f;
	private float moveTx = 0.0f;
	private float moveTy = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moveTx = 0.0f;
		moveTy = 0.0f;
		if(Input.GetKey(KeyCode.Z)){
			moveTy = Time.deltaTime;
		} else if(Input.GetKey (KeyCode.S)){
			moveTy = -Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.D)){
			moveTx = Time.deltaTime;
		} else if(Input.GetKey (KeyCode.Q)){
			moveTx = -Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			myself.GetComponent<Transform> ().Translate (marche * moveTx, marche * moveTy, 0.0f);
		} else {
			myself.GetComponent<Transform> ().Translate (court * moveTx, court * moveTy, 0.0f);
		}

		if (moveTx > 0 && moveTy == 0) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, -90.0f);
		} else if (moveTx < 0 && moveTy == 0) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, 90.0f);
		} else if (moveTx == 0 && moveTy > 0) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
		} else if (moveTx == 0 && moveTy < 0) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, 180.0f);
		} else if (moveTx > 0 && moveTy > 0) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, -45.0f);
		} else if (moveTx > 0 && moveTy < 0) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, -135.0f);
		} else if (moveTx < 0 && moveTy > 0) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, 45.0f);
		} else if (moveTx < 0 && moveTy < 0) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, 135.0f);
		}
			

		/*
		rotateSkin = 0.0f;
		if (Input.GetKey (KeyCode.Z)) {
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
				myself.GetComponent<Transform> ().Translate (0.0f, marche * Time.deltaTime, 0.0f);
			} else {
				myself.GetComponent<Transform> ().Translate (0.0f, court * Time.deltaTime, 0.0f);
			}
		} else if(Input.GetKey (KeyCode.S)) {
			rotateSkin = 180.0f;
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, 180.0f);
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
				myself.GetComponent<Transform> ().Translate (0.0f, -marche * Time.deltaTime, 0.0f);
			} else {
				myself.GetComponent<Transform> ().Translate (0.0f, -court * Time.deltaTime, 0.0f);
			}
		}
		if (Input.GetKey (KeyCode.Q)) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, 90.0f);
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
				myself.GetComponent<Transform> ().Translate (-marche * Time.deltaTime, 0.0f, 0.0f);
			} else {
				myself.GetComponent<Transform> ().Translate (-court * Time.deltaTime, 0.0f, 0.0f);
			}
		} else if (Input.GetKey (KeyCode.D)) {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, -90.0f);
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
				myself.GetComponent<Transform> ().Translate (marche * Time.deltaTime, 0.0f, 0.0f);
			} else {
				myself.GetComponent<Transform> ().Translate (court * Time.deltaTime, 0.0f, 0.0f);
			}
		} else {
			skin.GetComponent<Transform> ().localRotation = Quaternion.Euler (0.0f, 0.0f, rotateSkin);
		}*/
	}
}
