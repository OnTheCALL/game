using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour {

	public GameObject pseudo;
	public GameObject pass;

	public GameObject[] toDisable;
	public GameObject loadtext;

	// Use this for initialization
	void Start () {
		pseudo.GetComponent<Text> ().text = PlayerPrefs.GetString ("user_name", "");
		pass.GetComponent<Text> ().text = PlayerPrefs.GetString ("user_password", "");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeScene (int nb) {
		for (int i = 0; i < toDisable.Length; i++){
			toDisable [i].GetComponent<Button> ().interactable = false;
		}
		loadtext.GetComponent<Text> ().text = "Loading ...";
		SceneManager.LoadSceneAsync (nb);
	}

	public void MAJuser(){
		PlayerPrefs.SetString ("user_name", pseudo.GetComponent<Text> ().text);
		PlayerPrefs.Save ();
	}
	public void MAJpass(){
		PlayerPrefs.SetString ("user_password", pass.GetComponent<Text> ().text);
		PlayerPrefs.Save ();
	}
}
