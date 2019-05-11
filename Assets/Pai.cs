using System.Collections;
using UnityEngine;

public class Pai : MonoBehaviour {


	public Transform target;
	public float movespeed;
	float firstmovespeed;
	public float rdmp ;
	float rayCastOffset = 5f;
	public float detectiondistance;
	public sensorler snssag;
	public sensorler snssol;
	public sensorler snsust;
	public sensorler snalt;
	public bool attacking;
	public float runrotatespeed;
	public float sabir;
	public float rotmult;
	string dusmanimdir;
	lookat lkat;
	float sabir2;
	Transform elim;
	
	int typerun;
	// Use this for initialization
	void Start () {
		if (this.transform.tag == "enemy") {

			transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
		}
		typerun = Random.Range (0, 4);
		bool	 bv = (Random.Range (0, 3) == 1);
		if(bv == true) {
			attacking = false;
		}
		else{
			attacking = true;
		}




		firstmovespeed = movespeed;
		lkat = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<lookat> ();

		if (this.tag == "enemy") {

			dusmanimdir = "friend";
		}
		if (this.tag == "friend") {
			dusmanimdir = "enemy";
		}
	}
	
	// Update is called once per frame
	void Update () {

		Move ();
		Pathfinding ();
		if (attacking == true) {

			eminmiyiz ();

		}else 
		{
			//runaway ();
		}
	}

	void FixedUpdate() {
		if (target != null) {
			if (Vector3.Distance (transform.position, target.position) < 20f) {

				movespeed = firstmovespeed * 0.5f;

			} else {

				movespeed = firstmovespeed;
			}
		} else {
			
			movespeed = firstmovespeed;
		}
	}


	void eminmiyiz() {
		if (target != null) {
			if (target.GetComponent<Pai> ().target == this.transform && target.GetComponent<Pai> ().attacking == true) {

				attacking = false;

			}
		}


	}
	void Turn() {
		
		if (target != null) {
			Vector3 pos = target.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation (pos);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rdmp);
		} else {

			banatargetbulunprotokolu ();

		}

	
	}

	void Move(){

		transform.position += transform.forward * movespeed * Time.deltaTime;
		if (target != null) {

		} else {

			banatargetbulunprotokolu ();

		}



	}

	void runaway() {


	

	

		sabir += Time.deltaTime;


			if(sabir > 4.5f) {

			typerun = Random.Range (0, 5);
			sabir = 0;

			}

		if (typerun == 0) {
			transform.Rotate (0.3f * rotmult, 0, 0);
		}
		if (typerun == 1) {
			transform.Rotate (-0.3f * rotmult, 0, 0);
		}
		if (typerun == 2) {
			transform.Rotate (0, -0.1f * rotmult, 0);
			transform.Rotate (0, 0, -0.2f * rotmult);
		}
		if (typerun == 3) {

			transform.Rotate (0, 0.1f * rotmult, 0);
			transform.Rotate (0, 0, 0.2f * rotmult);


		}
		if (typerun == 4) {

			transform.Rotate (0.03f * rotmult, 0, 0);

		}







	}

	void Pathfinding() {

		if (snssag.bisivr == false && snssol.bisivr == false && snsust.bisivr == false && snalt.bisivr == false) {
			if (attacking == true) {
				Turn ();
			} else {

				runaway ();
			}
		}
		if (snssag.bisivr == true && snssol.bisivr == true && snsust.bisivr == true && snalt.bisivr == true) {
			transform.Rotate (3.5f, 0, 0);
		}

		if (snssag.bisivr == true) {

			transform.Rotate (0, -0.5f, 0.5f);
		}

		if (snssol.bisivr == true) {

			transform.Rotate (0, 0.5f, -0.5f);
		}

		if (snalt.bisivr == true) {

			transform.Rotate (-0.5f,0,0);
		}
		if (snsust.bisivr == true) {

			transform.Rotate (0.5f,0,0);
		}


		}

	void 	banatargetbulunprotokolu () {



		sabir2 += Time.deltaTime;

		RaycastHit vurdum;
		LayerMask lm;
		lm = LayerMask.GetMask ("unit");
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out vurdum,1200f,lm))
			
		{
			if (vurdum.transform.tag == dusmanimdir) {

				target = vurdum.transform;
			}

	}
		if (sabir2 > 2f) {

			if (this.tag == "friend") {
				

				for(int i = 0; i < lkat.enemies.Length; i++)
				{
					if(elim == null) {
						if (this.transform != lkat.enemies [i].transform) {
							elim =	lkat.enemies [i].transform;
							;
						}
					}
					if (Vector3.Distance (this.transform.position, lkat.enemies [i].transform.position) < Vector3.Distance (this.transform.position, elim.position)) {
						if (this.transform != lkat.enemies [i].transform) {
							elim = lkat.enemies [i].transform;
						}

					}

				}
				target = elim;
				}

			if (this.tag == "enemy") {
				for (int i = 0; i < lkat.friends.Length; i++) {
					if (elim == null) {
						if (this.transform != lkat.friends [i].transform) {
							elim =	lkat.friends [i].transform;
						}
					}
					if (Vector3.Distance (this.transform.position, lkat.friends [i].transform.position) < Vector3.Distance (this.transform.position, elim.position)) {
						if (this.transform != lkat.friends [i].transform) {
							elim = lkat.friends [i].transform;
						}
						;

					}

				}
				target = elim;
			}

			sabir2 = 0;
		}




}
}

