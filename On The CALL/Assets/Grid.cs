using UnityEngine;
using System.Collections;
[AddComponentMenu("Custom/Editor")]

public class Grid : MonoBehaviour
{
	public Object prefab;
	public bool placeOnNext = false;
	public float width = 5.0f;
	public float height = 5.0f;
	public Color color = Color.yellow;
	void OnDrawGizmos()
	{
		Vector3 pos = Camera.current.transform.position;
		Gizmos.color = color;
		for (float y = pos.y - 250.0f; y < pos.y + 250.0f; y+= height)
		{
			Gizmos.DrawLine(
				new Vector3(-250.0f + pos.x, Mathf.Floor(y/height) * height, 0.0f),
				new Vector3(250.0f + pos.x, Mathf.Floor(y/height) * height, 0.0f));
		}

		for (float x = pos.x - 250.0f; x < pos.x + 250.0f; x+= width)
		{
			
			Gizmos.DrawLine(
				new Vector3(Mathf.Floor(x/width) * width, -250.0f + pos.y, 0.0f),
				new Vector3(Mathf.Floor(x/width) * width, 250.0f + pos.y, 0.0f));
		}
	}
}