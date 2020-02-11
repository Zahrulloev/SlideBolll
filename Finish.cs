using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

	[SerializeField] int LevelNomer; // Переменная обозначающая номерь данного уровня. Не индекс сцены. 
    GameObject player; // Ссылка на игрока
	GameObject StarMuzika; //
	[SerializeField] GameObject ScoreSoni;
	[SerializeField] GameObject ScoreProshliysoni;
	public float colvoOchko; //  Общее кольво очков которые есть в данном уровне
	public float ochko; // Очки которые набрал игрок в конце игры.
	public int zvezda; // Переменная для обозначения сколько игрок получил звезд за этот уровень.
	public int zvezdapProshloe; // Для сохранения предедушего результата , игрока.
	float procentOchko; // Процент прохождения уровня.Показывает наско игрок прошел уровень.
	float score; 
	float score2;
	bool ScoreniKursatishMunkin = false;
	string nazvanieUrovnya;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;
	int bonus;


	private int indexLevl; // Индекс сцены.

	void Awake()
	{
		star1.SetActive (false);
		star2.SetActive (false);
		star3.SetActive (false);
		StarMuzika = GameObject.Find ("StarMuzika");
		nazvanieUrovnya = SceneManager.GetActiveScene().name; // получаем название уровня 

		if (PlayerPrefs.HasKey (nazvanieUrovnya + "score")) {
			score2 = PlayerPrefs.GetFloat (nazvanieUrovnya + "score");
			score = 0;
		} else {
			score = 0;
			score2 = 0;
			ScoreProshliysoni.SetActive (false);
		}

	}


	void Start (){
		if (PlayerPrefs.HasKey ("LevelNomer")) // проверяем в каком уровне находимся 
		{
			LevelNomer = PlayerPrefs.GetInt ("LevelNomer"); // получаем номер уровня

		} 
		else // Если не прошли проверку значить мы на нулевом (первом по счету) уровне.
		{
			LevelNomer = 0; // Присваим номер уровня , для дальнейшей работы.
		}

		if (PlayerPrefs.HasKey (nazvanieUrovnya)) // Проверяем получал ли игрок в этом уровне раньше звезды.
		{
			zvezdapProshloe = PlayerPrefs.GetInt (nazvanieUrovnya); // Значить сохраняем его прошлый результать. 
			zvezda = 0;
		} else {
			zvezdapProshloe = 0; // ну значить он раньше не получал звезьд. 
			zvezda = 0; 
		}


		indexLevl =SceneManager.GetActiveScene().buildIndex; // получаем индекс сцены.
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D ( Collider2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			if (indexLevl > LevelNomer) // если индекс уровня больше его номера уровня ( он как правило меньше.)
			{
				LevelNomer = LevelNomer + 1; // то прибавляем единицу. Фактически мы говорим , что открылся новый уровень.
				PlayerPrefs.SetInt ("LevelNomer", LevelNomer);
				PlayerPrefs.Save ();
			}
	
			if (indexLevl < LevelNomer || indexLevl == LevelNomer )
			{
				Debug.Log ("Blya"); // ничего не делаем. Фактически пропускаем ход , так сказать.
			}
			//// Cохранение бонусов игрока
			bonus = player.GetComponent<BollController> ().bonus;
			PlayerPrefs.SetInt ("Bonus", bonus);
			PlayerPrefs.Save ();
		////////////////////////////////////
		
		 starsrazdacha(); // запуск функции по раздаче starsov.

		}
	}

	void Update(){
		ochko = player.GetComponent<BollController> ().bonus2; 
		procentOchko = (ochko / colvoOchko)*100; // вычисляем процент прохождения уровня.

		if (ScoreniKursatishMunkin == true) {
			scoreoflevel ();
			ScoreProshliysoni.GetComponent<Text> ().text = score2.ToString ();
		}
	}
		

	void starsrazdacha()
	{
		bool trizvezdi = false; // Получил ли игрок три звезды.

		if (procentOchko >= 80) {
			zvezda = 3; 
			Invoke ("s1", 3f);
			Invoke ("s2", 5f);
			Invoke ("s3", 7f);
			trizvezdi = true;
			if (PlayerPrefs.HasKey (nazvanieUrovnya)) // если в базе данных есть поля с названием Уровня
			{
				PlayerPrefs.SetInt (nazvanieUrovnya, zvezda); // то сохраняем в поле с названием уровня , колличество звезды. 
				PlayerPrefs.Save ();
			} else {
				PlayerPrefs.SetInt (nazvanieUrovnya, zvezda);
				PlayerPrefs.Save ();
			}

		}

		if (procentOchko >= 50 && trizvezdi == false) {
			
			Invoke ("s1", 3f);
			Invoke ("s2", 5f);
			if (zvezdapProshloe < 3) {
				zvezda = 2;
				if (PlayerPrefs.HasKey (nazvanieUrovnya)) { // если в базе данных есть поля с названием Уровня
					PlayerPrefs.SetInt (nazvanieUrovnya, zvezda); // то сохраняем в поле с названием уровня , колличество звезды. 
					PlayerPrefs.Save ();
				} else {
					PlayerPrefs.SetInt (nazvanieUrovnya, zvezda);
					PlayerPrefs.Save ();
				}
			}
		}

		if (procentOchko < 50) {
			
			Invoke ("s1",3f);
			if (zvezdapProshloe == 0) {
				zvezda = 1;
				if (PlayerPrefs.HasKey (nazvanieUrovnya)) { // если в базе данных есть поля с названием Уровня
					PlayerPrefs.SetInt (nazvanieUrovnya, zvezda); // то сохраняем в поле с названием уровня , колличество звезды. 
					PlayerPrefs.Save ();
				} else {
					PlayerPrefs.SetInt (nazvanieUrovnya, zvezda);
					PlayerPrefs.Save ();
				}
			}
		
		}
			
	}




	void s1()
	{
		star1.SetActive (true);
		StarMuzika.GetComponent<AudioSource> ().Play ();
		ScoreniKursatishMunkin = true;
	}
	void s2()
	{
		star2.SetActive (true);
		StarMuzika.GetComponent<AudioSource> ().Play ();
		ScoreniKursatishMunkin = true;
	}
	void s3()
	{
		star3.SetActive (true);
		StarMuzika.GetComponent<AudioSource> ().Play ();
		ScoreniKursatishMunkin = true;
	}

	void scoreoflevel ()
	{     
		float scorObshiy = ochko * 52;
		if (scorObshiy > score) {
			score+= 5;
			ScoreSoni.GetComponent<Text> ().text = score.ToString ();
		}
		// Cохранение score
		if (PlayerPrefs.HasKey (nazvanieUrovnya + "score")) {
			PlayerPrefs.SetFloat (nazvanieUrovnya + "score",score);
			PlayerPrefs.Save ();
		} else {
			PlayerPrefs.SetFloat (nazvanieUrovnya + "score",score);
			PlayerPrefs.Save ();
		}

	}
}
