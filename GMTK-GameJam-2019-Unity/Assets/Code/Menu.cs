﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	[SerializeField] Button playButton, creditsButton, exitButton, backButton;
    [SerializeField] GameObject title1, title2, copy1, copy2;
	
	void Start () {
		playButton.onClick.AddListener(loadGame);
        creditsButton.onClick.AddListener(showCredits);
		exitButton.onClick.AddListener(exitGame);
        backButton.onClick.AddListener(showMenu);
        showMenu();
	}
	
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.E)) {
			Application.Quit();
		}
	}

	void loadGame() {
		SceneManager.LoadScene("Main");
	}

	void exitGame() {
		Application.Quit();
	}

    void showCredits() {
        title1.SetActive(false);
        title2.SetActive(true);
        copy1.SetActive(true);
        copy2.SetActive(true);
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);

    }

    void showMenu() {
        title1.SetActive(true);
        title2.SetActive(false);
        copy1.SetActive(false);
        copy2.SetActive(false);
        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
    }
}
