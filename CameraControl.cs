using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	Vector3 target; 
	Vector3 target2; 
	private GameObject player;
	[SerializeField] Transform playerjoyi;
	[SerializeField] float distansiya = 10f; 
	private GameObject muzika;
	public bool povorot = false;



	void Start ()
	{
		muzika = GameObject.Find ("Muzik");
		player = GameObject.FindGameObjectWithTag ("Player");
		playerjoyi = player.transform;

		if (PlayerPrefs.HasKey ("MuzikaOn")) {
			if (PlayerPrefs.GetInt ("MuzikaOn") == 1) {
				muzika.GetComponent<AudioSource>().Play();
			} else {
				muzika.GetComponent<AudioSource>().Stop();

			}
		}
	}


	// Update is called once per frame
	void LateUpdate () {

		if (povorot == true) {
			target = new Vector3 (playerjoyi.position.x, playerjoyi.position.y + distansiya, transform.position.z);
		} else {
			target = new Vector3 (transform.position.x, playerjoyi.position.y + distansiya, transform.position.z);
		}
		transform.position = target; 
	     

		}
}
