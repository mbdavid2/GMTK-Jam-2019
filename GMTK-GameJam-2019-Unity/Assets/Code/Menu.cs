using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Button playButton;
	public Button exitButton;
	
	void Start () {
		playButton.onClick.AddListener(loadGame);
		exitButton.onClick.AddListener(exitGame);
	}
	
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.E)) {
			Application.Quit();
		}
	}

	private void loadGame() {
		SceneManager.LoadScene("Main");
	}

	private void exitGame() {
		Application.Quit();
	}
}
