using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class units : MonoBehaviour {

	public float speed;
	public Scoremanager SM;
	// Use this for initialization
	void Start () {
		SM = GameObject.FindGameObjectWithTag ("GM").GetComponent<Scoremanager> ();
		this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (SM.gameison == false) {
			Destroy (this.gameObject);
		}
		Destroy (this.gameObject, 7.5f);
		
	}
}
