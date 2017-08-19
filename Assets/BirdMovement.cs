using UnityEngine;
using System.Collections; 

public class BirdMovement : MonoBehaviour {
	// NOTE : SET BIRD SPRITE X AND Y ANGLES SOMEHWERE IS WILL FLAP SOMETHING SOMETHING ELSE.//
    Vector3 velocity = Vector3.zero;//This gives velocity to Bird.
	//public Vector3 gravity;// This gives Gravity to Bird. //DONT NEED THIS ACC TO (VID 4)//
	//public Vector3 flapvelocity; 
	public float flapSpeed = 100f; 
	public float forwardSpeed = 1f; //(FORWARD SPEED)

	bool didFlap = false; //Boolean

	Animator animator;

	public bool dead = false;
	float deathCooldown;                 //restarting ga

	public bool godMode = false;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();

		if(animator == null) {
			Debug.LogError ("Didn't find animator");
		}
	}

	//Do Grphics & input Update here
	void Update() {                             
		if (dead) {                              //restarting game
			deathCooldown -= Time.deltaTime;
			if(deathCooldown <= 0) {                 //restarting game
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ){ 
				Application.LoadLevel (Application.loadedLevel );   //restarting game
				}
		}
	}
		else {
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ){ 
			didFlap = true;
			}
	    }
    }

	// Do physics engine Update here
	  void FixedUpdate () {    //Runs per 58th sec.

		///<< WE DONT NEED THIS CODE ACC TO VID 5 BCA OF SOME RESN SO WILL REWRITE A NEW CODE >>>//

		//velocity.x = forwardSpeed; //(FORWARD SPEED)
		//velocity += gravity * Time.deltaTime; //velocity approaches max down velocity it will face down(bird facing down) //////DONT NEED THIS ACC TO (VID 4)////

		//if(didFlap == true) {
		//	didFlap = false;
		//	if(velocity.y < 0 ) // (Bird going down) // this will not let bird go down from starting 
		//		velocity.y += 0;  //(Bird Going Down) // 
		//	velocity += flapvelocity; //Add velocity to flapvelocity
		//}

		//velocity = Vector3.ClampMagnitude(velocity, maxSpeed); //This will ensure that velocity cannot exceed our maxspeed ,going up down it will not exceed mazspeed.

		//rigidbody2D.AddForce (velocity);

		//float angle = 0; // (bird facing down)
		//if(velocity.y  < 0) { //(bird facing down)
		//	angle = Mathf.Lerp(0, -90, -velocity.y / maxSpeed); //Only do this when [if(velocity.y < 0)](bird facing down)	
		//}

		//transform.rotation = Quaternion.Euler(0, 0, angle); // no x axis rotation no y axis rotation and z axis roatation will be angle (bird facing down)
         if(dead)
			return; 

		GetComponent<Rigidbody2D>().AddForce( Vector2.right * forwardSpeed );

		if(didFlap) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
			animator.SetTrigger("DoFlap");

			didFlap = false;
		}
	
	    if(GetComponent<Rigidbody2D>().velocity.y > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0); 

		}
		else {
			float angle = Mathf.Lerp(0, -90, -GetComponent<Rigidbody2D>().velocity.y / 3f);
			transform.rotation = Quaternion.Euler(0, 0, angle); 
		}
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if (godMode)
			return;
		animator.SetTrigger ("Death");
		dead = true;
		deathCooldown = 0.5f;          //restarting game
	}
}