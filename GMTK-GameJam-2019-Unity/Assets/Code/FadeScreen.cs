using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour {

	private Color alphaColor; //Range: 0.1f to 1f
	public GameObject staminaEffect;
	private float fadeSpeed;

	public void staminaIndicator(float staminaValue){
		alphaColor.a = 1;
		staminaEffect.GetComponent<MeshRenderer>().material.color = Color.Lerp(staminaEffect.GetComponent<MeshRenderer>().material.color, alphaColor, fadeSpeed * Time.deltaTime);
	}


	void Start() {
		initVariables();
	}

	private void initVariables(){
		//Stamina/Transparency intitial values
		alphaColor = staminaEffect.GetComponent<MeshRenderer>().material.color;
		alphaColor.a = 0;
		staminaEffect.GetComponent<MeshRenderer>().material.color = Color.Lerp(staminaEffect.GetComponent<MeshRenderer>().material.color, alphaColor, 1f); //Lerp in one single step (1f)
		fadeSpeed = 10f;
	}

	void Update() {
		
	}
}
