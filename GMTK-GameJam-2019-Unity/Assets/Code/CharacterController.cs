using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	private List<GameObject> currentCharacters;
	private int maxNumCharacters;
	public GameObject defaultPrefab;
	private int killerID;

	void Start () {
		currentCharacters = new List<GameObject>();
		maxNumCharacters = 3;

		instantiateLevel();
	}
	
	void instantiateLevel() {
		instantiateCharactersAndIDs();
		missatgesHardcoded();
	}

	void Update () {
		
	}

	/* Creates characters and assigns IDs to all of them*/
	void instantiateCharactersAndIDs() {
		GameObject characterTMP;

		characterTMP = Instantiate(defaultPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		characterTMP.GetComponent<CharacterAttributes>().setID(0);
		characterTMP.GetComponent<CharacterAttributes>().setMessage("default");
		currentCharacters.Add(characterTMP);

		characterTMP = Instantiate(defaultPrefab, new Vector3(0, 0, 6), Quaternion.identity);
		characterTMP.GetComponent<CharacterAttributes>().setID(1);
		characterTMP.GetComponent<CharacterAttributes>().setMessage("default");
		currentCharacters.Add(characterTMP);

		characterTMP = Instantiate(defaultPrefab, new Vector3(6, 0, 6), Quaternion.identity);
		characterTMP.GetComponent<CharacterAttributes>().setID(2);
		characterTMP.GetComponent<CharacterAttributes>().setMessage("default");
		currentCharacters.Add(characterTMP);
		/*for (int i = 0; i < maxNumCharacters; ++i) {
			if (i%2 == 0) {

			}
			characterTMP = Instantiate(defaultPrefab, new Vector3(i*2, 0, i*2), Quaternion.identity);
			characterTMP.GetComponent<CharacterAttributes>().setID(i);
			characterTMP.GetComponent<CharacterAttributes>().setMessage("default"+i);
			currentCharacters.Add(characterTMP);
		}*/
		currentCharacters[2].GetComponent<CharacterAttributes>().setIsKiller(); //TODO: De moment hardcoded a aquest, s'hauria de fer alguna cosa random
		killerID = 2;
	}

	/* Assigns messages to the characters and who are they pointing to*/
	/* void instantiateCharacterMessages() {
		pointAt(currentCharacters[killerID-1], currentCharacters[killerID]); //Vigila q no sigui 0 la del killer
		if (Random.Range(0, 1) == 0) {
			message = "Guilty!";
		}
		else {

		}
		currentCharacters[killerID-1].GetComponent<CharacterAttributes>().setMessage("Guilty");
		/*for (int i = 1; i < maxNumCharacters; ++i) {
			pointAt(currentCharacters[i], currentCharacters[i-1]);
			
		}
	}*/

	void missatgesHardcoded() {
		pointAndMessage(0, killerID, "Guilty!");
		pointAndMessage(1, 0, "Liar!");
		pointAndMessage(killerID, 1, "Liar!");
	}

	void pointAndMessage(int idPointer, int idPointed, string message) {
		pointAt(currentCharacters[idPointer], currentCharacters[idPointed]);
		currentCharacters[idPointer].GetComponent<CharacterAttributes>().setMessage(message);
	}


	void pointAt(GameObject pointer, GameObject pointed) {
		//pointer.transform.Rotate(pointer.transform.rotation.x, pointer.transform.rotation.y + 20f, pointer.transform.rotation.z, Space.Self);
		//pointer.transform.LookAt(Vector3.zero);
		pointer.transform.LookAt(pointed.transform);
	}
}
