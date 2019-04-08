using UnityEngine;
using System.Collections;

public class EnemyMover : MonoBehaviour {
	public float speed = 3;
	public float startingX;
	public float targetX;
	public float direction;

	void Update () {
		transform.position = new Vector3(direction * Mathf.PingPong(Time.time * speed, targetX*2)+startingX * direction, transform.position.y, transform.position.z);  
	}
}
