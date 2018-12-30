using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actions : MonoBehaviour {

	public GameObject main_character;
	public GameObject eventmanager;
	public GameObject cone_model;
	public GameObject car_VSAV1;
	public GameObject car_FPT1;
	public GameObject car_FPTSR1;
	public GameObject car_VL1;
	public GameObject car_SAMU_VL1;
	public GameObject[] interventions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoAction (string todo){
		string[] splitedTodo = todo.Split ('#');
		if (todo == "open Ordi") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<IG_menu> ().OpenMenu ("Ordinateur", "Prendre feuille route", "take departure paper");
		} else if (todo == "close"){
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
		} else if (todo == "open Hospital Menu"){
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<IG_menu> ().OpenMenu ("CHU St-Brieuc", "Déposer une victime", "medic_deposer_brancard_hopital#" + gameObject.GetComponent<fromNetwork>().ID.ToString());
		} else if (todo == "take departure paper") {
			//gameObject.GetComponent<IG_menu> ().set_bip_msg ("DEPART MALAISE - CHANTIER RUE DES TILLEULS");
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
		} else if (splitedTodo[0] == "check_inconsciente") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("check_inconsciente", splitedTodo [1]);
		} else if (splitedTodo[0] == "check_respire") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("check_respire", splitedTodo [1]);
		} else if (splitedTodo[0] == "check_identitee") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("check_identitee", splitedTodo [1]);
		} else if (splitedTodo[0] == "search_hurt_zone") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("search_hurt_zone", splitedTodo [1]);
		} else if (splitedTodo[0] == "medic_put_collier_cervical") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_put_collier_cervical", splitedTodo [1]);
		} else if (splitedTodo[0] == "medic_rcp") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_rcp", splitedTodo [1]);
		} else if (splitedTodo[0] == "medic_asistance_resp") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_asistance_resp", splitedTodo [1]);
		} else if (splitedTodo[0] == "medic_menu_blessures") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			string[] Tags = splitedTodo[1].Split(':');
			NetAction("Inter#" + Tags[0] + "#menu_blessure#" + Tags[1]);
		} else if (splitedTodo[0] == "medic_menu_blessures2") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<IG_menu> ().OpenMenu (splitedTodo[2], "Désinfecter", "medic_soins_desinfecter#" + splitedTodo[1] + "#" + splitedTodo[2], "Mettre bandage", "medic_soins_bandage#" + splitedTodo[1] + "#" + splitedTodo[2], "Mettre crème anti-douleur", "medic_soins_antidouleur#" + splitedTodo[1] + "#" + splitedTodo[2], "Mettre pansement", "medic_soins_pansement#" + splitedTodo[1] + "#" + splitedTodo[2]);
		} else if (splitedTodo[0] == "medic_soins_desinfecter") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_soins_desinfecter", splitedTodo [1], splitedTodo [2]);
		} else if (splitedTodo[0] == "medic_soins_bandage") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_soins_bandage", splitedTodo [1], splitedTodo [2]);
		} else if (splitedTodo[0] == "medic_soins_antidouleur") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_soins_antidouleur", splitedTodo [1], splitedTodo [2]);
		} else if (splitedTodo[0] == "medic_soins_pansement") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_soins_pansement", splitedTodo [1], splitedTodo [2]);
		} else if (splitedTodo[0] == "medic_put_victim_in_brancard") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_put_victim_in_brancard", splitedTodo [1], splitedTodo [2]);
		} else if (splitedTodo[0] == "medic_rentrer_brancard_dans") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_rentrer_brancard_dans", splitedTodo [1], splitedTodo [2]);
			gameObject.GetComponent<IG_menu> ().change_tool ("hand");
		} else if (splitedTodo[0] == "medic_prendre_brancard_avec_victime") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_prendre_brancard_avec_victime", splitedTodo [1], splitedTodo [2]);
			gameObject.GetComponent<IG_menu> ().change_tool ("brancard");
		} else if (splitedTodo[0] == "medic_deposer_brancard_hopital") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_deposer_brancard_hopital", splitedTodo [1]);
		} else if (splitedTodo[0] == "taketool") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<IG_menu> ().change_tool (splitedTodo [1]);
		} else if (splitedTodo[0] == "setGyro2model") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("setGyro2model", splitedTodo [1], splitedTodo [2]);
		}
	}

	public void NetAction(string rawaction){
		string[] datas = rawaction.Split ('#');
		int nbline = 0;
		foreach (string line in datas) {
			nbline = nbline + 1;
		}
		if (nbline > 0) {
			if(datas[0] == "Inter" && nbline > 2) {
				foreach (GameObject inter in interventions) {
					if (inter.GetComponent<intervention> ().NAME == datas [1]) {
						string preparestring = "fromServer";
						for (int i = 2; i < datas.Length; i++) {
							preparestring = preparestring + "#" + datas [i];
						}
						inter.GetComponent<intervention> ().Action (preparestring);
						return;
					}
				}
				Debug.Log ("inter not find  :  " + rawaction);
			} else {
				//unknow action
			}
		}
	}

	public void RelayToInter(string TAG){ 
		foreach (GameObject inter in interventions) {
			if (inter.GetComponent<intervention> ().NAME == TAG && inter.GetComponent<intervention> ().spawned == false) {
				inter.GetComponent<intervention> ().Action ("fromServer#start");
			} else if(inter.GetComponent<intervention> ().NAME != TAG && inter.GetComponent<intervention> ().spawned == true){
				inter.GetComponent<intervention> ().Action ("fromServer#stop");
			}
		}
	}
}
