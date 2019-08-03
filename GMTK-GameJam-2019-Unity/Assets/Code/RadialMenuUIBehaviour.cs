using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenuUIBehaviour : MonoBehaviour {

    SenseBehaviour.Sense currentSense;
    float cooldown;

    [SerializeField] Button sightButton, hearingButton, touchButton;
    [SerializeField] GameObject radialMenuUI;
    [SerializeField] Text cooldownText;
    [SerializeField] GameObject player;

    SenseBehaviour senseBeh;

    void Start () {
        senseBeh = player.GetComponent<SenseBehaviour>();
        currentSense = senseBeh.getCurrentSense();
        //Change UI sprite button?
        cooldown = senseBeh.getCurrentCooldown();
        // cooldown = sense.GetComponent<SenseBehaviour>.getCooldown();
        sightButton.onClick.AddListener(() => onClickButton(SenseBehaviour.Sense.Sight));
        hearingButton.onClick.AddListener(() => onClickButton(SenseBehaviour.Sense.Hearing));
        touchButton.onClick.AddListener(() => onClickButton(SenseBehaviour.Sense.Touch));
        Debug.Log(currentSense);
        radialMenuUI.SetActive(false);
    }

    void onClickButton(SenseBehaviour.Sense sense) {
        if (cooldown <= 0 && currentSense != sense) {
            currentSense = sense;
            //Change UI sprite button?
            senseBeh.setCurrentSense(currentSense);
            //reiniciar cooldown a sense + fer transicio del sentit antic al nou
            cooldown = senseBeh.getCurrentCooldown();
            Debug.Log(currentSense);
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
            //Mostrar logo disponible
        } 
    }
}
