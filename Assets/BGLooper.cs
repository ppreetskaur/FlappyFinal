using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
     //script of looping sprites so game never ends soever.//
	int numBGPanels = 6;   //6 sky and ground images(sprites).(triiggering sky and ground).

	float PipeMax = 0.694f;    //for pipes   0.694f
	float PipeMin = -0.400f;   //for pipes  0.427f

	void Start() {
		GameObject[] Pipes = GameObject.FindGameObjectsWithTag ("Pipe");

		foreach(GameObject Pipe in Pipes) {           //for pipes
			Vector3 pos = Pipe.transform.position;

			pos.y = Random.Range(PipeMin, PipeMax);    //for pipes
			
			Pipe.transform.position = pos;			//for pipes
		}
	}

		
	void OnTriggerEnter2D(Collider2D collider) {  
		Debug.Log ("Triggered: " + collider.name);  //so this would tell us name of the thing it is colliding.
	
		float widthofBGobject = ((BoxCollider2D)collider).size.x; 

		Vector3 pos = collider.transform.position; //moving the collider to right //

		pos.x += widthofBGobject * numBGPanels;  //(widthofBGobject/2f)<<without this it will create a gap when looping sky sprite//

		collider.transform.position = pos;

		if(collider.tag == "Pipe") {               //for pipes
			pos.y = Random.Range (PipeMin, PipeMax);  //for pipes
		}
		collider.transform.position = pos;    //for pipes
	}
}
