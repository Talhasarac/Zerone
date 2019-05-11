using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunsc : MonoBehaviour {


	public LayerMask lm;
	public float range;
	string dusmani;
	public GameObject ammotype;
	public float cooldown;
	float timecool;
	// Use this for initialization
	void Start () {
		if (this.transform.parent.tag == "friend") {

			dusmani = "enemy";

		}
		if (this.transform.parent.tag == "enemy") {
			dusmani = "friend";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,range,lm))
		{
			
			if (hit.transform.parent.tag == dusmani) {
				Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.forward) * hit.distance, Color.red);

				timecool += Time.deltaTime;
				if (timecool >= cooldown) {

					GameObject	clone =	Instantiate (ammotype, transform.position, transform.parent.rotation);

					clone.GetComponent<ammosc> ().whoami = transform.parent.tag;

					timecool = 0;
				}
			}
		}
		
	}
}
