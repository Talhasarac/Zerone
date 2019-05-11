using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject one;
	public GameObject zero;
	public GameObject vrs;
	public int kolaylik;
	// kolaylık derecesi azaldıkca zorluk artar


	public float cooldown;
	float timer;

	void Start () {
		
	}
	

	void Update () {

		timer += Time.deltaTime;
		if(timer > cooldown) {
			int which = Random.Range (0,kolaylik); 

			if (which == 0) {
				
				Instantiate (vrs, transform.position, Quaternion.identity);
			} else {
				int which2 = Random.Range (0, 2);

				if (which2 == 1) {
					Instantiate (one, transform.position,Quaternion.identity);
				}
				if (which2 == 0) {
					Instantiate (zero, transform.position,Quaternion.identity);
				}
					

			}

			timer = 0;

			}



		
	}
}
