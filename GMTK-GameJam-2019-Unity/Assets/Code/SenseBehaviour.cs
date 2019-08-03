using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseBehaviour : MonoBehaviour {

    public enum Sense {Sight, Hearing, Touch};
    Sense currentSense;

    float currentCooldown;
    [SerializeField] float cooldown;

    void Start () {
        setCurrentSense(Sense.Sight);
        currentCooldown = 0;
        updateEnvironmentSense();
    }

    void updateEnvironmentSense() {
        switch(currentSense) {
            case Sense.Sight:
                break;
            case Sense.Hearing:
                break;
            case Sense.Touch:
                break;
            default:
                Debug.Log("wrong currentSense value");
                break;
        }
    }

    public Sense getCurrentSense()  {
        return currentSense;
    }

    public void setCurrentSense(Sense sense) {
        currentSense = sense;
        currentCooldown = cooldown;
        updateEnvironmentSense();
    }

    public float getCurrentCooldown() {
        return currentCooldown;
    }

    void Update () {
        if (currentCooldown - Time.deltaTime > 0) {
            currentCooldown -= Time.deltaTime;
        }
        else if (currentCooldown != 0) {
            currentCooldown = 0;
        }
    }
}
