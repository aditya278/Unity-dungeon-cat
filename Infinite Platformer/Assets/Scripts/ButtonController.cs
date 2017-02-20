using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	public GameObject mainMenuPanel;
	public GameObject instructionPanel;

	public void NewGameBtn (string newGameLevel) {
	
		SceneManager.LoadScene ("Level1");
	}

	public void ExitGameBtn() {
	
		Application.Quit ();
	}

	public void InstructionBtn() {
	
		mainMenuPanel.SetActive (false);
		instructionPanel.SetActive (true);
	}

	public void BackBtn() {
	
		instructionPanel.SetActive (false);
		mainMenuPanel.SetActive (true);
	}

	public void GoToMainMenu() {
	
		SceneManager.LoadScene ("MainMenu");
	}
}
