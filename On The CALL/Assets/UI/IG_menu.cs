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
	string[] acts = {"","","",""};
	public GameObject hours_text;
	public GameObject truck_text;
	public GameObject bip_text;
	public GameObject chat_text_1;
	public GameObject chat_text_2;
	public GameObject chat_inter;
	public GameObject speak_to_vic;
	public GameObject in_hand;
	public Sprite[] items;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void press1(){
		if (panel.GetComponent<Image> ().enabled == true) {
			gameObject.GetComponent<actions> ().DoAction (acts [0]);
		}
	}
	public void press2(){
		if (panel.GetComponent<Image> ().enabled == true) {
			gameObject.GetComponent<actions> ().DoAction (acts [1]);
		}
	}
	public void press3(){
		if (panel.GetComponent<Image> ().enabled == true) {
			gameObject.GetComponent<actions> ().DoAction (acts [2]);
		}
	}
	public void press4(){
		if (panel.GetComponent<Image> ().enabled == true) {
			gameObject.GetComponent<actions> ().DoAction (acts [3]);
		}
	}
	public void pressY(){
		if (speak_to_vic.activeSelf == false) {
			speak_to_vic.GetComponent<InputField> ().text = "";
			speak_to_vic.SetActive (true);
			speak_to_vic.GetComponent<InputField> ().Select ();
			speak_to_vic.GetComponent<InputField> ().ActivateInputField ();
		}
	}
	public void pressEnter(){
		if (speak_to_vic.activeSelf == true) {
			gameObject.GetComponent<NetTCP> ().DoAction ("victime_talk", speak_to_vic.GetComponent<InputField> ().text);
			Debug.Log(speak_to_vic.GetComponent<InputField> ().text);
			speak_to_vic.GetComponent<InputField> ().text = "";
			speak_to_vic.SetActive (false);
		}
	}
	public void pressEsc(){
		if (speak_to_vic.activeSelf == true) {
			speak_to_vic.GetComponent<InputField> ().text = "";
			speak_to_vic.SetActive (false);
		}
	}

	public void OpenMenu(string Title, string name1 = "", string act1 = "", string name2 = "", string act2 = "", string name3 = "", string act3 = "", string name4 = "", string act4 = "") {
		panel.GetComponent<Image> ().enabled = true;
		title.GetComponent<Text> ().text = Title;
		if (name1 != "") { opt1.GetComponent<Text> ().text = "1) " + name1; }
		if (name2 != "") { opt2.GetComponent<Text> ().text = "2) " + name2; }
		if (name3 != "") { opt3.GetComponent<Text> ().text = "3) " + name3; }
		if (name4 != "") { opt4.GetComponent<Text> ().text = "4) " + name4; }
		acts [0] = act1;
		acts [1] = act2;
		acts [2] = act3;
		acts [3] = act4;
	}

	public void CloseMenu(){
		panel.GetComponent<Image> ().enabled = false;
		title.GetComponent<Text> ().text = "";
		opt1.GetComponent<Text> ().text = "";
		opt2.GetComponent<Text> ().text = "";
		opt3.GetComponent<Text> ().text = "";
		opt4.GetComponent<Text> ().text = "";
		acts [0] = "";
		acts [1] = "";
		acts [2] = "";
		acts [3] = "";
	}

	public void set_bip_hour(string text){
		hours_text.GetComponent<Text>().text = text;
	}
	public void set_bip_vhc(string text){
		truck_text.GetComponent<Text>().text = text;
	}
	public void set_bip_msg(string text){
		bip_text.GetComponent<Text>().text = text;
	}
	public void update_chat(string text){
		chat_text_1.GetComponent<Text>().text = text;
		chat_text_2.GetComponent<Text>().text = text;
	}
	public void msg_inter(string text){
		chat_inter.GetComponent<Text>().text = text;
	}

	public void change_tool(string text){
		if (text == "hand") {
			in_hand.GetComponent<Image> ().sprite = items [0];
		} else if(text == "medpack"){
			in_hand.GetComponent<Image> ().sprite = items [1];
		} else if(text == "brancard"){
			in_hand.GetComponent<Image> ().sprite = items [2];
		}
	}

	public string get_tool(){
		if (in_hand.GetComponent<Image> ().sprite == items [1]) {
			return "medpack";
		} else if (in_hand.GetComponent<Image> ().sprite == items [2]) {
			return "brancard";
		} else {
			return "hand";
		}
	}
}
