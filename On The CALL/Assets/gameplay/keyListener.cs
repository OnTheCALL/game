﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyListener : MonoBehaviour {

	/*private bool listen_goUp = true;
	private bool listen_goDown = true;
	private bool listen_goLeft = true;
	private bool listen_goRight = true;*/
	private bool listen_Interact = true;
	private bool listen_getput = true;
	private bool listen_car = true;
	private bool listen_menu1 = true;
	private bool listen_menu2 = true;
	private bool listen_menu3 = true;
	private bool listen_menu4 = true;
	private bool listen_code1 = true;
	private bool listen_code2 = true;
	private bool listen_code3 = true;

	public KeyCode convertKey (string name){
		if (name == "A") { return KeyCode.A; }
		else if (name == "B") { return KeyCode.B; }
		else if (name == "C") { return KeyCode.C; }
		else if (name == "D") { return KeyCode.D; }
		else if (name == "E") { return KeyCode.E; }
		else if (name == "F") { return KeyCode.F; }
		else if (name == "G") { return KeyCode.G; }
		else if (name == "H") { return KeyCode.H; }
		else if (name == "I") { return KeyCode.I; }
		else if (name == "J") { return KeyCode.J; }
		else if (name == "K") { return KeyCode.K; }
		else if (name == "L") { return KeyCode.L; }
		else if (name == "M") { return KeyCode.M; }
		else if (name == "N") { return KeyCode.N; }
		else if (name == "O") { return KeyCode.O; }
		else if (name == "P") { return KeyCode.P; }
		else if (name == "Q") { return KeyCode.Q; }
		else if (name == "R") { return KeyCode.R; }
		else if (name == "S") { return KeyCode.S; }
		else if (name == "T") { return KeyCode.T; }
		else if (name == "U") { return KeyCode.U; }
		else if (name == "V") { return KeyCode.V; }
		else if (name == "W") { return KeyCode.W; }
		else if (name == "X") { return KeyCode.X; }
		else if (name == "Y") { return KeyCode.Y; }
		else if (name == "Z") { return KeyCode.Z; }
		else if (name == "Left Shift") { return KeyCode.LeftShift; }
		else if (name == "Right Shift") { return KeyCode.RightShift; }
		else if (name == "Left Ctrl") { return KeyCode.LeftControl; }
		else if (name == "Right Ctrl") { return KeyCode.RightControl; }
		else if (name == "Space") { return KeyCode.Space; }
		else if (name == "0") { return KeyCode.Alpha0; }
		else if (name == "1") { return KeyCode.Alpha1; }
		else if (name == "2") { return KeyCode.Alpha2; }
		else if (name == "3") { return KeyCode.Alpha3; }
		else if (name == "4") { return KeyCode.Alpha4; }
		else if (name == "5") { return KeyCode.Alpha5; }
		else if (name == "6") { return KeyCode.Alpha6; }
		else if (name == "7") { return KeyCode.Alpha7; }
		else if (name == "8") { return KeyCode.Alpha8; }
		else if (name == "9") { return KeyCode.Alpha9; }
		else {
			return KeyCode.Escape;
		}
	}

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("AlreadySet", 0) == 0) {
			PlayerPrefs.SetString ("keyboard_goUp", "Z");
			PlayerPrefs.SetString ("keyboard_goDown", "S");
			PlayerPrefs.SetString ("keyboard_goLeft", "Q");
			PlayerPrefs.SetString ("keyboard_goRight", "D");
			PlayerPrefs.SetString ("keyboard_car", "Space");
			PlayerPrefs.SetString ("keyboard_walk", "Left Shift");
			PlayerPrefs.SetString ("keyboard_interact", "E");
			PlayerPrefs.SetString ("keyboard_cone", "C");
			PlayerPrefs.SetString ("keyboard_code1", "1");
			PlayerPrefs.SetString ("keyboard_code2", "2");
			PlayerPrefs.SetString ("keyboard_code3", "3");
			PlayerPrefs.SetString ("keyboard_menu1", "1");
			PlayerPrefs.SetString ("keyboard_menu2", "2");
			PlayerPrefs.SetString ("keyboard_menu3", "3");
			PlayerPrefs.SetString ("keyboard_menu4", "4");
			PlayerPrefs.SetInt ("AlreadySet", 1);
			PlayerPrefs.Save ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<perso> ().goUp = Input.GetKey (convertKey (PlayerPrefs.GetString ("keyboard_goUp", "Z"))) && gameObject.GetComponent<perso> ().inacar == false;
		gameObject.GetComponent<perso> ().goDown = Input.GetKey (convertKey (PlayerPrefs.GetString ("keyboard_goDown", "S"))) && gameObject.GetComponent<perso> ().inacar == false;
		gameObject.GetComponent<perso> ().goLeft = Input.GetKey (convertKey (PlayerPrefs.GetString ("keyboard_goLeft", "Q"))) && gameObject.GetComponent<perso> ().inacar == false;
		gameObject.GetComponent<perso> ().goRight = Input.GetKey (convertKey (PlayerPrefs.GetString ("keyboard_goRight", "D"))) && gameObject.GetComponent<perso> ().inacar == false;
		gameObject.GetComponent<perso> ().iswalking = Input.GetKey (convertKey (PlayerPrefs.GetString ("keyboard_walk", "Left Shift"))) && gameObject.GetComponent<perso> ().inacar == false;

		if (listen_menu1 && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_menu1","1"))) && gameObject.GetComponent<perso>().inacar == false) {
			listen_menu1 = false;
			gameObject.GetComponent<perso> ().World.GetComponent<IG_menu> ().press1 ();
		}
		if (listen_menu2 && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_menu2","2"))) && gameObject.GetComponent<perso>().inacar == false) {
			listen_menu2 = false;
			gameObject.GetComponent<perso> ().World.GetComponent<IG_menu> ().press2 ();
		}
		if (listen_menu3 && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_menu3","3"))) && gameObject.GetComponent<perso>().inacar == false) {
			listen_menu3 = false;
			gameObject.GetComponent<perso> ().World.GetComponent<IG_menu> ().press3 ();
		}
		if (listen_menu4 && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_menu4","4"))) && gameObject.GetComponent<perso>().inacar == false) {
			listen_menu4 = false;
			gameObject.GetComponent<perso> ().World.GetComponent<IG_menu> ().press4 ();
		}
		if (listen_car && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_car","Space"))) && gameObject.GetComponent<perso>().inacar == false) {
			listen_car = false;
			if (gameObject.GetComponent<getCollides> ().nearVhc != null) {
				gameObject.GetComponent<getCollides> ().nearVhc.GetComponent<VHC> ().enter (gameObject, gameObject.GetComponent<perso> ().skin);
			}
		}
		if (listen_car && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_car","Space"))) && gameObject.GetComponent<perso>().inacar == true) {
			listen_car = false;
			if (gameObject.GetComponent<getCollides> ().nearVhc != null) {
				gameObject.GetComponent<getCollides> ().nearVhc.GetComponent<VHC> ().exit ();
			}
		}
		if (listen_code1 && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_code1","1"))) && gameObject.GetComponent<perso>().inacar == true) {
			listen_code1 = false;
			if (gameObject.GetComponent<getCollides> ().nearVhc != null) {
				gameObject.GetComponent<getCollides> ().nearVhc.GetComponent<VHC> ().change_code (1, false);
			}
		}
		if (listen_code2 && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_code2","2"))) && gameObject.GetComponent<perso>().inacar == true) {
			listen_code2 = false;
			if (gameObject.GetComponent<getCollides> ().nearVhc != null) {
				gameObject.GetComponent<getCollides> ().nearVhc.GetComponent<VHC> ().change_code (2, false);
			}
		}
		if (listen_code3 && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_code3","3"))) && gameObject.GetComponent<perso>().inacar == true) {
			listen_code3 = false;
			if (gameObject.GetComponent<getCollides> ().nearVhc != null) {
				gameObject.GetComponent<getCollides> ().nearVhc.GetComponent<VHC> ().change_code (3, false);
			}
		}
		if (listen_Interact && Input.GetKeyDown(convertKey(PlayerPrefs.GetString("keyboard_interact","E"))) && gameObject.GetComponent<perso>().inacar == false) {
			listen_Interact = false;
			if (gameObject.GetComponent<getCollides> ().nearOrdi == true) {
				gameObject.GetComponent<perso> ().World.GetComponent<actions> ().DoAction ("open Ordi");
			}
		}

		if (Input.GetKeyUp (convertKey (PlayerPrefs.GetString ("keyboard_car", "Space")))) {
			listen_car = true;
		}
		if (gameObject.GetComponent<perso>().inacar == false && Input.GetKeyUp (convertKey (PlayerPrefs.GetString ("keyboard_menu1", "1")))) {
			listen_menu1 = true;
		}
		if (gameObject.GetComponent<perso>().inacar == false && Input.GetKeyUp (convertKey (PlayerPrefs.GetString ("keyboard_menu2", "2")))) {
			listen_menu2 = true;
		}
		if (gameObject.GetComponent<perso>().inacar == false && Input.GetKeyUp (convertKey (PlayerPrefs.GetString ("keyboard_menu3", "3")))) {
			listen_menu3 = true;
		}
		if (gameObject.GetComponent<perso>().inacar == false && Input.GetKeyUp (convertKey (PlayerPrefs.GetString ("keyboard_menu4", "4")))) {
			listen_menu4 = true;
		}

		if (gameObject.GetComponent<perso>().inacar == true && Input.GetKeyUp (convertKey (PlayerPrefs.GetString ("keyboard_code1", "1")))) {
			listen_code1 = true;
		}
		if (gameObject.GetComponent<perso>().inacar == true && Input.GetKeyUp (convertKey (PlayerPrefs.GetString ("keyboard_code2", "2")))) {
			listen_code2 = true;
		}
		if (gameObject.GetComponent<perso>().inacar == true && Input.GetKeyUp (convertKey (PlayerPrefs.GetString ("keyboard_code3", "3")))) {
			listen_code3 = true;
		}
		if (gameObject.GetComponent<perso>().inacar == false && Input.GetKeyUp (convertKey (PlayerPrefs.GetString ("keyboard_interact", "E")))) {
			listen_Interact = true;
		}
	}
}
