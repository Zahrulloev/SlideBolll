using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aylana : MonoBehaviour {
	public float speed= 0.2f;
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, speed);
	}
}
