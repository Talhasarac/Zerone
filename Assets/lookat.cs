using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour {


	public Transform targettt;
	public GameObject[] friends;
	public GameObject[] enemies;
	// Use this for initialization
	void Start () {
		stacklists ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	void awoker() {
		Invoke ("stacklists", 0.21f);
	}
	void stacklists() {
		
		friends = GameObject.FindGameObjectsWithTag ("friend");
		enemies = GameObject.FindGameObjectsWithTag ("enemy");


	}

}
