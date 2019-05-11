using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scoremanager : MonoBehaviour {

	public int CurrentScore;
	public int MaxScore;
	public Text CurrentScoretext;
	public bool gameison;
	public GameObject[] spawners;
	public GameObject resscreen;
	// Use this for initialization
	void Start () {

		MaxScore = PlayerPrefs.GetInt("MaxScorePP", 0);


	}

	void Update() {

	

	}
	// Update is called once per frame
	void LateUpdate () {

		CurrentScoretext.text = CurrentScore.ToString ();




	}
	void gameover () {
		

		gameison = false;

		resscreen.transform.GetChild (0).GetComponent<Text> ().text = MaxScore.ToString ();
		for (int i = 0; i < spawners.Length; i++) {
			spawners [i].SetActive (false);

		}
		resscreen.SetActive (true);

		if (CurrentScore > MaxScore) {
			MaxScore = CurrentScore;
			PlayerPrefs.SetInt("MaxScorePP", MaxScore);
		}

	}

	void startover () {

		CurrentScore = 0;

		gameison = true;
		resscreen.SetActive (false);


		for (int i = 0; i < spawners.Length; i++) {
			spawners [i].SetActive (true);

		}

	}
}
