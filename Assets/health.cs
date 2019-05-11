using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {


	public float healthf;
	float handhealth;
	lookat lkat;
	bool oldumoldum;
	float hasarsizskengecensure;
	public GameObject bumb;
	// Use this for initialization
	void Start () {
		handhealth = healthf;
		lkat = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<lookat> ();
	}
	
	// Update is called once per frame
	void Update () {
		hasarsizskengecensure += Time.deltaTime;
		if (handhealth != healthf) {

			hasarsizskengecensure = 0;
			bool	 bv = (Random.Range (0, 2) == 1);
			if(bv == true) {
				this.transform.parent.GetComponent<Pai> ().attacking = false;
			}


			handhealth = healthf;

		}
		if (hasarsizskengecensure > 3f) {

			this.transform.parent.GetComponent<Pai> ().attacking = true;
			hasarsizskengecensure = 0;
		}



		if (healthf <= 0) {
			this.GetComponent<BoxCollider> ().enabled = false;
			if (oldumoldum == false) {
				lkat.SendMessage ("awoker");
				Instantiate (bumb, transform.parent.transform.position, transform.parent.transform.rotation);
				oldumoldum = true;
			}


			Destroy (this.transform.parent.gameObject,0.2f);
		
		}
	
		
	}

	void OnTriggerEnter(Collider emi)
	{
		if (emi.tag == "bullet") {
			if (emi.GetComponent<ammosc> ().whoami != this.transform.parent.tag) {
				healthf -=	emi.GetComponent<ammosc> ().dmg;
			}
		}


	}
}
