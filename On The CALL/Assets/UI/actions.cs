using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actions : MonoBehaviour {

	public GameObject main_character;

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
}
