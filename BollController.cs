using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class BollController : MonoBehaviour {

	public float movespeed = 300f;
	[SerializeField] float turnspeed = 120f;
	[SerializeField] GameObject Portlash; // Портлашни префабы
	[SerializeField] GameObject bonusMuzika;
	[SerializeField] GameObject DestroyMuzika;
	[SerializeField] GameObject TimeMuzika;
	public GameObject benzinSoni;
	public GameObject bonusSoni;
	private float yaw;
	private Transform MyT;
	public float BenzinBak;
	public float BenzinRashod;
	public float benzin;
	private GameObject GameManagerBenzin;
	public bool click = false;
	public bool ung = false;
	public bool chap = false; 
	public bool panelWin = false; // Чтобы включить таймер на скрипте Timer
	public bool panelGameower = false;
	public int bonus = 0;
	public int bonus2 = 0;
	public Animation anim;
	public static int KolvoProigrishey = 0;
	public bool finish; // Чтобы узнать дошелли игрок до финиша. Если дошел то мы отключаем таймер в счетчики времени.
	private bool zvuki;



	void Awake (){
		MyT = transform;
		bonusMuzika = GameObject.Find ("BonusMuzika");
		DestroyMuzika = GameObject.Find ("DestroyMuzika");
		TimeMuzika = GameObject.Find ("TimeMuzika");
		benzinSoni = GameObject.Find ("TimeText");
		bonusSoni = GameObject.Find ("BonusText");
		GameManagerBenzin = GameObject.Find ("GameManager");
	    }

	void Start(){
		movespeed = GameManagerBenzin.GetComponent<GameManager> ().SkorostKorablya;
		BenzinBak = GameManagerBenzin.GetComponent<GameManager> ().BenzinBak;
		BenzinRashod = GameManagerBenzin.GetComponent<GameManager> ().BenzinRashod;
		anim = benzinSoni.GetComponent<Animation> () as Animation;
		finish = false;
		if (PlayerPrefs.HasKey("Bonus"))
		{
			bonus = PlayerPrefs.GetInt("Bonus"); // Загружаем из базы записанное кольво бонусов
		}

		if (PlayerPrefs.HasKey ("Zvuki"))
		{
				int x = PlayerPrefs.GetInt("Zvuki");
				if (x > 0){ zvuki=true;}
				else{ zvuki = false;}

		}
		benzin = BenzinBak;
	
	}

	// Update is called once per frame
	void Update ()
	{
		Turn ();
		Thrast ();
	}


	void Turn ()
	{

	    yaw = turnspeed * Time.deltaTime; // Чап ва унга буралишь коди , ротейтини узгартиради
		if (click == true && ung == true) 
		{
			MyT.Rotate (0, 0, -yaw);
		}

		if (click == true && chap ==true)
		{
			
			MyT.Rotate (0, 0, yaw);
		}
			
	}


	void Thrast()
	{
		MyT.position += MyT.up * movespeed * Time.deltaTime ; // Тугрига юриш учун код
		if (finish == false) benzin -= BenzinRashod*Time.deltaTime;
		if (benzin < 11 && finish==false) {
			benzinSoni.GetComponent<Text> ().color = new Color (255,0,0);
			anim.Play ("Vakt");
		}
		if (benzin > 10 && finish == false) {
			benzinSoni.GetComponent<Text> ().color = new Color (255,255,255);
			anim.Stop("Vakt");
			benzinSoni.GetComponent<RectTransform> ().localScale = new Vector3 (1,1,1);
		}

		benzinSoni.GetComponent<Text>().text = benzin.ToString ();
	
	
		if (benzin < 0) {
			KolvoProigrishey++;
			finish = true;
			movespeed = 0; // Чтобы отключить скорость когда дойдет до финиша
			if (Advertisement.IsReady () && KolvoProigrishey %5 == 0)
			{ 
				Advertisement.Show ();
				KolvoProigrishey = 0;

			}
			panelGameower = true;
			BenzinRashod = 0;
			benzin = 0.001f;
		
			if (anim.IsPlaying ("Vakt") == true) {
				anim.Stop ("Vakt");
				benzinSoni.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
		
			}
		}

}


	void OnCollisionEnter2D (Collision2D coll){
		// События которые будут происходить при столькновение игрока с стеной
		if (coll.gameObject.tag == "Stena" || coll.gameObject.tag == "bullet") {
			KolvoProigrishey++;
			if (zvuki == true) {
				DestroyMuzika.GetComponent<AudioSource> ().Play ();
			}
			Instantiate (Portlash, transform.position, Quaternion.identity); // создаем клон из префаба портлаш
			this.gameObject.SetActive (false); // отключаем нашего игрока , что бы он не был видном при взрыве
			Handheld.Vibrate(); // Для вибрации телефона при проигрише.
			if (Advertisement.IsReady () && KolvoProigrishey %5 == 0)
			{ 
				Advertisement.Show ();
				KolvoProigrishey = 0;

			}
			finish = true;
			panelGameower = true;
		}
	
		if (coll.gameObject.tag == "Finish") {
			panelWin = true;
			finish = true;
			if (anim.IsPlaying("Vakt")) {
				anim.Stop("Vakt");
				benzinSoni.GetComponent<RectTransform> ().localScale = new Vector3 (1,1,1);
			}
			movespeed = 0; // Чтобы отключить скорость когда дойдет до финиша

		}
		// Когда собираешь монеты или бонусы
		if (coll.gameObject.tag == "Bonus") {
			bonus = bonus +1; // Для сохранения колличество взятых бонусов. Эта переменная потом используется в скрипте Finish для сохранения числа бонусов. В этом скрипте не сохраняется.
			bonus2 = bonus2 + 1;
			bonusSoni.GetComponent<Text> ().text = bonus2.ToString ();
			if (zvuki == true) {
				bonusMuzika.GetComponent<AudioSource> ().Play ();
			}
			Destroy (coll.gameObject);
		}


		if (coll.gameObject.tag == "Vremya") {
			benzin = benzin + GameManagerBenzin.GetComponent<GameManager> ().BenzinDobavka;
			if (zvuki == true) {
				TimeMuzika.GetComponent<AudioSource> ().Play ();
			}
			Destroy (coll.gameObject);
		}

	}


}

