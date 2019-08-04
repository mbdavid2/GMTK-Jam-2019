using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    [SerializeField] Button nextLevelButton, menuButton, exitButton;
    [SerializeField] Text title, text;
    [SerializeField] AudioSource win, lose;

    void Start () {
        string[] quotes = new string[10];
        quotes[0] = "\"The world is full of obvious things which nobody by any chance ever observes.\"\n-Arthur Conan Doyle";
        quotes[1] = "\"The detective and his criminal wear versions of the same mask.\"\n-Jane Roberts";
        quotes[2] = "\"A detective sees death in all the various forms at least five times a week.\"\n-Evan Hunter";
        quotes[3] = "\"The instant they say something you don't expect or already know, you should drop into detective mode.\"\n-Emmett Shear";
        quotes[4] = "\"To read of a detective's daring finesse or ingenious stratagem is a rare joy.\"\n-Rex Stout";
        quotes[5] = "\"The main purpose of a significance test is to inhibit the natural enthusiasm of the investigator.\"\n-Frederick Mosteller";
        quotes[6] = "\"Read like a detective and write like a conscientious investigative reporter.\"\n-David Coleman";
        quotes[7] = "\"The criminal is the creative artist; the detective only the critic.\"\n-Gilbert K. Chesterton";
        quotes[8] = "\"The detective story is the normal recreation of noble minds.\"\n-Philip Guedalla";
        quotes[9] = "\"It is ridiculous to set a detective story in New York City. New York City is itself a detective story.\"\n-Agatha Christie";
        Menu.pause = false;
        if (Menu.gameover) {
            lose.Play();
            nextLevelButton.gameObject.SetActive(false);
            text.text = "You lose, better luck next time.\n\n" + quotes[Random.Range(0,10)];
        }
        else {
            win.Play();
            Menu.currentLevel++;
            if (Menu.currentLevel > 4) {
                Menu.currentLevel = 0;
                title.text = "The End";
                text.text = "Thanks for playing! We hope you enjoyed this little thing we made for GMTK GameJam 2019.";
                nextLevelButton.gameObject.SetActive(false);
            }
            else {
                title.text = "Level Cleared";
                text.text = "You found the culprit, nice.\n\n" + quotes[Random.Range(0, 10)];
            }
            nextLevelButton.onClick.AddListener(() => SceneManager.LoadScene(Menu.currentLevel));
        }
        menuButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        exitButton.onClick.AddListener(() => Application.Quit());
	}
}
