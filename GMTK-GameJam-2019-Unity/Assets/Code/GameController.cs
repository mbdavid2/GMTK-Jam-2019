using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private List<GameObject> currentCharacters;
	private int maxNumCharacters;
	public GameObject defaultPrefab;
	private int killerID;

	void Start () {

		//instantiateLevel();
	}
	
	void instantiateLevel() {
	}

	void Update () {
		
	}

	public void gameOver() {
		SceneManager.LoadScene("Main");
	}

}