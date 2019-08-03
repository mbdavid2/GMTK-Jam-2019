using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	private List<GameObject> currentCharacters;
	private int maxNumCharacters;
	public GameObject defaultPrefab;

	void Start () {
		currentCharacters = new List<GameObject>();
		maxNumCharacters = 3;

		instantiateLevel();
		pointAt(currentCharacters[2], currentCharacters[0]);
		pointAt(currentCharacters[0], currentCharacters[1]);
	}
	
	void instantiateLevel() {
		instantiateCharactersAndIDs();
	}

	void Update () {
		
	}

	/* Creates characters and assigns IDs to all of them*/
	void instantiateCharactersAndIDs() {
		GameObject characterTMP;
		for (int i = 0; i < maxNumCharacters; ++i) {
			characterTMP = Instantiate(defaultPrefab, new Vector3(i * 4.0F, 0, i * 2.0F), Quaternion.identity);
			characterTMP.GetComponent<CharacterAttributes>().setID(i);
			characterTMP.GetComponent<CharacterAttributes>().setMessage("placeholder");
			currentCharacters.Add(characterTMP);
		}
		currentCharacters[2].GetComponent<CharacterAttributes>().setIsKiller(); //TODO: De moment hardcoded a aquest, s'hauria de fer alguna cosa random
	}

	/* Assigns messages to the characters and who are they pointing to*/
	void instantiateCharacterMessages() {

	}


	void pointAt(GameObject pointer, GameObject pointed) {
		//pointer.transform.Rotate(pointer.transform.rotation.x, pointer.transform.rotation.y + 20f, pointer.transform.rotation.z, Space.Self);
		//pointer.transform.LookAt(Vector3.zero);
		pointer.transform.LookAt(pointed.transform);
	}
}
