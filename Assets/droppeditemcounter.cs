using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class droppeditemcounter : MonoBehaviour {

	public Text CurrentScoretext;
	public Scoremanager SM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D unit) {
		if (unit.isTrigger) {

			if (unit.tag == "unit") {
				SM.CurrentScore += 1;
			}
			if (unit.tag == "bug") {
				SM.SendMessage ("gameover");
			}
		}
		}
}
