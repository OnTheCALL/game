using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour {

	public GameObject[] toDisable;
	public GameObject loadtext;

	// Use this for initialization
	void Start () {
		
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
}
