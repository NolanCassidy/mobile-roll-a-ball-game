using UnityEngine;
using System;

public class CameraController : MonoBehaviour 
{
	public GameObject player;
	Vector3 offset;

	void Start () 
	{
		offset = transform.position;
	}

	void LateUpdate() 
	{
		if (player.transform.position.y >= -15) {
			transform.position = player.transform.position + offset;
		}
	}
}