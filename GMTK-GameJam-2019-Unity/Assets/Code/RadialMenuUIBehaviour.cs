using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RadialMenuUIBehaviour : MonoBehaviour {

    SenseBehaviour.Sense currentSense;
    float cooldown;

    [SerializeField] Button sightButton, hearingButton, touchButton;
    [SerializeField] GameObject radialMenuUI;
    [SerializeField] Text cooldownText;
    [SerializeField] GameObject player, clock;

    SenseBehaviour senseBeh;

    ColorBlock refColor, selColor;

    void Start () {
        refColor = selColor = sightButton.colors;
        selColor = hearingButton.colors;
        senseBeh = player.GetComponent<SenseBehaviour>();
        currentSense = senseBeh.getCurrentSense();
        updateSelColor();
        //Change UI sprite button?
        cooldown = senseBeh.getCurrentCooldown();
        sightButton.onClick.AddListener(() => onClickButton(SenseBehaviour.Sense.Sight));
        hearingButton.onClick.AddListener(() => onClickButton(SenseBehaviour.Sense.Hearing));
        touchButton.onClick.AddListener(() => onClickButton(SenseBehaviour.Sense.Touch));
        //Debug.Log(currentSense);
        radialMenuUI.SetActive(false);
    }

    void onClickButton(SenseBehaviour.Sense sense) {
        if (cooldown <= 0 && currentSense != sense) {
            currentSense = sense;
            //Change UI sprite button?
            senseBeh.setCurrentSense(currentSense);
            //reiniciar cooldown a sense + fer transicio del sentit antic al nou
            cooldown = senseBeh.getCurrentCooldown();
            clock.SetActive(true);
            updateSelColor();
            //Debug.Log(currentSense);
        }
        radialMenuUI.SetActive(false);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            radialMenuUI.SetActive(true);
        }
        cooldown = senseBeh.getCurrentCooldown();
        if (cooldown != 0) {
            cooldownText.text = cooldown.ToString("N2");
        }
        else {
            cooldownText.text = cooldown.ToString("N2");
            clock.SetActive(false);
        }
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("GameOver");
        }*/
    }

    void updateSelColor() {
        switch (currentSense) {
            case SenseBehaviour.Sense.Sight:
                sightButton.colors = selColor;
                hearingButton.colors = refColor;
                touchButton.colors = refColor;
                break;
            case SenseBehaviour.Sense.Hearing:
                hearingButton.colors = selColor;
                sightButton.colors = refColor;
                touchButton.colors = refColor;
                break;
            case SenseBehaviour.Sense.Touch:
                touchButton.colors = selColor;
                sightButton.colors = refColor;
                hearingButton.colors = refColor;
                break;
            default:
                //Debug.Log("wrong currentSense value");
                break;
        }
    } 
}
