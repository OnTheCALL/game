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
			//TODO region choose, and after type of soin
		} else if (splitedTodo[0] == "medic_put_victim_in_brancard") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_put_victim_in_brancard", splitedTodo [1], splitedTodo [2]);
		} else if (splitedTodo[0] == "medic_rentrer_brancard_dans") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<NetTCP> ().DoAction ("medic_rentrer_brancard_dans", splitedTodo [1], splitedTodo [2]);
			gameObject.GetComponent<IG_menu> ().change_tool ("hand");
		} else if (splitedTodo[0] == "taketool") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<IG_menu> ().change_tool (splitedTodo [1]);
		}
	}

	public void NetAction(string rawaction){
		string[] datas = rawaction.Split ('#');
		int nbline = 0;
		foreach (string line in datas) {
			nbline = nbline + 1;
		}
		if (nbline > 0) {
			if (datas [0] == "addcone" && nbline > 3) {
				GameObject temp = Instantiate (cone_model, new Vector3 (float.Parse (datas [2]), float.Parse (datas [3]), -2.0f), new Quaternion (0, 0, 0, 0));
				temp.GetComponent<NetID> ().ID = int.Parse (datas [1]);
			} else if (datas [0] == "remcone" && nbline > 1) {
				eventmanager.GetComponent<IDsenpai> ().actionTo (int.Parse (datas [1]), "destroy");
			} else if(datas[0] == "Inter" && nbline > 2) {
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
