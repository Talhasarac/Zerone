using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammosc : MonoBehaviour {


	public float amspeed; 
	public float dmg;
	public string whoami;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (0,0,amspeed);


		Destroy (this.gameObject, 5);
	}
}
