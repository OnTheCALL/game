using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour {

	public GameObject pseudo_parent;
	public GameObject pass_parent;

	public GameObject[] toDisable;
	public GameObject loadtext;

	// Use this for initialization
	void Start () {
		fetch_text ();
	}

	void fetch_text(){
		pseudo_parent.GetComponent<InputField> ().text = PlayerPrefs.GetString ("user_name", "");
		pass_parent.GetComponent<InputField> ().text = PlayerPrefs.GetString ("user_password", "");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeScene (int nb) {
		for (int i = 0; i < toDisable.Length; i++){
			toDisable [i].GetComponent<Button> ().interactable = false;
		}
		loadtext.GetComponent<Text> ().text = "Loading ...";
		PlayerPrefs.SetString ("user_name", pseudo_parent.GetComponent<InputField> ().text);
		PlayerPrefs.SetString ("user_password", pass_parent.GetComponent<InputField> ().text);
		PlayerPrefs.Save ();
		SceneManager.LoadSceneAsync (nb);
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
