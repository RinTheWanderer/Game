using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour {


	public float speed;
	public float shiftMultiplier;

	private Rigidbody2D body2d;

	private bool canDash = true;
	public float dashWaitTime;
	public float dashTime;
	private float dashCounter;
	public float dashMultiplier;
	private bool dashing = false;
	private Vector2 dashVector= new Vector2 (0,0);


	void Awake ()
	{
		body2d = GetComponent<Rigidbody2D> ();
	}


	void Update () 
	{
		if (canDash) {
			if (Input.GetKey (KeyCode.Space)) {
				dashVector = new Vector2 (body2d.velocity.x * dashMultiplier, body2d.velocity.y * dashMultiplier);
				dashCounter = 0;
				canDash = false;
			}
		} 
		else {
			dashCounter += Time.deltaTime;
			if (dashCounter > dashTime)
				dashVector = new Vector2 (0, 0);
			if(dashCounter > dashWaitTime)
				canDash = true;
		}

		if (Input.GetKey (KeyCode.LeftShift))
			body2d.velocity = new Vector2 (shiftMultiplier * speed * Input.GetAxis ("Horizontal"), shiftMultiplier * speed * Input.GetAxis ("Vertical"));
		else
			body2d.velocity = dashVector + new Vector2 (speed * Input.GetAxis ("Horizontal"), speed * Input.GetAxis ("Vertical"));
	}
}
