using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class IG_menu : MonoBehaviour {

	public GameObject panel;
	public GameObject title;
	public GameObject opt1;
	public GameObject opt2;
	public GameObject opt3;
	public GameObject opt4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenMenu(string Title, string[] Opts, string[] Actions) {
		panel.GetComponent<Image> ().enabled = true;
		title.GetComponent<Text> ().text = Title;
	}
}
