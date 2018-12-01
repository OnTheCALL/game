using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHC : MonoBehaviour {

	public bool Imdriver = false;
	public string VHCname = "";
	GameObject camOBJ;
	GameObject skintohide;
	public float Direction = 0.0f;
	public float maxspeed = 10.0f;
	float speed = 0.0f;
	float tox = 0.0f;
	float toy = 0.0f;
	public GameObject spawn_door;
	public GameObject[] gyros;
	float toggleGyro = 0.25f;
	public int code_alerte = 1;
	public float resetDriver = 0.0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (resetDriver > 0.0f) {
			resetDriver = resetDriver - Time.deltaTime;
			Imdriver = true;
		}
		if (camOBJ != null && camOBJ.GetComponent<perso>().inacar == true) {
			gameObject.GetComponent<Rigidbody> ().drag = 1;
			gameObject.GetComponent<Rigidbody> ().angularDrag = 1;
			camOBJ.GetComponent<Transform> ().position = new Vector3 (gameObject.GetComponent<Transform> ().position.x, gameObject.GetComponent<Transform> ().position.y, -10.0f);

			if (Imdriver) {
				if (Input.GetKey (KeyCode.Z) && speed < -0.1f) {
					speed = speed + 0.2f;
				} else if (Input.GetKey (KeyCode.S) && speed > 0.1f) {
					speed = speed - 0.2f;
				} else if (Input.GetKey (KeyCode.Z)) {
					speed = speed + Time.deltaTime;
				} else if (Input.GetKey (KeyCode.S)) {
					speed = speed - Time.deltaTime;
				} else if (speed > 0.05f) {
					speed = speed - 0.05f;
				} else if (speed < -0.05f) {
					speed = speed + 0.05f; 
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

				camOBJ.GetComponent<perso> ().setVHCrot (Direction);

				gameObject.GetComponent<Transform> ().rotation = Quaternion.Euler (0.0f, 0.0f, Direction);
				tox = -Mathf.Sin (Mathf.Deg2Rad * Direction) * speed;
				toy = Mathf.Cos (Mathf.Deg2Rad * Direction) * speed;
				gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (tox, toy, 0.0f);
				//float decalx = -Mathf.Sin (Mathf.Deg2Rad * Direction) * 5;
				//float decaly = Mathf.Cos (Mathf.Deg2Rad * Direction) * 5;
				//camOBJ.GetComponent<Transform> ().position = new Vector3 (gameObject.GetComponent<Transform> ().position.x + decalx, gameObject.GetComponent<Transform> ().position.y + decaly, -10.0f);
			}
				
		}else {
			gameObject.GetComponent<Rigidbody> ().drag = 100;
			gameObject.GetComponent<Rigidbody> ().angularDrag = 100;
		}

		if (code_alerte > 1) {
			toggleGyro = toggleGyro - Time.deltaTime;
			if (toggleGyro <= 0) {
				toggleGyro = toggleGyro + 0.25f;
				for (int i = 0; i < gyros.Length; i++) {
					gyros [i].GetComponent<SpriteRenderer> ().enabled = !(gyros [i].GetComponent<SpriteRenderer> ().enabled);
				}
			}
		}
		if (code_alerte < 3 && gameObject.GetComponent<AudioSource> ().isPlaying == true) {
			gameObject.GetComponent<AudioSource> ().Stop ();
		}
	}

	public void change_code(int code, bool force){
		if (Imdriver == true || force == true) {
			if (code == 1) {
				toggleGyro = 0.25f;
				for (int i = 0; i < gyros.Length; i++) {
					gyros [i].GetComponent<SpriteRenderer> ().enabled = false;
				}
			} else if (code == 2) {
				if (code_alerte == 1) {
					toggleGyro = 0.25f;
					gyros [0].GetComponent<SpriteRenderer> ().enabled = true;
					if (gyros.Length > 1) {
						for (int i = 1; i < gyros.Length; i++) {
							gyros [i].GetComponent<SpriteRenderer> ().enabled = !(gyros [i - 1].GetComponent<SpriteRenderer> ().enabled);
						}
					}
				}
			} else if (code == 3) {
				if (code_alerte == 1) {
					toggleGyro = 0.25f;
					gyros [0].GetComponent<SpriteRenderer> ().enabled = true;
					if (gyros.Length > 1) {
						for (int i = 1; i < gyros.Length; i++) {
							gyros [i].GetComponent<SpriteRenderer> ().enabled = !(gyros [i - 1].GetComponent<SpriteRenderer> ().enabled);
						}
					}
				}
				gameObject.GetComponent<AudioSource> ().Play ();
			}
			code_alerte = code;
		}
	}

	public void NetUpdate(int code, float x, float y, float zaxis, int driverID){
		// this is not called if you are the driver
		Imdriver = false;
		if (code_alerte != code) {
			change_code (code, true);
		}
		//Vector3 oldpos = gameObject.GetComponent<Transform> ().position;
		gameObject.GetComponent<Transform> ().position = new Vector3 (x, y, -3.0f);
		//gameObject.GetComponent<Transform> ().LookAt (oldpos);
		gameObject.GetComponent<Transform> ().rotation = Quaternion.Euler(0.0f, 0.0f, zaxis); 
	} 

	public void enter (GameObject perso, GameObject skin){
		perso.GetComponent<BoxCollider> ().enabled = false;
		perso.GetComponent<perso> ().inacar = true;
		perso.GetComponentInChildren<Camera> ().orthographicSize = 9.0f; 
		camOBJ = perso;
		Imdriver = true;
		resetDriver = 1.0f;
		skintohide = skin;
		skintohide.GetComponent<SpriteRenderer> ().enabled = false;
	}

	public void exit (){
		camOBJ.GetComponentInChildren<Camera> ().orthographicSize = 7.0f;
		camOBJ.GetComponent<BoxCollider> ().enabled = true;
		skintohide.GetComponent<SpriteRenderer> ().enabled = true;
		camOBJ.GetComponent<Transform> ().position = new Vector3(spawn_door.GetComponent<Transform>().position.x, spawn_door.GetComponent<Transform>().position.y, -10.0f);
		camOBJ.GetComponent<perso> ().inacar = false;
		camOBJ = null;
		Imdriver = false;
		skintohide = null;
	}
}
