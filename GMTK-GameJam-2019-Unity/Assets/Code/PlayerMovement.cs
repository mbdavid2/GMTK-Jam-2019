using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float movementSpeed;
    private bool collided;
    public Rigidbody playerRb;

	void Start () {
        movementSpeed = 5f;
        collided = false;
	}

    void OnCollisionEnter(Collision coll) {
        playerRb.velocity = Vector3.zero;
	}

     void OnCollisionExit(Collision coll) {
		collided = false;
	}

    void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        /*Vector3 tempVect = new Vector3(x * transform.right, 0, z * transform.forward);
        tempVect = tempVect.normalized * movementSpeed * Time.deltaTime;
        playerRb.MovePosition(transform.position + tempVect);*/

        if (z != 0 || x != 0) {
            playerRb.MovePosition(playerRb.position + z * transform.forward * Time.deltaTime * movementSpeed);
            playerRb.MovePosition(playerRb.position + x * transform.right * Time.deltaTime * movementSpeed);
        }
        else {
            playerRb.velocity = Vector3.zero;
        }
        
        //transform.Translate(movementSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, movementSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        /*if (!collided) transform.Translate(movementSpeed*Input.GetAxis("Horizontal")*Time.deltaTime, 0f, movementSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        if (collided) {
            transform.Translate(movementSpeed*Input.GetAxis("Horizontal")*Time.deltaTime/100, 0f, movementSpeed*Input.GetAxis("Vertical")*Time.deltaTime/100);
        }*/
	}
}
