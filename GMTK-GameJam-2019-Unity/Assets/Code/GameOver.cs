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
            Menu.currentLevel++;
            if (Menu.currentLevel > 4) {
                Menu.currentLevel = 0;
                title.text = "The End";
                text.text = "Thanks for playing! We hope you enjoyed this little thing we made for GMTK GameJam 2019.";
                nextLevelButton.gameObject.SetActive(false);
            }
            else {
                title.text = "Level Clear";
                text.text = "You found the culprit, nice.";
            }
            nextLevelButton.onClick.AddListener(() => SceneManager.LoadScene(Menu.currentLevel));
        }
        menuButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        exitButton.onClick.AddListener(() => Application.Quit());
	}
}
