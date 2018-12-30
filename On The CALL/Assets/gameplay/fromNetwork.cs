using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net.NetworkInformation;

public class fromNetwork : MonoBehaviour {

	WWWForm formFM;
	WWW downloadFM;
	JSONNode monObjFM;
	WWWForm formINIT;
	WWW downloadINIT;
	JSONNode monObjINIT;
	bool sendOnNext = false;
	public string relayBack = "";
	public int ID = 0;

	Thread receiveThread;
	UdpClient udp_obj;
	public string IP = "51.38.38.241";
	IPEndPoint remotEndPoint;

	// Use this for initialization
	void Start () {
		formFM = new WWWForm ();
		formFM.AddField ("ID", 0);
		Application.runInBackground = true;
		init();
	}

	IEnumerator fetchMainData (){
		formFM = new WWWForm ();
		formFM.AddField ("ID", ID);
		downloadFM = null;
		downloadFM = new WWW ("https://cta.loulou123546.fr/gameAPI/fetch", formFM);
		yield return downloadFM;
		if (string.IsNullOrEmpty (downloadFM.error)) {
			monObjFM = JSON.Parse(downloadFM.text);
			gameObject.GetComponent<NetTCP> ().receive (monObjFM ["chat"], monObjFM ["chat_inter"], monObjFM ["cones"], monObjFM ["inter_info"]);
		}
		sendOnNext = true;
	}
	IEnumerator initweb (){
		formINIT = new WWWForm ();
		formINIT.AddField ("pseudo", PlayerPrefs.GetString ("user_name", "no"));
		formINIT.AddField ("pass", PlayerPrefs.GetString ("user_password", "no"));
		downloadINIT = new WWW ("https://cta.loulou123546.fr/gameAPI/init", formINIT);
		yield return downloadINIT;
		if (string.IsNullOrEmpty (downloadINIT.error)) {
			monObjINIT = JSON.Parse (downloadINIT.text);
			Debug.Log (monObjINIT);
			if (int.Parse (monObjINIT ["error"]) == 1) {
				gameObject.GetComponent<IG_menu> ().set_bip_msg ("DISCONNECTED\n\nCLOSE AND RETRY");
			} else {
				gameObject.GetComponent<IG_menu> ().set_bip_msg ("");
				//formFM.AddField ("ID", int.Parse (monObjINIT ["ID"]));
				ID = int.Parse (monObjINIT ["ID"]);
				gameObject.GetComponent<NetTCP> ().inited (int.Parse (monObjINIT ["ID"]), monObjINIT ["grade"]);
			}
		} else {
			gameObject.GetComponent<IG_menu> ().set_bip_msg ("NOT CONNECTED\n\nCLOSE AND RETRY");
		}
		sendOnNext = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (sendOnNext == true) {
			sendOnNext = false;
			StartCoroutine (fetchMainData ());
		}
		if (relayBack != "") {
			gameObject.GetComponent<NetUDP>().receive(relayBack);
			relayBack = "";
		}
	}
		
	// init
	private void init() {
		remotEndPoint = new IPEndPoint (IPAddress.Parse(IP), 26001);
		udp_obj = new UdpClient (26001);
		udp_obj.Client.ReceiveTimeout = 5000;
		receiveThread = new Thread (new ThreadStart (ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start ();
		StartCoroutine (initweb ());
		//gameObject.GetComponent<NetUDP> ().OnNetReady ();
	}

	private void ReceiveData() {
		while (true) {
			try {
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Broadcast, 26001);
				byte[] data = udp_obj.Receive(ref anyIP);
				string text = Encoding.UTF8.GetString(data);
				relayBack = text;
				//Debug.Log(text);
			}
			catch (Exception err) {
				Debug.Log(err.ToString());
			}
		}
	}

	public void sendUDPString(string message){
		try{
			byte [] data = Encoding.UTF8.GetBytes(message);
			udp_obj.Send(data, data.Length, remotEndPoint);
		} catch (Exception err){
			Debug.Log (err.ToString ());
		}
	}

	void OnDisable() {
		if ( receiveThread!= null)	receiveThread.Abort();
		udp_obj.Close();

		if (udp_obj != null)
			udp_obj.Close ();
	}
}