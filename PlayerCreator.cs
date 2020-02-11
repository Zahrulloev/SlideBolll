using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour {
	[SerializeField] int SkinNomer;
	public GameObject [] players = new GameObject[5];

	void Awake (){
		if (PlayerPrefs.HasKey ("SkinNomer")) 
		{
			SkinNomer = PlayerPrefs.GetInt ("SkinNomer");
			Instantiate (players[SkinNomer], transform.position, Quaternion.identity);
		} 
		else 
		{
			SkinNomer = 0;
			Instantiate (players[SkinNomer], transform.position, Quaternion.identity);
		}
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
