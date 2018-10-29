using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class fromNetwork : MonoBehaviour {

	public float next_in = 0.5f;
	WWWForm form;
	WWW download;
	string fromWeb = "";
	public GameObject chat;
	JSONNode monObj;

	// Use this for initialization
	void Start () {
		form = new WWWForm ();
		form.AddField ("fromGame", 1);
	}

	IEnumerator fetchMainData (){
		download = new WWW ("https://cta.loulou123546.fr/gameAPI/fetch", form);
		yield return download;
		if (string.IsNullOrEmpty (download.error)) {
			fromWeb = "";
			monObj = JSON.Parse(download.text);
			chat.GetComponent<Text>().text = monObj["chat"];
		}
	}
	
	// Update is called once per frame
	void Update () {
		next_in = next_in - Time.deltaTime;
		if (next_in <= 0) {
			next_in = next_in + 2.0f;
			if (download == null || download.isDone == true) {
				StartCoroutine (fetchMainData ());
			}
		}
	}
}
