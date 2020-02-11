using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Invoke ("Destroy", 5f);
	}

	void Destroy(){
		Destroy (this.gameObject);

	}
}
