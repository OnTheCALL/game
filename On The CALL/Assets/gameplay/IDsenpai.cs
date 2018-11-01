using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDsenpai : MonoBehaviour {

	string[] Orders = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider col){
		for (int i = 0; i < Orders.Length; i++) {
			if (Orders [i] != "") {
				string[] data = Orders [i].Split ('#');
				if (col != null && col.gameObject != null && col.gameObject.GetComponent<NetID>() != null && int.Parse (data [0]) == col.gameObject.GetComponent<NetID> ().ID) {
					if (data [1] == "destroy") {
						col.gameObject.GetComponent<NetID> ().deleteMyself ();
						Orders [i] = "";
						return;
					}
				}
			}
		}
	}

	public void actionTo(int ID, string ask, string data = ""){
		for (int i = 0; i < Orders.Length; i++) {
			if (Orders [i] == "") {
				Orders [i] = ID.ToString () + "#" + ask + "#" + data;
				return;
			}
		}
		//  If your come here, there was a BIG PROBLEM, action will be skipped
	}
}
