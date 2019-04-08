using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {
	public float speed = 3;
	public Vector3 startingPos;
	public float distance;
	public float direction;
	public string axis;

	void Start () {
		startingPos = transform.position;
	}

	void FixedUpdate () {
		if (axis == "x") {
			transform.position = new Vector3 (direction * Mathf.PingPong (Time.time * speed, distance) + startingPos.x, transform.position.y, transform.position.z);  
		} else if (axis == "y") {
			transform.position = new Vector3 (transform.position.x,direction * Mathf.PingPong (Time.time * speed, distance) +  startingPos.y, transform.position.z);
		}
		else if (axis == "z") {
			transform.position = new Vector3 (transform.position.x, transform.position.y, direction * Mathf.PingPong (Time.time * speed, distance) + startingPos.z);
		}
	}
}