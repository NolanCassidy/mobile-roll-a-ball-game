using UnityEngine;
using System.Collections;

public class RestartButtonController : MonoBehaviour {
	
	public void restartGame () {
		Application.LoadLevel ("MainScene");
	}
}
