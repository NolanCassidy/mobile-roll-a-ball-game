using UnityEngine;
using System.Collections;

public class EnemySpinnerMover : MonoBehaviour {
	public float spinSpeed = 90;
	public float direction = 1;

	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime*spinSpeed*direction);
	}
}
