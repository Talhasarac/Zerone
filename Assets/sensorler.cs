using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensorler : MonoBehaviour {

	public bool bisivr;
	BoxCollider bx;
	public Vector3 nwsz;
	public Vector3 nwcntr;
	public Collider cd;
	// Use this for initialization
	void Start () {
		bx = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}




	void OnTriggerStay(Collider other) {
		cd = other;

		if (other.tag != "sensor" && other != transform.parent && other.tag != "bullet" && other.gameObject != transform.parent.gameObject ) {
			
			bisivr = true;
			bx.center = nwcntr;
			bx.size = nwsz;
		}


		if (other.GetComponent<health> () != null) {
			if (other.GetComponent<health> ().healthf <= 0) {
				bisivr = false;
			}
		}
		}
	
	

	void OnTriggerExit(Collider other) {


		if (other.tag != "bullet") {
			bisivr = false;
			bx.size = new Vector3 (1, 1, 1);
			bx.center = new Vector3 (0, 0, 0);
		}


	}

}
