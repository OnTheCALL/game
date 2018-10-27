using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHC : MonoBehaviour {

	GameObject camOBJ;
	GameObject skintohide;
	Vector3 oldpos;
	public float Direction = 0.0f;
	float speed = 0.0f;
	float tox = 0.0f;
	float toy = 0.0f;
	bool readSpace = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (camOBJ != null && camOBJ != false) {
			gameObject.GetComponent<Rigidbody> ().drag = 1;
			gameObject.GetComponent<Rigidbody> ().angularDrag = 1;
			camOBJ.GetComponent<Transform> ().position = new Vector3 (gameObject.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y, -10.0f);

			if (Input.GetKey (KeyCode.Z)) {
				speed = speed + Time.deltaTime;
			} else if (Input.GetKey (KeyCode.S)) {
				speed = speed - Time.deltaTime;
			} else if (speed > 0.1f) {
				speed = speed - 0.1f;
			} else if (speed < -0.1f) {
				speed = speed + 0.1f;
			} else {
				speed = 0.0f;
			}

			if (Input.GetKey (KeyCode.D)) {
				Direction = Direction - (60.0f * Time.deltaTime);
			} else if (Input.GetKey (KeyCode.Q)) {
				Direction = Direction + (60.0f * Time.deltaTime);
			}
			if (Direction > 360.0f) {
				Direction = Direction - 360.0f;
			} else if (Direction < 0.0f) {
				Direction = Direction + 360.0f;
			}

			gameObject.GetComponent<Transform> ().rotation = Quaternion.Euler (0.0f, 0.0f, Direction);
			tox = -Mathf.Sin (Mathf.Deg2Rad * Direction) * speed;
			toy = Mathf.Cos (Mathf.Deg2Rad * Direction) * speed;
			gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (tox, toy, 0.0f);
			if (Input.GetKeyDown (KeyCode.Space) && readSpace == true) {
				exit ();
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				readSpace = true;
			}
		}else {
			gameObject.GetComponent<Rigidbody> ().drag = 100;
			gameObject.GetComponent<Rigidbody> ().angularDrag = 100;
		}
	}

	public void enter (GameObject perso, GameObject skin){
		readSpace = false;
		perso.GetComponent<BoxCollider> ().enabled = false;
		oldpos = perso.GetComponent<Transform> ().position;
		perso.GetComponent<perso> ().inacar = true;
		camOBJ = perso;
		skintohide = skin;
		skintohide.GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void exit (){
		camOBJ.GetComponent<BoxCollider> ().enabled = true;
		skintohide.GetComponent<SpriteRenderer> ().enabled = true;
		camOBJ.GetComponent<Transform> ().position = oldpos;
		camOBJ.GetComponent<perso> ().inacar = false;
		camOBJ = null;
		skintohide = null;
	}
}
