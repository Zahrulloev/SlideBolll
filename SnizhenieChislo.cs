using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SnizhenieChislo : MonoBehaviour {

	GameObject GameManagerS;
	float chislo;

	void Start(){
		GameManagerS = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.Snizhennayskorost == 0 || GameManager.idLevel != SceneManager.GetActiveScene().buildIndex) {
			chislo = GameManagerS.GetComponent<GameManager> ().SkorostKorablya;
			GetComponent<Text> ().text = chislo.ToString ();

		} else {
			GetComponent<Text> ().text = GameManager.Snizhennayskorost.ToString ();
		}

	}
}