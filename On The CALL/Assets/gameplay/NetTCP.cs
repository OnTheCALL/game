using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetTCP : MonoBehaviour {

	WWWForm form;
	WWW download;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void inited(int ID, string grade){
		gameObject.GetComponent<NetUDP> ().OnNetReady (ID);
		gameObject.GetComponent<discordController> ().Grade = grade;
		gameObject.GetComponent<IG_menu> ().set_bip_msg("GRADE : " + grade + "\n\nSTATUS : DISPONIBLE");
	}

	IEnumerator makeAweb (string action, string d1 = "0", string d2 = "0", string d3 = "0"){
		form = new WWWForm ();
		form.AddField("action", action);
		form.AddField ("data1", d1);
		form.AddField ("data2", d2);
		form.AddField ("data3", d3);
		download = new WWW ("https://cta.loulou123546.fr/gameAPI/action", form);
		yield return download;
		if (string.IsNullOrEmpty (download.error)) {
			
		}
	}

	public void DoAction(string act, string d1 = " ", string d2 = " ", string d3 = " "){
		StartCoroutine (makeAweb(act, d1, d2, d3));
	}

	public void receive(string chat, string chat_inter, string cones = " ", string inter_info = " "){
		gameObject.GetComponent<IG_menu> ().update_chat(chat);
		gameObject.GetComponent<OBJ_manger> ().updateCones (cones);
		if (gameObject.GetComponent<IG_menu> ().truck_text.GetComponent<Text> ().text == "") {
			gameObject.GetComponent<IG_menu> ().msg_inter ("");
		} else {
			gameObject.GetComponent<IG_menu> ().msg_inter (chat_inter);
		}
			
		string[] inter_data = inter_info.Split ('&');
		foreach (string inter in inter_data) {
			string[] parsed = inter.Split ('#');
			if (parsed [0] == "Victim_blessure") {
				gameObject.GetComponent<actions> ().NetAction ("Inter#" + parsed[1] + "#Victim_blessure#" + parsed[2] + "#" +  parsed[3]);
			}
		}
	}
}
