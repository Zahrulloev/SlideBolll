using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizatorUroven : MonoBehaviour {


	public GameObject MissionCompleted_rus;
	public GameObject MissionCompleted_eng;
	public GameObject LastRezult_rus;
	public GameObject LastRezultat_eng;
	public GameObject Vmenu;
	public GameObject Dalshe;
	public GameObject Da;
	public GameObject Net;
	public GameObject MissiyaProvalina_rus;
	public GameObject MissiyaProvalina_eng;
	public GameObject offline_rus;
	public GameObject offline_eng;
	public GameObject Snizhenie_rus;
	public GameObject Snizhenie_eng;
	public GameObject Zagruzka_rus;
	public GameObject Zagruzka_eng;



	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.GetString ("Til") == "rus") {
			MissionCompleted_eng.SetActive (false);
			LastRezultat_eng.SetActive (false);
			MissiyaProvalina_eng.SetActive (false);
			offline_eng.SetActive (false);
			Snizhenie_eng.SetActive (false);
			Zagruzka_eng.SetActive (false);
			Vmenu.GetComponent<Text> ().text = "В меню";
			Dalshe.GetComponent<Text> ().text = "Дальше";
			Da.GetComponent<Text> ().text = "Да";
			Net.GetComponent<Text> ().text = "Нет";
		} 
		else 
		{
			MissionCompleted_rus.SetActive (false);
			LastRezult_rus.SetActive (false);
			MissiyaProvalina_rus.SetActive (false);
			MissionCompleted_rus.SetActive (false);
			offline_rus.SetActive (false);
			Snizhenie_rus.SetActive (false);
			Zagruzka_rus.SetActive (false);
			Vmenu.GetComponent<Text> ().text = "Home";
			Dalshe.GetComponent<Text> ().text = "Next";
			Da.GetComponent<Text> ().text = "Yes";
			Net.GetComponent<Text> ().text = "No";

		}
	}
	

}
