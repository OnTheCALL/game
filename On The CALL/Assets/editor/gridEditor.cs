using UnityEngine;
using UnityEditor;
using System.Collections;
[CustomEditor(typeof(Grid))]
public class GridEditor : Editor
{
	Grid grid;
	public void OnEnable()
	{
		grid = (Grid)target;
		SceneView.onSceneGUIDelegate += GridUpdate;
	}

	public void OnDisable()
	{
		SceneView.onSceneGUIDelegate -= GridUpdate;
	}
	void GridUpdate(SceneView sceneview)
	{
		Event e = Event.current;
		Ray r = Camera.current.ScreenPointToRay(new
			Vector3(e.mousePosition.x, -e.mousePosition.y +
				Camera.current.pixelHeight));
		Vector3 mousePos = r.origin;
		if(e.isKey && e.character == 'a')
		{
			GameObject obj;
			//Object prefab =
			//	EditorUtility.GetPrefabParent(Selection.activeObject);
			obj = (GameObject)PrefabUtility.InstantiatePrefab(grid.prefab);
			Vector3 aligned = new Vector3(
				Mathf.Floor(mousePos.x/grid.width)*grid.width + grid.width/2.0f,
				Mathf.Floor(mousePos.y/grid.height)*grid.height +
				grid.height/2.0f,
				0.0f);
			obj.transform.position = aligned;
		}
	}
}