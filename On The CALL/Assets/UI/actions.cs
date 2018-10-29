using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actions : MonoBehaviour {

	public GameObject hours_text;
	public GameObject truck_text;
	public GameObject bip_text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoAction (string todo){
		if (todo == "set affectation") {
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
			gameObject.GetComponent<IG_menu> ().OpenMenu ("Affectations", "FPT", "set vhc FPT", "VSAV", "set vhc VSAV");
		} else if (todo == "set vhc FPT") {
			truck_text.GetComponent<Text> ().text = "FPT";
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
		} else if (todo == "set vhc VSAV") {
			truck_text.GetComponent<Text> ().text = "VSAV";
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
		} else if (todo == "take departure paper") {
			bip_text.GetComponent<Text> ().text = "DEPART AVP - RUE DES TILLEULS";
			gameObject.GetComponent<IG_menu> ().CloseMenu ();
		}
	}
}
