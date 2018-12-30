using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED_model : MonoBehaviour {

	/* Modes :
	 * 0 : off
	 * 1 : blink sync (FPTSR)
	 * 2 : cross
	 * 3 : arrowLeft
	 * 4 : arrow Right
	 */
	public bool[] TurnOnFor = { true, false, false, false, false };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void send (float TimeS, int mode){
		if (TurnOnFor [mode] == false) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		} else if (mode == 1) {
			if (TimeS % 0.3f >= 0.15f) {
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			} else {
				gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			}
		}
	}
}
