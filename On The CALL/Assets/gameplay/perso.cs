using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perso : MonoBehaviour {

	public float court = 2.7f;
	public float marche = 1.1f;
	public GameObject myself;
	public GameObject skin;
	private float moveTx = 0.0f;
	private float moveTy = 0.0f;
	public bool inacar = false;

	string[] test1 = { "here", "me", "too" };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moveTx = 0.0f;
		moveTy = 0.0f;
		if(Input.GetKey(KeyCode.Z)){
			moveTy = 1.0f;
		} else if(Input.GetKey (KeyCode.S)){
			moveTy = -1.0f;
		}
		if(Input.GetKey(KeyCode.D)){
			moveTx = 1.0f;
		} else if(Input.GetKey (KeyCode.Q)){
			moveTx = -1.0f;
		}
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			myself.GetComponent<Rigidbody> ().velocity = new Vector3 (marche * moveTx, marche * moveTy, 0.0f);
		} else {
			myself.GetComponent<Rigidbody> ().velocity = new Vector3 (court * moveTx, court * moveTy, 0.0f);
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
	}

	void OnTriggerStay(Collider col){
		if (Input.GetKeyUp (KeyCode.E)) {
			
			if (col.gameObject.GetComponent<EventNamer> ().eventname == "Ordinateur") {
				gameObject.GetComponent<IG_menu> ().OpenMenu ("Ordinateur", test1, test1);
			}
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			
			if (col.gameObject.GetComponent<EventNamer> ().eventname == "FireEngine") {
				if (inacar == false) {
					col.gameObject.GetComponent<VHC> ().enter (myself, skin);
				}
			}
		}
	}
}
