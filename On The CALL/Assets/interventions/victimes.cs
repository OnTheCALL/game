using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victimes : MonoBehaviour {

	public bool player_here = false;
	public string tag_name = "";
	public float orig_x = 0.0f;
	public float orig_y = 0.0f;
	public float orig_z = 0.0f;
	public float orig_rot = 0.0f;
	public string[] blessures = new string[4];


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
		} else if (action == "menu_blessure") {
			gameObject.GetComponentInParent<intervention> ().World.GetComponent<IG_menu> ().OpenMenu ("Blessures", blessures[0], "medic_menu_blessures2#" + tag_name + "#" + blessures[0], blessures[1], "medic_menu_blessures2#" + tag_name + "#" + blessures[1], blessures[2], "medic_menu_blessures2#" + tag_name + "#" + blessures[2], blessures[3], "medic_menu_blessures2#" + tag_name + "#" + blessures[3]);//TODO ajouter la gestion des blessures
		}
	}

	public void updateBlessures (string raw){
		if (raw == "nohurt") {
			blessures[0] = "";blessures[1] = "";blessures[2] = "";blessures[3] = "";
		} else {
			string[] datas = raw.Split (':');
			if (datas.Length >= 1) { blessures [0] = datas[0]; } else { blessures [0] = ""; }
			if (datas.Length >= 2) { blessures [1] = datas[1]; } else { blessures [1] = ""; }
			if (datas.Length >= 3) { blessures [2] = datas[2]; } else { blessures [2] = ""; }
			if (datas.Length >= 4) { blessures [3] = datas[3]; } else { blessures [3] = ""; }
		}
	}
}
