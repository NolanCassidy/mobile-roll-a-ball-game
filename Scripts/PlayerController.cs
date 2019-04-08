using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{


	public float speed = 800.0f;
	public float velocity = 0.0f;
	public float speedMobile = 1200.0f;
	public Text scoreText;
	private int count = 0;
	public Text WinText;
	public Button NewGame;
	public GameObject exitRamp;
	public GameObject EnemySpinner;
	private Vector3 resetPosition;
	private int lives = 5;
	public Text livesText;


	void Start()
	{

		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		//resetPosition = transform.position = new Vector3 (0.0f, 1.5f, 0.0f);
		resetPosition = transform.position = new Vector3 (0.0f, 0.5f, 0.0f);

		//resetPlayer();
	}

	void FixedUpdate()
	{

		#if UNITY_WEBPLAYER || UNITY_STANDALONE_WIN || UNITY_STANDALONE || UNITY_EDITOR
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
		#endif

		#if UNITY_IPHONE || UNITY_ANDROID
		float moveHorizontalMobile = Input.acceleration.x;
		float moveVerticalMobile = Input.acceleration.y;
		Vector3 movementMobile = new Vector3 (moveHorizontalMobile, 0.0f, moveVerticalMobile);
		GetComponent<Rigidbody> ().AddForce (movementMobile * speedMobile * Time.deltaTime);
		#endif

		if (transform.position.y <= -110) {
			resetPlayer();
		}


		if (transform.position.z >= 50) {
			resetPosition =new Vector3(0.0f, 1.5f, 52.0f);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Portal") {
			Application.LoadLevel("WinScene");
		}

		if (other.gameObject.tag == "Enemy") {
			resetPlayer();
		}

		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			count +=1;
			scoreText.text = "Score: " + count;

			if(count >= 8)
			{
				//WinText.gameObject.SetActive(true);
				//NewGame.gameObject.SetActive(true);
				exitRamp.gameObject.SetActive(true);
			}
		}
	}

	void resetPlayer()
	{
		lives -= 1;
		livesText.text = "Lives: " + lives;

		if (lives <= 0) 
		{
			Application.LoadLevel ("GameOverScene");
		} 
		else 
		{
			transform.position = resetPosition;
			GetComponent<Rigidbody>().velocity = new Vector3 (0.0f, 0.0f, 0.0f);
			//GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f, 0.5f, 0.0f);
		}

	}


}
