using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float movementSpeed;

	void Start () {
        movementSpeed = 7f;
	}

    void Update () {
        transform.Translate(movementSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, movementSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
	}
}
