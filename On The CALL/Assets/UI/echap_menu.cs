using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using AOT;

public class echap_menu : MonoBehaviour {

	public bool OnPause = false;
	public GameObject Canvas_game;
	public GameObject Canvas_pause;
	public GameObject Chat_zone;
	public GameObject Chat_input;
	public GameObject Chat_button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Disconnect (string reason = "disconnect", int continuewith = 0){
		WWWForm formDisco = new WWWForm ();
		formDisco.AddField ("ID", gameObject.GetComponent<fromNetwork>().ID);
		formDisco.AddField ("reason", reason);
		WWW downloadDisco = new WWW ("https://cta.loulou123546.fr/gameAPI/disconnect", formDisco);
		yield return downloadDisco;
		if (continuewith == 0) {
			SceneManager.LoadSceneAsync (0);
		} else {
			Application.Quit ();
		}
	}
	IEnumerator SendNTMessage (string text = "no message", string pseudo = "no name"){
		WWWForm formMsg = new WWWForm ();
		formMsg.AddField ("user", pseudo);
		formMsg.AddField ("msg", text);
		WWW downloadMsg = new WWW ("https://cta.loulou123546.fr/gameAPI/newMSG", formMsg);
		yield return downloadMsg;
		Chat_button.GetComponent<Button> ().interactable = true;
	}

	public void BackMenu (){
		StartCoroutine (Disconnect ("disconnect", 0));
	}

	public void QuitApp (){
		StartCoroutine (Disconnect ("disconnect", 1));
	}

	public void TogglePause (){
		if (OnPause == true) {
			OnPause = false;
			Canvas_pause.SetActive (false);
			Canvas_game.SetActive (true);
		} else {
			OnPause = true;
			Canvas_pause.SetActive (true);
			Canvas_game.SetActive (false);
		}
	}

	public void SendMessage (){
		Chat_button.GetComponent<Button> ().interactable = false;
		string presend = Chat_input.GetComponent<InputField> ().text;
		string author = PlayerPrefs.GetString ("user_name", "Inconnu");
		Chat_input.GetComponent<InputField> ().text = "";
		StartCoroutine (SendNTMessage(presend, author));
	}

	public void DEV_respawn (){
		gameObject.GetComponent<actions> ().main_character.GetComponent<Transform> ().position = new Vector3 (36.42f, -7.6f, -10.0f);
	}

	public void Discord_start_test(){
		
	}

	public void Discord_stop_test(){
		
	}
}
