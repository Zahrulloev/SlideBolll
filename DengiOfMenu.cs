using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DengiOfMenu : MonoBehaviour {
	int dengi ;

	
	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.HasKey ("Dengi")) {
			dengi = PlayerPrefs.GetInt ("Dengi");
			GetComponent<Text> ().text = dengi.ToString ();
		} else {

			PlayerPrefs.SetInt ("Dengi", 0);
			PlayerPrefs.Save ();
		}

		
	}
}
