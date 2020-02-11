using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	[SerializeField] AudioSource click;
	[SerializeField] AudioSource slide;
	[SerializeField]GameObject abaut;
	[SerializeField]GameObject Nasstroyki;
	[SerializeField] GameObject ViborUrovnya;
	[SerializeField] GameObject Shop;
	[SerializeField] GameObject Converter;
	[SerializeField] GameObject ZagruzkaUrovnya;

	void Awake (){
		abaut.SetActive (false);
		Nasstroyki.SetActive (false);
		ViborUrovnya.SetActive (false);
		Shop.SetActive (false);
		Converter.SetActive (false);
		ZagruzkaUrovnya.SetActive (false);

	}


	public void ClickPlay(){
		ViborUrovnya.SetActive (true);
		click.Play ();
	}

	public void ClickSlayderPereklyuchatel ()
	{
		slide.Play ();
	}
	public void AbautClick (){
		abaut.SetActive (true);
		click.Play ();
	}
	public void NastroykaClick (){
		Nasstroyki.SetActive (true);
		click.Play ();
	}

	public void ShopClick(){
		Shop.SetActive (true);
		click.Play ();

	}

	public void ConverterClick (){
		Converter.SetActive (true);
		click.Play ();
	}


	public void ShopZakrit(){
		Shop.SetActive (false);
		click.Play ();
	}

	public void ZakritAbaut(){
		abaut.SetActive (false);
		click.Play ();
	}
	public void ZakritNastroyka (){
		Nasstroyki.SetActive (false);
		click.Play ();
	}
	public void  ZakritViborUrovnya(){
		ViborUrovnya.SetActive (false);
		click.Play ();
	}

	public void ZakritConverter(){
		Converter.SetActive (false);
		click.Play ();

	}

}
