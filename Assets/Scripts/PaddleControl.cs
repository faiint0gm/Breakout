using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour {

	public float timeFactor = 10f;
	private Vector3 playerPos = new Vector3 (0,-10,0);

	void Start()
	{
		Cursor.visible = false;
	}
	void Update () {

		if (Input.GetKey(KeyCode.Escape))
			{
				Cursor.visible = true;
			}
		float xPosition = transform.position.x + (Input.GetAxis("Mouse X"))*Time.deltaTime * timeFactor;
		playerPos = new Vector3 (Mathf.Clamp (xPosition, -8f, 8f), -10, 0);
		transform.position = playerPos;
	}
}
