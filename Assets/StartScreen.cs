using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	static bool SawOnce =false;

	// Use this for initialization
	void Start () {
		if (!SawOnce) {
			GetComponent<SpriteRenderer> ().enabled = true;
			Time.timeScale = 0;
		}
			SawOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale==0 && (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))) { 
			Time.timeScale = 1;
			GetComponent<SpriteRenderer> ().enabled = false;

		}
	}
}
