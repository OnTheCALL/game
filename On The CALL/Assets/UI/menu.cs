using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;

public class menu : MonoBehaviour {

	public string VERSION_ACTUAL = "0.3.0-dev3";

	public GameObject pseudo_parent;
	public GameObject pass_parent;
	public GameObject maj_text;
	int isuptodate = -1;
	WWW downloadFM;
	JSONNode monObjFM;

	public GameObject[] toDisable;
	public GameObject loadtext;

	// Use this for initialization
	void Start () {
		fetch_text ();
		maj_text.GetComponent<Text> ().text = "Version : " + VERSION_ACTUAL + "\n\nRecherche de Mise A Jour ...";
		StartCoroutine (fetchVersion ());
	}

	void fetch_text(){
		pseudo_parent.GetComponent<InputField> ().text = PlayerPrefs.GetString ("user_name", "");
		pass_parent.GetComponent<InputField> ().text = PlayerPrefs.GetString ("user_password", "");
	}

	IEnumerator fetchVersion (){
		downloadFM = null;
		downloadFM = new WWW ("https://raw.githubusercontent.com/OnTheCALL/game/dev0.3/VERSION.json");
		yield return downloadFM;
		if (string.IsNullOrEmpty (downloadFM.error)) {
			monObjFM = JSON.Parse (downloadFM.text);
			if ((string)monObjFM ["Public_Version"] == VERSION_ACTUAL || (string)monObjFM ["Alpha_Version"] == VERSION_ACTUAL || (string)monObjFM ["Dev_Version"] == VERSION_ACTUAL) {
				maj_text.GetComponent<Text> ().text = "Version : " + VERSION_ACTUAL + "\n\nJeu à jour";
				isuptodate = 1;
			} else {
				isuptodate = 0;
				string compatible = monObjFM ["Compatible"];
				string[] datas = compatible.Split ('#');
				foreach (string line in datas) {
					if (line == VERSION_ACTUAL) {
						isuptodate = 1;
						maj_text.GetComponent<Text> ().text = "Version : " + VERSION_ACTUAL + "\n\nMise à jour disponible !";
					}
				}
				if (isuptodate != 1) {
					maj_text.GetComponent<Text> ().text = "Version : " + VERSION_ACTUAL + "\n\nMise à jour obligatoire !";
				}
			}
		} else {
			maj_text.GetComponent<Text> ().text = "Version : " + VERSION_ACTUAL + "\n\nErreur serveur";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeScene (int nb) {
		if (isuptodate == 1) {
			for (int i = 0; i < toDisable.Length; i++) {
				toDisable [i].GetComponent<Button> ().interactable = false;
			}
			loadtext.GetComponent<Text> ().text = "Loading ...";
			PlayerPrefs.SetString ("user_name", pseudo_parent.GetComponent<InputField> ().text);
			PlayerPrefs.SetString ("user_password", pass_parent.GetComponent<InputField> ().text);
			PlayerPrefs.Save ();
			SceneManager.LoadSceneAsync (nb);
		} else {
			loadtext.GetComponent<Text> ().text = "Faite la mise à jour, puis relancer le jeu";
		}
	}

	public void MAJuser(){
		PlayerPrefs.SetString ("user_name", pseudo_parent.GetComponent<InputField> ().text);
		PlayerPrefs.Save ();
	}
	public void MAJpass(){
		PlayerPrefs.SetString ("user_password", pass_parent.GetComponent<InputField> ().text);
		PlayerPrefs.Save ();
	}
}
