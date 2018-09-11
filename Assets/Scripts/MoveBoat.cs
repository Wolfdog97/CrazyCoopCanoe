using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoat : MonoBehaviour {

	public float accel = 10f;
	public float turnSpeed =  3f;
	public float maxSpeed = 8f;

	public KeyCode right = KeyCode.W;
	public KeyCode left = KeyCode.Space;

	Rigidbody rb;

	void Update () {

		//if up pressed
		if (Input.GetAxis("Vertical") > 0)
		{
			//add force
			rb.AddRelativeForce(Vector2.up * accel);

			//if we are going too fast, cap speed
			if (rb.velocity.magnitude > maxSpeed)
			{
				rb.velocity = rb.velocity.normalized * maxSpeed;
			}
		}

		//if right/left pressed add torque to turn
		if (Input.GetAxis("Horizontal") != 0)
		{
			//scale the amount you can turn based on current velocity so slower turning below max speed
			float scale = Mathf.Lerp(0f, turnSpeed, rb.velocity.magnitude / maxSpeed);
			//axis is opposite what we want by default
			//rb.AddTorque(-Input.GetAxis("Horizontal") * scale);
		}
	}
}

