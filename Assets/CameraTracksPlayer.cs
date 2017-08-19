using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {

	Transform Player;

	float offsetX;
	  
	// Use this for initialization
	void Start () {

		GameObject Player_go = GameObject.FindGameObjectWithTag("Player");

		if(Player_go == null) {
			Debug.LogError("Couldn't find an object with tag 'Player'!");
			return;
		}

	    Player = Player_go.transform;  //transform contains the location of player

		offsetX = transform.position.x - Player.position.x;
	}

	// Update is called once per frame
	void Update () {
		if(Player != null) {
			Vector3 pos = transform.position;
			pos.x = Player.position.x + offsetX;
			transform.position = pos;
		}
	}
}
