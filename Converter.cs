using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Converter : MonoBehaviour {
	public int ColvoDeneg;
	public int ColvoBonus;
	public GameObject NetBonusa;

	void Start(){
		NetBonusa.SetActive (false);

	}

	public void click1(){
		if (PlayerPrefs.HasKey ("Bonus")) {
			int bonus = PlayerPrefs.GetInt ("Bonus");
			int dengi = PlayerPrefs.GetInt ("Dengi");
			if (PlayerPrefs.GetInt ("Bonus") > ColvoBonus) {
				bonus = bonus - ColvoBonus;
				dengi = dengi + ColvoDeneg;
				PlayerPrefs.SetInt ("Dengi", dengi);
				PlayerPrefs.SetInt ("Bonus", bonus);
				PlayerPrefs.Save ();
			}
			else{
				NetBonusa.SetActive (true);
			}
				
		} 
		else {

			NetBonusa.SetActive (true);
		}

	}
		

	public void ReklamaClick(){
		int dengi = PlayerPrefs.GetInt ("Dengi");
		dengi = dengi + ColvoDeneg;
		if (Advertisement.IsReady ()) {
			PlayerPrefs.SetInt ("Dengi", dengi);
			PlayerPrefs.Save ();
			Advertisement.Show ();

			}

	}


	public void Zakrit(){

		NetBonusa.SetActive (false);
	}


}
