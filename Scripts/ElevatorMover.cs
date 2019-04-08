using UnityEngine;
using System.Collections;

public class ElevatorMover : MonoBehaviour {

	public GameObject elevator;
	public GameObject Player;
	private bool elevatorMoving = false;

	void FixedUpdate () {
		if (elevatorMoving == true) {
			if (elevator.transform.position.y <= 9.9f) {
				elevator.transform.position = new Vector3 (elevator.transform.position.x, elevator.transform.position.y + 0.1f, elevator.transform.position.z);
			}
		}
		else if (elevatorMoving == false) {
			if (elevator.transform.position.y >= 1.1f) {
				elevator.transform.position = new Vector3 (elevator.transform.position.x, elevator.transform.position.y - 0.1f, elevator.transform.position.z);
			}
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.collider.gameObject.tag == "Player") {
			elevatorMoving = true;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if ((col.collider.gameObject.tag == "Player")) {
			elevatorMoving = false;
		}
	}
}
