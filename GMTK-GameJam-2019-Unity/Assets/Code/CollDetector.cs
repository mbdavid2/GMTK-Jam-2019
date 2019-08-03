using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollDetector : MonoBehaviour {

    public bool playerInRange;

	void Start () {
        
	}

    void Update () {
		
	}

    void OnCollisionStay(Collision coll) {
		if (coll.gameObject.tag.Equals("Player")) {
			playerInRange = true;
		}
	}

    void OnCollisionExit(Collision coll) {
		if (coll.gameObject.tag.Equals("Player")) {
			playerInRange = false;
		}
	}

    public bool isPlayerInRange() {
        return playerInRange;
    }
	
}
