using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intervention : MonoBehaviour {

	public string NAME = "";
	public GameObject World;
	public bool spawned = false;
	public GameObject[] AVP_vhc;
	public GameObject[] victimes;
	public GameObject[] incendies;

	// Use this for initialization
	void Start () {
		spawned = false;
		foreach (GameObject vhc in AVP_vhc) {
			vhc.SetActive (false);
		}
		foreach (GameObject vct in victimes) {
			vct.GetComponent<victimes> ().reset ();
			vct.SetActive (false);
		}
		foreach (GameObject inc in incendies) {
			inc.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void toogle (bool tg){
		spawned = tg;
		foreach (GameObject vhc in AVP_vhc) {
			vhc.SetActive (tg);
		}
		foreach (GameObject vct in victimes) {
			vct.GetComponent<victimes> ().reset ();
			vct.SetActive (tg);
		}
		foreach (GameObject inc in incendies) {
			inc.SetActive (tg);
		}
	}

	public void Action (string rawaction){
		string[] datas = rawaction.Split ('#');
		int nbline = 0;
		foreach (string line in datas) {
			nbline = nbline + 1;
		}
		if (nbline > 1) {
			if (datas [1] == "victime_menu" && nbline > 2) {
				victimes [ int.Parse(datas[2]) ].GetComponent<victimes> ().action ("menu");
			}
			else if (datas [1] == "menu_blessure" && nbline > 2) {
				victimes [ int.Parse(datas[2]) ].GetComponent<victimes> ().action ("menu_blessure");
			}
			else if (datas [1] == "Victim_blessure" && nbline > 3) {
				victimes [ int.Parse(datas[2]) ].GetComponent<victimes> ().updateBlessures (datas[3]);
			}
			else if (datas [1] == "VICTIME" && nbline > 2) {
				victimes [ int.Parse(datas[2]) ].GetComponent<victimes> ().update (float.Parse(datas[3]), float.Parse(datas[4]), float.Parse(datas[5]), float.Parse(datas[6]));
			}
			else if (datas [1] == "start") {
				toogle (true);
			}
			else if (datas [1] == "stop") {
				toogle (false);
			}
		}
	}
}
