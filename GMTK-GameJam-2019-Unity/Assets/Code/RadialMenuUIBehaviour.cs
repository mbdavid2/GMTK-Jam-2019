using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenuUIBehaviour : MonoBehaviour {

    int currentSense;
    float cooldown;

    [SerializeField] Button sightButton, hearingButton, touchButton;
    [SerializeField] GameObject radialMenuUI;
    [SerializeField] Text cooldownText;

    void Start () {
        currentSense = 0;
        // currentSense = sense.GetComponent<SenseBehaviour>.getCurrentSense();
        //Change UI sprite button?
        cooldown = 10.0f;
        // cooldown = sense.GetComponent<SenseBehaviour>.getCooldown();
        sightButton.onClick.AddListener(() => onClickButton(0));
        hearingButton.onClick.AddListener(() => onClickButton(1));
        touchButton.onClick.AddListener(() => onClickButton(2));
        Debug.Log(currentSense);
        radialMenuUI.SetActive(false);
    }

    void onClickButton(int button) {
        if (cooldown <= 0) {
            currentSense = button;
            //Change UI sprite button?
            //sense.GetComponent<SenseBehaviour>.setCurrentSense(currentSense);
            //reiniciar cooldown a sense + fer transicio del sentit antic al nou
            Debug.Log(currentSense);
        }
        radialMenuUI.SetActive(false);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            cooldown = 10.0f;
            // cooldown = sense.GetComponent<SenseBehaviour>.getCooldown();
            radialMenuUI.SetActive(true);
        }
        if (cooldown-Time.deltaTime > 0) {
            cooldown -= Time.deltaTime;
            cooldownText.text = cooldown.ToString("N2");
        }
        else {
            cooldown = 0;
            cooldownText.text = cooldown.ToString("N2");
            //Mostrar logo disponible
        } 
    }
}
