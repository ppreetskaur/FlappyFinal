using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highScore = 0; 

	static Score instance;

	static public void AddPoint() {
		if(instance.bird.dead)
			return;

		score++;

		if(score > highScore) {
			highScore = score;
		}
	}
	BirdMovement bird;
	void Start() {
		instance = this;
		GameObject Player_go = GameObject.FindGameObjectWithTag("Player");
		if (Player_go == null) {
			Debug.LogError("Could not find an object with tag 'Player'!");
		}

		bird = Player_go.GetComponent<BirdMovement>();
		score = 0;
		highScore = PlayerPrefs.GetInt("highScore", 0);
	}

	void OnDestroy() {
		instance = null;
		PlayerPrefs.SetInt("highScore", highScore);
	}

	void Update () {
		GetComponent<GUIText>().text = "Score: " + score + "\nHighScore: " + highScore;
		}
}
