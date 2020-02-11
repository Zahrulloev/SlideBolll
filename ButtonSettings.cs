using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonSettings : MonoBehaviour {
	public static int LevelNomer;
	public int releasedLevel;
	public string nextLevel;


	void Awake()
	{
		if (PlayerPrefs.HasKey ("LevelNomer"))
		{
			LevelNomer = PlayerPrefs.GetInt ("LevelNomer");
			Debug.Log (LevelNomer);
		}
	}


	void Update (){

		if (Input.GetKey (KeyCode.Space))
			{
			PlayerPrefs.DeleteKey ("LevelNomer");
			PlayerPrefs.DeleteKey ("Bonus");
			PlayerPrefs.Save ();

			}


	}
//	public void ButtonNextLevel()
//	{
//		SceneManager.LoadScene (nextLevel);
//		if(releasedLevelStatic <= releasedLevel){
//			releasedLevelStatic = releasedLevel;
//			PlayerPrefs.SetInt ("Level", releasedLevelStatic);
//
//	}
//   }

}
