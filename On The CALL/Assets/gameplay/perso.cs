using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perso : MonoBehaviour {

	public float court = 2.7f;
	public float marche = 1.1f;
	public GameObject skin;
	public GameObject World;
	private float moveTx = 0.0f;
	private float moveTy = 0.0f;
	public bool inacar = false;
	public float rotation = 0.0f;

	public bool goUp = false;
	public bool goDown = false;
	public bool goLeft = false;
	public bool goRight = false;
	public bool iswalking = true;


	// Use this for initialization
	void Start () {
		
	}

	public void setVHCrot(float zaxis){
		rotation = zaxis;
	}
	
	// Update is called once per frame
	void Update () {
		moveTx = 0.0f;
		moveTy = 0.0f;
		if(goUp){
			moveTy = 1.0f;
		} else if(goDown){
			moveTy = -1.0f;
		}
		if(goRight){
			moveTx = 1.0f;
		} else if(goLeft){
			moveTx = -1.0f;
		}
		if (iswalking) {
			gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (marche * moveTx, marche * moveTy, 0.0f);
		} else {
			gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (court * moveTx, court * moveTy, 0.0f);
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

	void OnTriggerExit(Collider col){
		if (col.gameObject.GetComponent<EventNamer> () != null && col.gameObject.GetComponent<EventNamer> ().eventname == "Ordinateur") {
			World.GetComponent<IG_menu> ().CloseMenu ();
		}
	}
}
