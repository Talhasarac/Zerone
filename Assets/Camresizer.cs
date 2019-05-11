using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camresizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera cam = this.GetComponent<Camera> ();
		if (cam.aspect == 0.625f) {
			cam.orthographicSize = 5;
		} else {
			cam.orthographicSize = 6;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
