using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusOfMenu : MonoBehaviour {

	int bonus;

	void Update (){

		if (PlayerPrefs.HasKey ("Bonus")) {
			bonus = PlayerPrefs.GetInt ("Bonus");	
			GetComponent<Text> ().text = bonus.ToString ();
		} else {

			PlayerPrefs.SetInt ("Bonus", 0);
			PlayerPrefs.Save ();
		}
	}
}
