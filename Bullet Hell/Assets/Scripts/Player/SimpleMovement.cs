using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour {


	public float speed;
	public float shiftMultiplier;

	private Rigidbody2D body2d;

	public bool canDash = true;
	public float dashWaitTime;
	public float dashTime;
	private float dashCounter;
	public float dashSpeed;


	void Start ()
	{
		body2d = GetComponent<Rigidbody2D> ();
	}


	void Update () 
	{
		if (canDash) {
			if (Input.GetKey (KeyCode.LeftShift))
				body2d.velocity = new Vector2 (shiftMultiplier * speed * Input.GetAxis ("Horizontal"), shiftMultiplier * speed * Input.GetAxis ("Vertical"));
			else if (Input.GetKey (KeyCode.Space))
				Dash ();
			else
				body2d.velocity = new Vector2 (speed * Input.GetAxis ("Horizontal"), speed * Input.GetAxis ("Vertical"));
		}
	}

	public void Dash(){
		canDash = false;
		float currentXVelocity = body2d.velocity.x;
		float currentYVelocity = body2d.velocity.y;

		if (dashCounter <= dashTime) {
			body2d.velocity = new Vector2 (currentXVelocity * dashSpeed, currentYVelocity * dashSpeed);
			dashCounter += Time.deltaTime;
		} 
		else if (dashCounter > dashTime && dashCounter <= dashWaitTime) {
			body2d.velocity = new Vector2 (0, 0);
			dashCounter += Time.deltaTime;
		}
		else {
			dashCounter = 0;
			canDash = true;
		}
	}
}
