using UnityEngine;
using System.Collections;

public class ChallengeController : MonoBehaviour {

	public float scrollSpeed = 5.0f;
	public GameObject[] challenges;
	public float frequency = 0.5f;
	float counter = 0.0f;
	public Transform challengesSpawnPoint;
	public bool isGameOver = false;

	// Use this for initialization
	void Start () {
	
		GenerateRandomChallenges ();
	}
		
	// Update is called once per frame
	void Update () {

		if (isGameOver)
			return;

		if (counter <= 0.0f) {
		
			GenerateRandomChallenges ();
		} else {
		
			counter -= Time.deltaTime * frequency;
		}

	
		GameObject currentObject;
		for (int i = 0; i < transform.childCount; i++) {
			currentObject = transform.GetChild (i).gameObject;
			ScrollChallenge (currentObject);
			if (currentObject.transform.position.x <= -15f) {
				Destroy (currentObject);
			}
		}
	}

	void ScrollChallenge (GameObject currentChallenge) {
	
		currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
	}

	void GenerateRandomChallenges () {
		GameObject newChallenge = Instantiate (challenges [Random.Range (0, challenges.Length)], challengesSpawnPoint.position, Quaternion.identity) as GameObject;
		newChallenge.transform.parent = transform;
		counter = 1.0f;
	}

	public void GameOver() {
		isGameOver = true;
		transform.GetComponent<GameController> ().GameOver();
	}
}