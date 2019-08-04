using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    [SerializeField] Button nextLevelButton, menuButton, exitButton;
    [SerializeField] Text title, text;

    // Use this for initialization
    void Start () {
        if (Menu.gameover) {
            nextLevelButton.gameObject.SetActive(false);
            text.text = "You lose, better luck next time.";
        }
        else {
            //Menu.currentLevel++;
            //if currentLvl == maxLvl finestra fi
            title.text = "Level Clear";
            text.text = "You found the culprit, nice.";
            Menu.currentLevel++;
            if (Menu.currentLevel >= 5) Menu.currentLevel = 0;
            print(Menu.currentLevel);
            nextLevelButton.onClick.AddListener(() => SceneManager.LoadScene(Menu.currentLevel));
        }
        menuButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        exitButton.onClick.AddListener(() => Application.Quit());
	}
}
