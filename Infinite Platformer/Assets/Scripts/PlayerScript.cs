using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float jumpPower = 10.0f;
	Rigidbody2D myRigidbody;
	public bool isGrounded = false;
	float posX = 0.0f;
	bool isGameOver = false;
	ChallengeController myChallengeController;
	GameController myGameController;
	LightSpawner ls;
	public AudioClip jump;
	public AudioClip coin;
	public AudioClip dead;
	AudioSource myAudioSource;
	Animator anim;

	// Use this for initialization
	void Start () {
	
		myRigidbody = transform.GetComponent<Rigidbody2D> ();
		posX = transform.position.x;
		myChallengeController = GameObject.FindObjectOfType<ChallengeController> ();
		myGameController = GameObject.FindObjectOfType<GameController> ();
		ls = GameObject.FindObjectOfType<LightSpawner> ();
		myAudioSource = GameObject.FindObjectOfType<AudioSource> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if (Input.GetMouseButton(0) && isGrounded && !isGameOver) {
		
			myRigidbody.AddForce (Vector2.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale) * 20.0f);
			anim.SetFloat ("jump", jumpPower);
			myAudioSource.PlayOneShot (jump);
		}

		if (transform.position.x < posX && !isGameOver) {
			
			GameOver ();
		}



	}

	void GameOver() {
		myAudioSource.PlayOneShot (dead);
		isGameOver = true;
		anim.SetBool ("death", true);
		myChallengeController.GameOver ();
		ls.gover = true;

	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.collider.tag == "Floor") {

			isGrounded = true;
		}

		if (other.collider.tag == "Enemy") {
		
			myAudioSource.PlayOneShot (dead);
			GameOver ();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
	
		if (other.tag == "Coin") {
		
			myGameController.IncrementScore ();
			Destroy (other.gameObject);
			myAudioSource.PlayOneShot (coin);
		}
	}

	void OnCollisionStay2D(Collision2D other) {

		if (other.collider.tag == "Floor") {

			isGrounded = true;
			anim.SetFloat ("jump", 0f);
		}
	}

	void OnCollisionExit2D(Collision2D other) {

		if (other.collider.tag == "Floor") {

			isGrounded = false;
		}
	}
}
