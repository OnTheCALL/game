using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class echap_menu : MonoBehaviour {

	public bool OnPause = false;
	public GameObject Canvas_game;
	public GameObject Canvas_pause;

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
}
