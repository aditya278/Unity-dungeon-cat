using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject gameOverPanel;
	public Text scoreText;
	int score = 0;
	public Text bestText;
	public Text uText;
	public GameObject newAlert;
	public GameObject bImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameOver() {
		
		scoreText.gameObject.SetActive (false);
		gameOverPanel.SetActive (true);
		bImage.SetActive (false);

		if (score > PlayerPrefs.GetInt ("best", 0)) {
		
			PlayerPrefs.SetInt ("best", score);
			newAlert.SetActive (true);
		}

		bestText.text = "Best Score: " + PlayerPrefs.GetInt ("best", 0).ToString();
		uText.text = "Your Score: " + score.ToString ();

	}

	public void Restart() {
	
		Application.LoadLevel ("Level1");
	}

	public void IncrementScore() {
	
		score++;
		scoreText.text = "Score: "+score.ToString ();
	}
}
