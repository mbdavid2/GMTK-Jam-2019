using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    private float movementSpeed;
    private bool collided;
    public Rigidbody playerRb;
    public Text textInteract;

	void Start () {
        movementSpeed = 5f;
        collided = false;
        textInteract.text = "";
	}

    void OnCollisionStay(Collision coll) {
        playerRb.velocity = Vector3.zero;
        if (coll.gameObject.tag.Equals("Character")) {
            if (GetComponent<SenseBehaviour>().getCurrentSense() == SenseBehaviour.Sense.Touch) {
                print(coll.gameObject.GetComponent<CharacterAttributes>().isCharacterKiller());
                //GetComponent<SenseBehaviour>().isCharacterKiller()
                textInteract.text = "Press F to punch\nPress G to greet";
                if(Input.GetKey(KeyCode.F)) {
                    if (coll.gameObject.GetComponent<CharacterAttributes>().isCharacterKiller()) {
                        Menu.gameover = false;
                        SceneManager.LoadScene("GameOver");
                    }
                    else {
                        Menu.gameover = true;
                        SceneManager.LoadScene("GameOver");
                    }
                }
                if(Input.GetKey(KeyCode.G)) {
                    if (coll.gameObject.GetComponent<CharacterAttributes>().isCharacterKiller()) {
                        Menu.gameover = true;
                        SceneManager.LoadScene("GameOver");
                    }
                    else if (coll.gameObject.GetComponent<CharacterAttributes>().isSilentUntilGreet()) {
                        coll.gameObject.GetComponent<CharacterAttributes>().setSilentNoMore();
                    }
                }
            }
        }
	}

    void OnCollisionExit(Collision coll) {
		collided = false;
        textInteract.text = "";
	}

    void Update () {
        movement();
        if(Input.GetKey(KeyCode.Escape)) {
            Menu.pause = true;
			SceneManager.LoadScene("Menu");
		}

	}

    private void movement() {
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
