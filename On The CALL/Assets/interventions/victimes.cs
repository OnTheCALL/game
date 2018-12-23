﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victimes : MonoBehaviour {

	public bool player_here = false;
	public string tag_name = "";
	public float orig_x = 0.0f;
	public float orig_y = 0.0f;
	public float orig_z = 0.0f;
	public float orig_rot = 0.0f;


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

	public void reset(){
		gameObject.GetComponent<Transform> ().localPosition = new Vector3 (orig_x, orig_y, orig_z);
		gameObject.GetComponent<Transform> ().localEulerAngles = new Vector3 (0.0f, 0.0f, orig_rot);
	}

	public void update(float x, float y, float z, float rot){
		gameObject.GetComponent<Transform> ().position = new Vector3 (x, y, z);
		gameObject.GetComponent<Transform> ().eulerAngles = new Vector3 (0.0f, 0.0f, rot);
	}

	public void action(string action){
		if (action == "menu" && gameObject.GetComponentInParent<intervention> ().World.GetComponent<IG_menu> ().get_tool() == "hand") {
			gameObject.GetComponentInParent<intervention> ().World.GetComponent<IG_menu> ().OpenMenu ("Victime", "Test conscience", "check_inconsciente#" + tag_name, "Prendre le Pouls", "check_respire#" + tag_name, "Cherche blessures", "search_hurt_zone#" + tag_name, "Identifier la victime", "check_identitee#" + tag_name);
		} else if (action == "menu" && gameObject.GetComponentInParent<intervention> ().World.GetComponent<IG_menu> ().get_tool() == "medpack") {
			gameObject.GetComponentInParent<intervention> ().World.GetComponent<IG_menu> ().OpenMenu ("Victime", "Mettre collier cervical", "medic_put_collier_cervical#" + tag_name, "Massage Cardiaque", "medic_rcp#" + tag_name, "Mettre Assistance Respiratoire", "medic_asistance_resp#" + tag_name, "Blessures", "medic_menu_blessures#" + tag_name);
		} else if (action == "menu" && gameObject.GetComponentInParent<intervention> ().World.GetComponent<IG_menu> ().get_tool() == "brancard") {
			gameObject.GetComponentInParent<intervention> ().World.GetComponent<IG_menu> ().OpenMenu ("Victime", "Prendre victime ", "medic_put_victim_in_brancard#" + tag_name + "#" + gameObject.GetComponentInParent<intervention>().World.GetComponent<fromNetwork>().ID.ToString());
		}
	}
}
