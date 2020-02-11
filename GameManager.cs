using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

	[SerializeField] GameObject panelYutkazdi1; // Ссылка на панелку
	[SerializeField] GameObject panelYutdi1;
	[SerializeField] GameObject  paneltayyer; // Чтобы включить таймер на скрипте Timer
	[SerializeField] GameObject GameOverMuzika;
	[SerializeField] GameObject ZagruzkaMenu;
	[SerializeField] GameObject Fora;
	[SerializeField] GameObject NetPodklyuceniya;
	[SerializeField] float time = 2f;
	public float BenzinBak;
	public float BenzinRashod;
	public float BenzinDobavka;
	public float SkorostKorablya;
	public static float Snizhennayskorost=0;
	public static bool Snizhenie = false;
	public static int idLevel;
	// Use this for initialization
	void Awake(){
		print (Snizhenie);
		if (Snizhenie == true && idLevel==SceneManager.GetActiveScene().buildIndex) {
			SkorostKorablya = Snizhennayskorost;
		}
	}

	void Start () 
	{ 
		panelYutkazdi1.SetActive (false); // отключаем панелку в начале загрузки уровня 
		panelYutdi1.SetActive (false);
		paneltayyer = GameObject.FindGameObjectWithTag ("Player");
		ZagruzkaMenu.SetActive (false);
		Fora.SetActive (false);
		NetPodklyuceniya.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (time > 0 && paneltayyer.GetComponent<BollController>().panelGameower == true) 
		{
			time -= Time.deltaTime;
			if (time < 0) {
				if (PlayerPrefs.HasKey ("Zvuki")) {
					int x = PlayerPrefs.GetInt ("Zvuki");
					if (x > 0) {
						GameOverMuzika.GetComponent<AudioSource> ().Play ();
					}
				}
				panelYutkazdi1.SetActive (true);
			}
		}

		if (time > 0 && paneltayyer.GetComponent <BollController> ().panelWin == true) {

			time -= Time.deltaTime;
			if (time < 0) {

				panelYutdi1.SetActive (true);
			}

		}
	}

	public void ClickHome ()
	{
		SceneManager.LoadScene ("Menu");
		ZagruzkaMenu.SetActive (true);
	}

	public void ClickAgain()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ClickNextUroven()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void SnizitSkorost(){
		Fora.SetActive (true);
	}

	public void SnizitDA(){
		
		if (Advertisement.IsReady ()) {
			idLevel = SceneManager.GetActiveScene ().buildIndex;
			Snizhennayskorost = SkorostKorablya - 1.5f;
			Snizhenie = true;
			Advertisement.Show ();
		} else {
			NetPodklyuceniya.SetActive (true);
		}
		Fora.SetActive (false);
	}

	public void SnizitNET(){
		Fora.SetActive (false);
	}
	public void Offline(){
		NetPodklyuceniya.SetActive (false);

	}

}