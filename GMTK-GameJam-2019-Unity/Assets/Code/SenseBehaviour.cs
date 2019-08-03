using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseBehaviour : MonoBehaviour {

    public enum Sense {Sight, Hearing, Touch};
    Sense currentSense;

    float currentCooldown;
    [SerializeField] float cooldown;

    AudioSource hearingBackground1, hearingBackground2;

    Transform[] level_elem, actors_elems;

    void Start () {
        hearingBackground1 = GameObject.Find("Audio Background 1").GetComponent<AudioSource>();
        hearingBackground2 = GameObject.Find("Audio Background 2").GetComponent<AudioSource>();
        hearingBackground1.Play();
        hearingBackground2.Play();
        level_elem = GameObject.Find("Level").GetComponentsInChildren<Transform>();
        actors_elems = GameObject.Find("Actors").GetComponentsInChildren<Transform>();
        setCurrentSense(Sense.Sight);
        currentCooldown = 0;
    }

    void updateEnvironmentSense() {
        switch(currentSense) {
            case Sense.Sight:
                hearingBackground1.Pause();
                hearingBackground2.Pause();
                foreach (Transform c in level_elem) {
                    if (c.gameObject.GetComponent<MeshRenderer>() != null) {
                        c.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                foreach (Transform c in actors_elems) {
                    if (c.gameObject.GetComponent<MeshRenderer>() != null) {
                        c.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    if (c.gameObject.GetComponent<Canvas>() != null) {
                        c.gameObject.GetComponent<Canvas>().enabled = false;
                    }
                }
                break;
            case Sense.Hearing:
                hearingBackground1.UnPause();
                hearingBackground2.UnPause();
                foreach (Transform c in level_elem) {
                    if (c.gameObject.GetComponent<MeshRenderer>() != null) {
                        c.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
                foreach (Transform c in actors_elems) {
                    if (c.gameObject.GetComponent<MeshRenderer>() != null) {
                        c.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                    if (c.gameObject.GetComponent<Canvas>() != null) {
                        c.gameObject.GetComponent<Canvas>().enabled = true;
                        c.gameObject.GetComponent<Canvas>().referencePixelsPerUnit = 21f;
                        /*UnityEngine.UI.CanvasScaler can = c.gameObject.GetComponent<Canvas>().CanvasScaler;
                        can.dynamicPixelsPerUnit = 20f;*/
                    }
                }
                break;
            case Sense.Touch:
                hearingBackground1.Pause();
                hearingBackground2.Pause();
                foreach (Transform c in level_elem) {
                    if (c.gameObject.GetComponent<MeshRenderer>() != null) {
                        c.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                }
                foreach (Transform c in actors_elems) {
                    if (c.gameObject.GetComponent<MeshRenderer>() != null) {
                        c.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    }
                    if (c.gameObject.GetComponent<Canvas>() != null) {
                        c.gameObject.GetComponent<Canvas>().enabled = false;
                    }
                }
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
