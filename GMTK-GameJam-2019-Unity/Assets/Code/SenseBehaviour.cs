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

    private Animator anim;

    void Start () {
        anim = GameObject.Find("Animation").GetComponent<Animator>();
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
        if (null != anim) {
            anim.Play("AnimBlink", 0, 0.11f);
        }
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
                        if (!checkIsSilentUntilGreet(c)) {
                            c.gameObject.GetComponent<Canvas>().enabled = true;
                            //print(c.gameObject.GetComponent<Canvas>().GetComponent<RectTransform>().transform.localScale);

                            // Distance to player
                            float distance = Vector3.Distance(c.gameObject.GetComponent<Canvas>().GetComponent<RectTransform>().transform.position, GameObject.Find("Player").transform.position);
                            print(distance*distance*distance);
                            distance = distance*distance;
                            float factor = 3/distance;
                            if (factor > 0.15f) factor = 0.15f;
                            c.gameObject.GetComponent<Canvas>().GetComponent<RectTransform>().transform.localScale = new Vector3(factor, factor, 0f);
                            c.gameObject.GetComponent<Canvas>().referencePixelsPerUnit = 21f;
                            /*UnityEngine.UI.CanvasScaler can = c.gameObject.GetComponent<Canvas>().CanvasScaler;
                            can.dynamicPixelsPerUnit = 20f;*/
                        }
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

    private bool checkIsSilentUntilGreet(Transform c) {
        return c.parent.gameObject.GetComponent<CharacterAttributes>().isSilentUntilGreet();
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
