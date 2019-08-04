using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	[SerializeField] Button playButton, aboutButton, creditsButton, exitButton, backButton;
    [SerializeField] GameObject title1, title2, about, copy1, copy2;

    public static bool gameover;
    public static int currentLevel;

    void Start () {
		playButton.onClick.AddListener(loadGame);
        aboutButton.onClick.AddListener(showAbout);
        creditsButton.onClick.AddListener(showCredits);
		exitButton.onClick.AddListener(() => Application.Quit());
        backButton.onClick.AddListener(showMenu);
        showMenu();
	}
	
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.E)) {
			Application.Quit();
		}
	}

	void loadGame() {
        gameover = false;
        currentLevel = 1;
		SceneManager.LoadScene(currentLevel);
	}

    void showAbout() { 
        title1.SetActive(false);
        title2.SetActive(true);
        about.SetActive(true);
        playButton.gameObject.SetActive(false);
        aboutButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);

    }

    void showCredits() {
        title1.SetActive(false);
        title2.SetActive(true);
        copy1.SetActive(true);
        copy2.SetActive(true);
        playButton.gameObject.SetActive(false);
        aboutButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);

    }

    void showMenu() {
        title1.SetActive(true);
        title2.SetActive(false);
        copy1.SetActive(false);
        copy2.SetActive(false);
        about.SetActive(false);
        playButton.gameObject.SetActive(true);
        aboutButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
    }
}
