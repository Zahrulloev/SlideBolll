using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManagerUnlocked : MonoBehaviour {
	public int Level;
	public Image Image;
	public Image Image2;
	public int zvezda;
	private string LevelString;
	public string nazvanieLevla;
	public Image StarOn1;
	public Image StarOn2;
	public Image StarOn3;
	public Image StarOf2;
	public Image StarOf3;
	public GameObject ZagruzkaUrovnya;


	void Awake(){
		if (PlayerPrefs.HasKey (nazvanieLevla)) {
			zvezda = PlayerPrefs.GetInt (nazvanieLevla);
			print ("OpenZvezda");
			OpenZvezda ();
		} else {
			print ("CloseZvezda");
			CloseZvezda ();
		}
	}

	void Start () {
		if (ButtonSettings.LevelNomer >= Level) 
		{
			Levelunlocked ();
		} 
		else 
		{
			Levellocked ();
		}
	}


	public void LevelSelect(string _level)
	{
		LevelString = _level;
		SceneManager.LoadScene (LevelString);
		ZagruzkaUrovnya.SetActive (true);
	}

	

	void Levellocked()
	{
		GetComponent<Button> ().interactable = false;
		Image.enabled = true;
		Image2.enabled = true;
	}
	void Levelunlocked ()
	{
		GetComponent<Button> ().interactable = true;
		Image.enabled = false;
		Image2.enabled = false;
	}

	void OpenZvezda()
	{
		if (zvezda == 3) 
		{
			StarOn1.enabled = true;
			StarOn2.enabled = true;
			StarOn3.enabled = true;
			print ("uhta zvezda");
		}

		if (zvezda == 2) 
		{
			StarOn1.enabled = true;
			StarOn2.enabled = true;
			StarOf3.enabled = true;
			StarOn3.enabled = false;
			print ("ikkita zvezda");
		}

		if (zvezda == 1) 
		{
			StarOn1.enabled = true;
			StarOn2.enabled = false;
			StarOn3.enabled = false;
			StarOf2.enabled = true;
			StarOf3.enabled = true;
			print ("bitta zvezda");
		}
	}

	void CloseZvezda ()
	{
		print ("zakrit");
		StarOn1.enabled = false;
		StarOn2.enabled = false;
		StarOn3.enabled = false;
		StarOf2.enabled = false;
		StarOf3.enabled = false;
	}
}
