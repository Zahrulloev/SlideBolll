using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Этот скрипт написан только для того, чтобы устранить один баг. Который возник не откуда. Прик включение игры , скрит "LevelManagerUnlockeD" автоматически
// отключается , из-за чего все кнопки уровня на котором он лежить не работают. Причем он отключается не на всех кнопках. Пока , что я проблему не нашел , и решил
// написать этот скрить , чтобы он включал скрипты при включение игры.

public class Vklyuchatel : MonoBehaviour {
	 
	public GameObject knopka;


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (knopka.GetComponent<LevelManagerUnlocked> ().isActiveAndEnabled) {
		} else {

			var mayskript = knopka.GetComponent<LevelManagerUnlocked> ();
			mayskript.enabled = true;
		}
	}
}
