using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour {
	
	public float speed = 0f; 
	public float maxSpeed = 20f;
	public float boost = 0.2f;
	public float rotationspeed = 50f;

		// Use this for initialization
		// Update is called once per frame
		void Update () {

			// Forward movement
		if (Input.GetKey (KeyCode.I))
		//	speed += boost;
			transform.Translate (Vector3.forward*speed*Time.deltaTime);

			// Backward movement
			if(Input.GetKey(KeyCode.K))
			transform.Translate (Vector3.back*speed*Time.deltaTime);

			// Left movement
			if(Input.GetKey(KeyCode.J))
			transform.Rotate (Vector3.left*rotationspeed*Time.deltaTime);

			// Right movement
			if(Input.GetKey(KeyCode.L))
			transform.Rotate (Vector3.right*rotationspeed*Time.deltaTime);

		}
	}