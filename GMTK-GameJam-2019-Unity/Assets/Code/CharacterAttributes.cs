using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour {

	public int ID;
    public int pointingID;
    public string message;
    public bool isKiller;

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
    }

    public void setIsKiller() {
        isKiller = true;
        print("set");
    }
	
	
}
