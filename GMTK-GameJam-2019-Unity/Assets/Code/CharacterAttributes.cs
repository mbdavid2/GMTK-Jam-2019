using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour {

	public int ID;
    public int pointingID;
    public string message;
    public bool isKiller;
    public GameObject objectMessage;

	void Start () {
        
	}

    void Update () {
		
	}

    public void setID(int id) {
        ID = id;
        isKiller = false;
    }

    public void setMessage(string message) {
        this.message = message;
        objectMessage = this.gameObject.transform.GetChild(0).gameObject;
        objectMessage.GetComponent<TextMesh>().text = message;
        messagePointAtCamera();
    }

    private void messagePointAtCamera() {
        //objectMessage.transform.LookAt(Camera.main.transform);
        //objectMessage.transform.localScale = new Vector3(-objectMessage.transform.localScale.x*1.1f, objectMessage.transform.localScale.y, objectMessage.transform.localScale.z);
        //objectMessage.transform.Rotate(objectMessage.transform.rotation.x, objectMessage.transform.rotation.y + 180f, objectMessage.transform.rotation.z, Space.Self);

        objectMessage.transform.LookAt(objectMessage.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    public void setIsKiller() {
        isKiller = true;
    }
	
	
}
