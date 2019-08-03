﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseBehaviour : MonoBehaviour {

    public enum Sense {Sight, Hearing, Touch};
    Sense currentSense;

    float currentCooldown;
    [SerializeField] float cooldown;

    AudioSource hearingBackground1, hearingBackground2;

    void Start () {
        hearingBackground1 = GameObject.Find("Audio Background 1").GetComponent<AudioSource>();
        hearingBackground2 = GameObject.Find("Audio Background 2").GetComponent<AudioSource>();
        hearingBackground1.Play();
        hearingBackground2.Play();
        setCurrentSense(Sense.Sight);
        currentCooldown = 0;
    }

    void updateEnvironmentSense() {
        switch(currentSense) {
            case Sense.Sight:
                hearingBackground1.Pause();
                hearingBackground2.Pause();
                GameObject.Find("Floor").GetComponent<MeshRenderer>().enabled = true;
                break;
            case Sense.Hearing:
                hearingBackground1.UnPause();
                hearingBackground2.UnPause();
                GameObject.Find("Floor").GetComponent<MeshRenderer>().enabled = false;
                break;
            case Sense.Touch:
                hearingBackground1.Pause();
                hearingBackground2.Pause();
                GameObject.Find("Floor").GetComponent<MeshRenderer>().enabled = false;
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
