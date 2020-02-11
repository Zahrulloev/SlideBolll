using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

	public GameObject player; 

	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
	}


	public void UngBocildi ()
	{
		player.GetComponent <BollController> ().click = true;
		player.GetComponent <BollController> ().ung = true;
	}

	public void ChapBosildi ()
	{
		player.GetComponent <BollController> ().click = true;
		player.GetComponent <BollController> ().chap = true;

	}

	public void Up()
	{
		player.GetComponent <BollController> ().click = false;
		player.GetComponent <BollController> ().ung = false;
		player.GetComponent<BollController> ().chap = false;
	}
}
