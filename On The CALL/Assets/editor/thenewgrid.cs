/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class thenewgrid : EditorWindow {

	GameObject gridmanager;
	public GameObject spawnable;
	public bool enableGrid = true;
	public float Zaxis = 0.0f;

	[MenuItem ("Window/My Window")]

	public static void  ShowWindow () {
		EditorWindow.GetWindow(typeof(thenewgrid));
	}
	
	void OnGUI () {
		gridmanager = (GameObject)EditorGUILayout.ObjectField ("Grid (gameobject)", gridmanager, typeof(GameObject), true);
		enableGrid = EditorGUILayout.Toggle ("Actif", enableGrid);
		spawnable = (GameObject)EditorGUILayout.ObjectField ("Prefab", spawnable, typeof(GameObject), true);
		Zaxis = EditorGUILayout.FloatField ("Rotation", Zaxis);

	}

	public float width = 5.0f;
	public float height = 5.0f;
	public Color color = Color.yellow;

	void Update(){
		gridmanager.GetComponent<Grid> ().prefab = spawnable;
		if (enableGrid == true) {
			gridmanager.GetComponent<Grid> ().color = Color.yellow;
		} else {
			gridmanager.GetComponent<Grid> ().color = Color.clear;
		}
	}

	public void OtherThing(){
		if (enableGrid == true) {
			Debug.Log ("pressed I ? or fail ?");
			gridmanager.GetComponent<Grid> ().placeOnNext = true;
		}
	}

	[MenuItem("MyMenu/Add Tiles _i")]
	static void DoSomethingWithAShortcutKey()
	{
		//OtherThing ();
	}
}*/
