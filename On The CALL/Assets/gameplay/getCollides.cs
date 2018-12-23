using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCollides : MonoBehaviour {

	public GameObject nearVhc;
	public bool nearOrdi = false;
	public GameObject nearCone;     //web cone obviously
	public string InterVictime = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnterVictime(string name){
		InterVictime = name;
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent<VHC> () != null) {
			nearVhc = col.gameObject;
		} else if (col.gameObject.GetComponent<EventNamer> () != null && col.gameObject.GetComponent<EventNamer> ().eventname == "net_cone") {
			nearCone = col.gameObject;
		} else if (col.gameObject.GetComponent<EventNamer> () != null && col.gameObject.GetComponent<EventNamer> ().eventname == "Ordinateur") {
			nearOrdi = true;
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.GetComponent<VHC> () != null && nearVhc == null) {
			nearVhc = col.gameObject;
		} else if (col.gameObject.GetComponent<EventNamer> () != null && nearCone == null && col.gameObject.GetComponent<EventNamer> ().eventname == "net_cone") {
			nearCone = col.gameObject;
		} else if (col.gameObject.GetComponent<EventNamer> () != null && col.gameObject.GetComponent<EventNamer> ().eventname == "Ordinateur") {
			nearOrdi = true;
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.GetComponent<VHC> () != null) {
			nearVhc = null;
		} else if (col.gameObject.GetComponent<EventNamer> () != null && col.gameObject.GetComponent<EventNamer> ().eventname == "net_cone") {
			nearCone = null;
		} else if (col.gameObject.GetComponent<EventNamer> () != null && col.gameObject.GetComponent<EventNamer> ().eventname == "Ordinateur") {
			nearOrdi = false;
		}
	}
}
