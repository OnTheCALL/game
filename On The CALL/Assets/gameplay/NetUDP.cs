using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetUDP : MonoBehaviour {

	public GameObject tryharder;
	public GameObject skinTryer;
	public int playerID = 0;
	float lastTime = 0.0f;
	float tryTime = 0.0f;
	public GameObject[] listPlayer = new GameObject[100];


	// Use this for initialization
	void Start () {
		
	}
	 
	// Update is called once per frame
	void Update () {
		lastTime = lastTime + Time.deltaTime;
		tryTime = tryTime + Time.deltaTime;
		if (tryTime > 1.0f) {
			tryTime = 0.0f;
			//gameObject.GetComponent<IG_menu> ().set_bip_vhc ("Re-send");
			if (gameObject.GetComponent<actions> ().main_character.GetComponent<perso> ().inacar == true) {
				gameObject.GetComponent<fromNetwork> ().sendUDPString ("setmypos#5#{{" + playerID + "}}+{{" + skinTryer.GetComponent<Transform> ().position.x.ToString () + "}}+{{" + skinTryer.GetComponent<Transform> ().position.y.ToString () + "}}+{{1}}+{{" + gameObject.GetComponent<actions> ().main_character.GetComponent<perso> ().rotation.ToString() + "}}");
			} else {
				gameObject.GetComponent<fromNetwork> ().sendUDPString ("setmypos#5#{{" + playerID + "}}+{{" + skinTryer.GetComponent<Transform> ().position.x.ToString () + "}}+{{" + skinTryer.GetComponent<Transform> ().position.y.ToString () + "}}+{{0}}+{{0}}");
			}
		}
		if (lastTime > 10.0f) {
			gameObject.GetComponent<IG_menu> ().set_bip_hour ("OFFLINE");
		}
	}

	public void OnNetReady(int ID){
		playerID = ID;
		gameObject.GetComponent<fromNetwork> ().sendUDPString ("setAlive#1#{{" + playerID + "}}");
	}

	public void receive (string rawdata){
		lastTime = 0.0f;
		tryTime = 0.0f;
		//gameObject.GetComponent<IG_menu> ().update_chat (rawdata);
		string[] datas = rawdata.Split ('#');
		int nbline = 0;
		foreach (string line in datas) {
			nbline = nbline + 1;
		}
		if (nbline > 0) {
			if (datas [0] == "Connection-Ready") {
				//gameObject.GetComponent<fromNetwork> ().sendUDPString ("setmypos#4#{{" + playerID + "}}+{{" + skinTryer.GetComponent<Transform> ().position.x.ToString () + "}}+{{" + skinTryer.GetComponent<Transform> ().position.y.ToString () + "}}+{{0}}");
				if (gameObject.GetComponent<actions> ().main_character.GetComponent<perso> ().inacar == true) {
					gameObject.GetComponent<fromNetwork> ().sendUDPString ("setmypos#5#{{" + playerID + "}}+{{" + skinTryer.GetComponent<Transform> ().position.x.ToString () + "}}+{{" + skinTryer.GetComponent<Transform> ().position.y.ToString () + "}}+{{1}}+{{" + gameObject.GetComponent<actions> ().main_character.GetComponent<perso> ().rotation.ToString() + "}}");
				} else {
					gameObject.GetComponent<fromNetwork> ().sendUDPString ("setmypos#5#{{" + playerID + "}}+{{" + skinTryer.GetComponent<Transform> ().position.x.ToString () + "}}+{{" + skinTryer.GetComponent<Transform> ().position.y.ToString () + "}}+{{0}}+{{0}}");
				}
			} else if(datas [0] == "all") {
				string[] cmds = rawdata.Split ('&');
				foreach (string cmd in cmds) {
					string[] cmds2 = cmd.Split ('#');
					if (cmds2 [0] == "fetchedpos" && int.Parse (cmds2 [1]) != playerID) {
						if (listPlayer [int.Parse (cmds2 [1])] != null) {
							listPlayer [int.Parse (cmds2 [1])].GetComponent<Transform> ().position = new Vector3 (float.Parse (cmds2 [2]), float.Parse (cmds2 [3]), -8.0f);
						} else {
							listPlayer [int.Parse (cmds2 [1])] = Instantiate (tryharder, new Vector3 (float.Parse (cmds2 [2]), float.Parse (cmds2 [3]), -8.0f), new Quaternion ());
						}
					} else if(cmds2 [0] == "VSAV 01" && int.Parse(cmds2[5]) != playerID){
						gameObject.GetComponent<actions> ().car_VSAV1.GetComponent<VHC> ().NetUpdate (int.Parse(cmds2[1]),float.Parse(cmds2[2]),float.Parse(cmds2[3]),float.Parse(cmds2[4]),int.Parse(cmds2[5]));
					} else if(cmds2 [0] == "FPT 01" && int.Parse(cmds2[5]) != playerID){
						gameObject.GetComponent<actions> ().car_FPT1.GetComponent<VHC> ().NetUpdate (int.Parse(cmds2[1]),float.Parse(cmds2[2]),float.Parse(cmds2[3]),float.Parse(cmds2[4]),int.Parse(cmds2[5]));
					}
				}
				//gameObject.GetComponent<fromNetwork> ().sendUDPString ("setmypos#4#{{" + playerID + "}}+{{" + skinTryer.GetComponent<Transform> ().position.x.ToString () + "}}+{{" + skinTryer.GetComponent<Transform> ().position.y.ToString () + "}}+{{0}}");
				if (gameObject.GetComponent<actions> ().main_character.GetComponent<perso> ().inacar == true) {
					gameObject.GetComponent<fromNetwork> ().sendUDPString ("setmypos#5#{{" + playerID + "}}+{{" + skinTryer.GetComponent<Transform> ().position.x.ToString () + "}}+{{" + skinTryer.GetComponent<Transform> ().position.y.ToString () + "}}+{{1}}+{{" + gameObject.GetComponent<actions> ().main_character.GetComponent<perso> ().rotation.ToString() + "}}");
				} else {
					gameObject.GetComponent<fromNetwork> ().sendUDPString ("setmypos#5#{{" + playerID + "}}+{{" + skinTryer.GetComponent<Transform> ().position.x.ToString () + "}}+{{" + skinTryer.GetComponent<Transform> ().position.y.ToString () + "}}+{{0}}+{{0}}");
				}
			} else {
				//gameObject.GetComponent<IG_menu> ().set_bip_msg (rawdata);
			}
		}
	}
}
