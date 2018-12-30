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
	public float[] listPlayerUpdate = new float[100];


	// Use this for initialization
	void Start () {
		for(int i = 0;i<100;i++){
			listPlayerUpdate [i] = 0.0f;
			listPlayer [i] = null;
		}
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
		for(int i = 0;i<100;i++){
			if (listPlayerUpdate[i] > 0.0f) {
				listPlayerUpdate [i] = listPlayerUpdate [i] - Time.deltaTime;
				if (listPlayerUpdate [i] <= 0.0f) {
					listPlayerUpdate [i] = 0.0f;
					Destroy (listPlayer [i]);
					listPlayer [i] = null;
				}
			}
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
							listPlayerUpdate [int.Parse (cmds2 [1])] = 8.0f;
							listPlayer [int.Parse (cmds2 [1])].GetComponent<Transform> ().position = new Vector3 (float.Parse (cmds2 [2]), float.Parse (cmds2 [3]), -8.0f);
						} else {
							listPlayerUpdate [int.Parse (cmds2 [1])] = 8.0f;
							listPlayer [int.Parse (cmds2 [1])] = Instantiate (tryharder, new Vector3 (float.Parse (cmds2 [2]), float.Parse (cmds2 [3]), -8.0f), new Quaternion ());
						}
					} else if(cmds2 [0] == "INTER"){
						gameObject.GetComponent<actions> ().RelayToInter (cmds2 [1]);
						if (cmds2 [3] == "NO") {
							gameObject.GetComponent<IG_menu> ().set_bip_msg ("");
							gameObject.GetComponent<IG_menu> ().set_bip_vhc ("");
						} else {
							gameObject.GetComponent<IG_menu> ().set_bip_msg (cmds2 [2]);
							gameObject.GetComponent<IG_menu> ().set_bip_vhc (cmds2 [3]);
						}
					} else if(cmds2 [0] == "VSAV 01" && int.Parse(cmds2[6]) != playerID){
						gameObject.GetComponent<actions> ().car_VSAV1.GetComponent<VHC> ().NetUpdate (int.Parse(cmds2[1]),int.Parse(cmds2[2]),float.Parse(cmds2[3]),float.Parse(cmds2[4]),float.Parse(cmds2[5]),int.Parse(cmds2[6]));
					} else if(cmds2 [0] == "FPT 01" && int.Parse(cmds2[6]) != playerID){
						gameObject.GetComponent<actions> ().car_FPT1.GetComponent<VHC> ().NetUpdate (int.Parse(cmds2[1]),int.Parse(cmds2[2]),float.Parse(cmds2[3]),float.Parse(cmds2[4]),float.Parse(cmds2[5]),int.Parse(cmds2[6]));
					} else if(cmds2 [0] == "FPTSR 01" && int.Parse(cmds2[6]) != playerID){
						gameObject.GetComponent<actions> ().car_FPTSR1.GetComponent<VHC> ().NetUpdate (int.Parse(cmds2[1]),int.Parse(cmds2[2]),float.Parse(cmds2[3]),float.Parse(cmds2[4]),float.Parse(cmds2[5]),int.Parse(cmds2[6]));
					} else if(cmds2 [0] == "VL 01" && int.Parse(cmds2[6]) != playerID){
						gameObject.GetComponent<actions> ().car_VL1.GetComponent<VHC> ().NetUpdate (int.Parse(cmds2[1]),int.Parse(cmds2[2]),float.Parse(cmds2[3]),float.Parse(cmds2[4]),float.Parse(cmds2[5]),int.Parse(cmds2[6]));
					} else if(cmds2 [0] == "SAMU_VL 01" && int.Parse(cmds2[6]) != playerID){
						gameObject.GetComponent<actions> ().car_SAMU_VL1.GetComponent<VHC> ().NetUpdate (int.Parse(cmds2[1]),int.Parse(cmds2[2]),float.Parse(cmds2[3]),float.Parse(cmds2[4]),float.Parse(cmds2[5]),int.Parse(cmds2[6]));
					}
					else if(cmds2 [0] == "VICTIME"){
						gameObject.GetComponent<actions> ().NetAction ("Inter#" + cmds2[1] + "#VICTIME#" + cmds2[2] + "#" + cmds2[3] + "#" + cmds2[4] + "#" + cmds2[5] + "#" + cmds2[6]);
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
