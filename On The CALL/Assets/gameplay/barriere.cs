using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barriere : MonoBehaviour {

	Hashtable opening = new Hashtable();
	Hashtable closing = new Hashtable();
	public GameObject bar_L;
	public GameObject bar_R;
	// To be compatible in the four direction, if x take 1 or -1, y take 0, and vice-versa
	public float x_pos_or_neg = 0.0f;
	public float y_pos_or_neg = -1.0f;
	Vector3 xPosL;
	Vector3 xPosR;

	// Use this for initialization
	void Start () {
		//opening.Add ("name", "Opening");
		opening.Add ("x", 0.05f);
		opening.Add ("time", 2.0f);
		//closing.Add ("name", "Closing");
		closing.Add ("x", 1.0f);
		//closing.Add ("delay", 0.5f);
		closing.Add ("time", 3.0f);
		xPosL = bar_L.GetComponent<Transform> ().position;
		xPosR = bar_R.GetComponent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Wait(float nb){
		yield return new WaitForSeconds (nb);
	}

	void OnTriggerEnter(Collider col){
		iTween.Stop (bar_L);
		iTween.Stop (bar_R);
		StartCoroutine(Wait(0.1f));
		iTween.ScaleTo (bar_L, opening);
		iTween.MoveTo (bar_L, new Vector3 (xPosL.x + (x_pos_or_neg * 0.9f), xPosL.y + (y_pos_or_neg * 0.9f), xPosL.z), 2.0f);
		iTween.ScaleTo (bar_R, opening);
		iTween.MoveTo (bar_R, new Vector3 (xPosR.x + (x_pos_or_neg * -0.9f), xPosR.y + (y_pos_or_neg * -0.9f), xPosR.z), 2.0f);
	}

	void OnTriggerExit(Collider col){
		iTween.ScaleTo (bar_L, closing);
		iTween.MoveTo (bar_L, xPosL, 3.0f);
		iTween.ScaleTo (bar_R, closing);
		iTween.MoveTo (bar_R, xPosR, 3.0f);
	}
}
