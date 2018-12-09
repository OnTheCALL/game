using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victimes : MonoBehaviour {

	public bool player_here = false;
	public string tag_name = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent<perso> () != null) {
			player_here = true;
			col.gameObject.GetComponent<getCollides> ().EnterVictime (tag_name);
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.GetComponent<perso> () != null && player_here == false) {
			player_here = true;
			col.gameObject.GetComponent<getCollides> ().EnterVictime (tag_name);
		}
	}

	void OnTriggerExit (Collider col) {
		if (col.gameObject.GetComponent<perso> () != null) {
			player_here = false;
			col.gameObject.GetComponent<getCollides> ().EnterVictime ("");
		}
	}

	public void action(string action){
		if (action == "menu") {
			gameObject.GetComponentInParent<intervention> ().World.GetComponent<IG_menu> ().OpenMenu ("Victime", "Test conscience", "isconsciente#" + tag_name);
		}
	}
}
