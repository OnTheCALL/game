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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoAction (string todo){
		if (todo == "open Ordi") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<IG_menu> ().OpenMenu ("Ordinateur", "Regarder mon affectation", "set affectation", "Prendre feuille route", "take departure paper");
		} else if (todo == "set affectation") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<IG_menu> ().OpenMenu ("Affectations", "FPT", "set vhc FPT", "VSAV", "set vhc VSAV");
		} else if (todo == "set vhc FPT") {
			gameObject.GetComponent<IG_menu> ().set_bip_vhc ("FPT");
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
		} else if (todo == "set vhc VSAV") {
			gameObject.GetComponent<IG_menu> ().set_bip_vhc ("VSAV");
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
		} else if (todo == "take departure paper") {
			gameObject.GetComponent<IG_menu> ().set_bip_msg ("DEPART MALAISE - CHANTIER RUE DES TILLEULS");
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
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
				GameObject temp = Instantiate (cone_model, new Vector3 (float.Parse(datas[2]), float.Parse(datas[3]), -2.0f), new Quaternion (0, 0, 0, 0));
				temp.GetComponent<NetID> ().ID = int.Parse (datas [1]);
			} else if (datas [0] == "remcone" && nbline > 1) {
				eventmanager.GetComponent<IDsenpai> ().actionTo (int.Parse (datas [1]), "destroy");
			} else {
				//unknow action
			}
		}
	}
}
