using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsShopManager : MonoBehaviour {


	[SerializeField] int stoimost; // Стоимост продоваемого скина 
	[SerializeField] int SkinNomer; // Номер продаваемого скина 
	[SerializeField] string NazvanieTovara;
	[SerializeField] GameObject NehvataetDeneg;
	[SerializeField] GameObject SpasiboZapokupku;
	[SerializeField] GameObject Galochka;
	[SerializeField] GameObject KupitVibrat;
	[SerializeField] GameObject Sena;
	private bool vibrano; // Выбран ли скин как основной ?


	// Use this for initialization
	void Start () {
		NehvataetDeneg.SetActive (false);
		SpasiboZapokupku.SetActive (false);
		Galochka.SetActive (false);
	}
	
	public void zakritSpasibo (){
		SpasiboZapokupku.SetActive(false);
	}

	public void zakritNehvataet (){
		NehvataetDeneg.SetActive(false);
	}

	public void pervaya()
	{
		if (PlayerPrefs.HasKey ("Bonus")) {
	
			if (PlayerPrefs.HasKey (NazvanieTovara)) 
			{
				
			} 
			else
			{

				if (PlayerPrefs.GetInt ("Bonus") > stoimost || PlayerPrefs.GetInt ("Bonus") == stoimost) { // Если у игрока хватает денег для покупки
					int oplata = PlayerPrefs.GetInt ("Bonus") - stoimost; // Записываем сумму оплаты в переменную
					PlayerPrefs.SetInt ("Bonus", oplata); // Сохраняем переменную в плейр префс
					PlayerPrefs.SetString (NazvanieTovara, "Kupleno");
					PlayerPrefs.SetInt ("SkinNomer", SkinNomer); // Отдаем игроку нахрен никому не нужный скин.
					SpasiboZapokupku.SetActive(true);
					Galochka.SetActive (true);
					PlayerPrefs.Save (); // Сохраняем все это дело

				} else 
				{
					NehvataetDeneg.SetActive (true);
				}
			}
			   
		}

		if (vibrano == false) // А тут уже лень комментит (((
		{
			if (PlayerPrefs.GetString(NazvanieTovara) == "Kupleno") 
			{
				Debug.Log ("Vibral");
				PlayerPrefs.SetInt ("SkinNomer", SkinNomer);
				PlayerPrefs.Save ();
			}
		}
		
	}
	public void vtoraya()
	{
		if (PlayerPrefs.HasKey ("Dengi")) {

			if (PlayerPrefs.HasKey (NazvanieTovara)) 
			{

			} 
			else
			{

				if (PlayerPrefs.GetInt ("Dengi") > stoimost || PlayerPrefs.GetInt ("Dengi") == stoimost) { // Если у игрока хватает денег для покупки
					int oplata = PlayerPrefs.GetInt ("Dengi") - stoimost; // Записываем сумму оплаты в переменную
					PlayerPrefs.SetInt ("Dengi", oplata); // Сохраняем переменную в плейр префс
					PlayerPrefs.SetString (NazvanieTovara, "Kupleno");
					PlayerPrefs.SetInt ("SkinNomer", SkinNomer); // Отдаем игроку нахрен никому не нужный скин.
					SpasiboZapokupku.SetActive(true);
					Galochka.SetActive (true);
					PlayerPrefs.Save (); // Сохраняем все это дело

				} else 
				{
					NehvataetDeneg.SetActive (true);
				}
			}

		}

		if (vibrano == false) // А тут уже лень комментит (((
		{
			if (PlayerPrefs.GetString(NazvanieTovara) == "Kupleno") 
			{
				Debug.Log ("Vibral");
				PlayerPrefs.SetInt ("SkinNomer", SkinNomer);
				PlayerPrefs.Save ();
			}
		}

	}











	void Update ()
	{

		if (PlayerPrefs.HasKey ("SkinNomer")) {
			if (PlayerPrefs.GetInt ("SkinNomer") == SkinNomer) { // Если скин номер , равно сохраненному скин номеру в плейр преф то 
				Galochka.SetActive (true);
				vibrano = true; // Скинь выбран как основной
				if (PlayerPrefs.GetString ("Til") == "rus") {
					KupitVibrat.GetComponent<Text> ().text = "Выбрано";
				} else {
					KupitVibrat.GetComponent<Text> ().text = "Selected";
				}
			} else { // Иначе нет бля
				Galochka.SetActive (false);
				vibrano = false; 
				if (PlayerPrefs.GetString (NazvanieTovara) == "Kupleno") {

					if (PlayerPrefs.GetString ("Til") == "rus") {
						KupitVibrat.GetComponent<Text> ().text = "Выбрать";
					} else 
					{
						KupitVibrat.GetComponent<Text> ().text = "Select";
					}
						
				}
				if (PlayerPrefs.GetString (NazvanieTovara) != "Kupleno") {
					if (PlayerPrefs.GetString ("Til") == "rus") {
						KupitVibrat.GetComponent<Text> ().text = "Купить";
					} else {
						KupitVibrat.GetComponent<Text> ().text = "Buy";
					}

				}
			}
		} else {
			PlayerPrefs.SetInt ("SkinNomer", 0);
			PlayerPrefs.Save ();
		}

		if (PlayerPrefs.GetString (NazvanieTovara) == "Kupleno") {
			Sena.SetActive(false);
		}


	}

}
