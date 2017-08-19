using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {
	//this will move ground on left side during looping, without this the ground will move to right faster than sky/

	Rigidbody2D Player;

	void Start () {
	GameObject Player_go = GameObject.FindGameObjectWithTag("Player");
	
	if(Player_go == null) {
		Debug.LogError("Couldn't find an object with tag 'Player'!");
		return;
	   }	
	   Player = Player_go.GetComponent<Rigidbody2D>();  //transform contains the location of player	
   }

     void FixedUpdate() {
		float vel = Player.velocity.x * 0.75f;

		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
	}
}
