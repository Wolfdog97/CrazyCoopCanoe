using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoeMovement : MonoBehaviour {

	// OBJECTS
	Rigidbody rb;//
	GameObject gameManager;//
	Transform myTransform;//


	// PLAYER 1 (BOW) CONTROL KEYS
	public KeyCode P1_SubmergeKey;//
	public KeyCode P1_SwitchToRightKey;//
	public KeyCode P1_SwitchToLeftKey;//
	public KeyCode P1_PaddleToSternKey;//
	public KeyCode P1_PaddleToBowKey;//

	// PLAYER 2 (STERN) CONTROL KEYS
	public KeyCode P2_SubmergeKey;//
	public KeyCode P2_SwitchToRightKey;//
	public KeyCode P2_SwitchToLeftKey;//
	public KeyCode P2_PaddleToSternKey;//
	public KeyCode P2_PaddleToBowKey;//



	// BOOLS
	public bool canoe_is_crashed;//
	public bool P1_paddle_is_submerged;//
	public bool P2_paddle_is_submerged;//
	public bool P1_paddle_on_right_side;//
	public bool P2_paddle_on_right_side;//


// TUNING VARIABLES
		
	// CANOE and PADDLE FORCES
	public float canoeVelocity;//
	public float paddleForce;//
	public float baseCanoeSpeed;//
		
	// PADDLE ANGLES
	public float angleChange;//
	public float myAngleShift;//

	// RIVER FORCES
	public float baseRiverSpeed;//
		
	// LIMITERS
	public float maxCanoeAngle;//
	public float minCanoeAngle;//


 
//________END_DECLARATIONS______________ 

//============START==================
   void Start () { // START FUNCTION

		gameManager = GameObject.Find ("GameManager"); // find the game object called "GameManager"
		rb = GetComponent<Rigidbody> (); // locate the rigidbody
		myTransform = GetComponent<Transform> (); // locate the transform
		myTransform = transform; 	// rename the transform because apparently I like redundancy
		canoe_is_crashed = false; // the canoe has not yet crashed, so the bools is set to 'false'
		P1_paddle_is_submerged = false; // starting with the paddles out of the water
		P2_paddle_is_submerged = false;	// starting with the paddles out of the water
		P1_paddle_on_right_side = true; // player 1's paddle starts on the right side
		P2_paddle_on_right_side = false; // player 2's paddle starts on the left side

	} // END START
		



//============FIXED=UPDATE================
	void FixedUpdate () { // FIXED UPDATE FUNCTION - UPDATED FOR EACH PHYSICS TICK
	
//--------------PLAYER-1-CONTROLS------------------
																						// PLAYER 1 SUBMERGING PADDLE
		if (Input.GetKeyDown(P1_SubmergeKey)){							 				//
			P1_paddle_is_submerged = true;												// swap the bool to true
			}// END IF P2 SUBMERGE KEY IS PRESSED
       

		if ((P1_paddle_is_submerged == true) && (P1_paddle_on_right_side == true)){ 	// PLAYER 1 PADDLING ON RIGHT
				if (Input.GetKeyDown (P1_PaddleToBowKey)) {								//
			}	//															

				if (Input.GetKeyDown (P1_PaddleToSternKey)) {							//
			}//
			
				if (Input.GetKeyDown (P1_SwitchToRightKey)) {
				}// END P1 SWAP TO RIGHT SIDE
					
				if (Input.GetKeyDown (P1_SwitchToLeftKey)) {
					if (P1_paddle_on_right_side == false){
						P1_SwapToLeft ();
					}// END ELSE 
				}// END P1 SWAP TO LEFT
			else { P1_HoldRight();
			}// END P1 RIGHT PADDLE DRAG
			}// END P1 PADDLING ON RIGHT
	

		if ((P1_paddle_is_submerged == true) && (P1_paddle_on_right_side == false)){ 	// PLAYER 1 PADDLING ON LEFT
			
			if (Input.GetKeyDown (P1_PaddleToBowKey)) {
			}// END P1 PADDLE TO BOW

			if (Input.GetKeyDown (P1_PaddleToSternKey)) {
			}// END P1 PADDLE TO STERN

			if (Input.GetKeyDown (P1_SwitchToRightKey)) {
				if (P1_paddle_on_right_side == false) {
					P1_SwapToRight ();
				}
			}// END P1 SWAP TO RIGHT SIDE

			if (Input.GetKeyDown (P1_SwitchToLeftKey)) {
			}// END P1 SWAP TO RIGHT
			else {P1_HoldLeft();
			}// END P1 LEFT PADDLE DRAG
		
		} // END P1 PADDLING ON LEFT
//--------------END-PLAYER-1-CONTROLS------------


//--------------PLAYER-2-CONTROLS------------------
		if (Input.GetKeyDown(P2_SubmergeKey)){ 											// PLAYER 2 SUBMERGING PADDLE
			P2_paddle_is_submerged = true;
		} //																				// IF P2 SUBMERGE KEY IS PRESSED


		if ((P2_paddle_is_submerged == true) && (P2_paddle_on_right_side == true)){ 	// P2 PADDLING ON RIGHT
			if (Input.GetKeyDown (P2_PaddleToBowKey)) {
			}//

			if (Input.GetKeyDown (P2_PaddleToSternKey)) {
			}//

			if (Input.GetKeyDown (P2_SwitchToRightKey)) {
			}// END P2 SWAP TO RIGHT SIDE

			if (Input.GetKeyDown (P2_SwitchToLeftKey)) {
				if (P2_paddle_on_right_side == false){
					P2_SwapToLeft ();
				}// END ELSE 
			}// END P2 SWAP TO LEFT
			else { P2_HoldRight();
			}// END P2 RIGHT PADDLE DRAG
		}// END P2 PADDLING ON RIGHT


		if ((P2_paddle_is_submerged == true) && (P2_paddle_on_right_side == false)){ 	// P2 PADDLING ON LEFT

			if (Input.GetKeyDown (P2_PaddleToBowKey)) {
			}// END P2 PADDLE TO BOW

			if (Input.GetKeyDown (P2_PaddleToSternKey)) {
			}// END P2 PADDLE TO STERN

			if (Input.GetKeyDown (P2_SwitchToRightKey)) {
				if (P2_paddle_on_right_side == false) {
					P2_SwapToRight ();
				}
			}// END P2 SWAP TO RIGHT SIDE

			if (Input.GetKeyDown (P2_SwitchToLeftKey)) {
			}// END P2 SWAP TO RIGHT
			else {P2_HoldLeft();
			}// END P2 LEFT PADDLE DRAG

		}// END P2 PADDLING ON LEFT
// END P2 MOVEMENT SCRIPT
	}// END FIXED UPDATE FUNCTION


//=============ACTIVE=PADDLING=FUNCTIONS==================

//-----------P1-ACTIVE-PADDLING-FUNCTIONS-----------------
			
				void P1_LeftToStern() {
			// increase velocity
			// increase angle
				P1_paddle_is_submerged = false;
					} //END P1 LEFT TO STERN FUNCTION
				
				void P1_LeftToBow() {
			// decrease velocity
			// decrease angle
				P1_paddle_is_submerged = false;
					} //END P1 LEFT TO BOW FUNCTION

				void  P1_RightToStern() {
			// increase velocity
			// decrease angle
				P1_paddle_is_submerged = false;
					} //END P1 RIGHT TO STERN FUNCTION
					
				void  P1_RightToBow() {
				// decrease velocity
				// increase angle
					P1_paddle_is_submerged = false;
					} //END P1 RIGHT TO BOW FUNCTION

				void  P1_HoldLeft (){
				// decrease angle slightly
				P1_paddle_is_submerged = false;
					}//END P1 HOLD LEFT FUNCTION

				void  P1_HoldRight(){
				//increase angle slightly
				P1_paddle_is_submerged = false;
					}//END P1 HOLD RIGHT FUNCTION

				void P1_SwapToRight(){
				P1_paddle_is_submerged = false;
					}//END P1 SWAP RIGHT FUNCTION

				void P1_SwapToLeft(){
				P1_paddle_is_submerged = false;
					}//END P1 SWAP TO LEFT
				

//-----------P2-ACTIVE-PADDLING-FUNCTIONS-----------------

				void P2_LeftToStern() {
					// increase velocity
					// increase angle
					P2_paddle_is_submerged = false;
				} //END P2 LEFT TO STERN FUNCTION

				void P2_LeftToBow() {
					// decrease velocity
					// decrease angle
					P2_paddle_is_submerged = false;
				} //END P2 LEFT TO BOW FUNCTION

				void  P2_RightToStern() {
					// increase velocity
					// decrease angle
					P2_paddle_is_submerged = false;
				} //END P2 RIGHT TO STERN FUNCTION

				void  P2_RightToBow() {
					// decrease velocity
					// increase angle
					P2_paddle_is_submerged = false;
				} //END P2 RIGHT TO BOW FUNCTION

				void  P2_HoldLeft (){
					//decrease angle drastically
					P2_paddle_is_submerged = false;
				}//END P2 HOLD LEFT FUNCTION

				void  P2_HoldRight(){
					//increase angle drastically
					P2_paddle_is_submerged = false;
				}//END P2 HOLD RIGHT FUNCTION

				void P2_SwapToRight(){
					P2_paddle_is_submerged = false;
				}//END P2 SWAP RIGHT FUNCTION

				void P2_SwapToLeft(){
					P2_paddle_is_submerged = false;
				}//END P2 SWAP TO LEFT

//________________END_ACTIVE_PADDLING_FUNCTIONS_______________________________________


}// END CANOE MOVEMENT SCRIPT

//=======================================================================================
//=======================================================================================




                //move to the left or the right (or not at all) depending on carDir
                //canoePosition.x += Mathf.Sign(carrot.x - transform.position.x) * horizontalSpeed * Time.fixedDeltaTime;

                // now that we've come up with the new position we want for the car, we tell the 
                //Rigidbody2D to go there. Note: we could just set transform.position to teleport the GameObject there,
                //but that wouldn't calculate collisions on the way. It's better to move physics objects using MovePosition()
                //rb.MovePosition(newPosition);

                //change the angle of the car using the horizontal velocity
                //note: you can set a sprite's rotation directly with transform.localEulerAngles, but if you have a 
                //physics body on it, it's safer to call MoveRotation() on the body
                //float newAngle = (laneWidth - distanceFromLane) * carrot.x * -swerveDifficulty;
                //rb.MoveRotation(newAngle);




							//increase the speed by acceleration * the time elapsed
							//forwardSpeed += Time.fixedDeltaTime * canoeAcceleration;  //Time.fixedDeltaTime is the number of seconds that will pass before the next fixedupdate

							//set the y component of the new velocity from forwardSpeed
							//using the speed * the time elapsed


							//canoePosition.y += forwardSpeed * Time.fixedDeltaTime;

							//rb.AddForce(transform.forward * forwardSpeed * Time.fixedDeltaTime)



							//				rb.velocity = new Vector3 (0, 0, baseSpeed);


							//					Debug.Log (angle);
							//					if (angle < maxCanoeAngle) {
							//						angle = angle+5;
							//						transform.localRotation = Quaternion.Euler (0, angle, 0);
							//						rb.AddRelativeForce (horizontalSpeed * paddleForce, 0, baseSpeed + forwardSpeed * paddleForce);
							//						paddle_is_submerged = false;
							//					}

						//					Debug.Log (angleChange);
						//					if (angleChange > minCanoeAngle) {
						//						angleChange = angleChange - 5;
						//						transform.localRotation = Quaternion.Euler (0, angleChange, 0);
						//						rb.AddRelativeForce (-horizontalSpeed * paddleForce, 0, baseSpeed + forwardSpeed * paddleForce);
						//						paddle_is_submerged = false;


						//					rb.velocity = new Vector3 (0, 0, baseSpeed);
						//
						//					if (angleChange < 0) {
						//						angleChange = angleChange + myAngleShift;
						//					} 
						//					if (angleChange > 0) {
						//						angleChange = angleChange - myAngleShift;
						//					}
						//
						//					if (angleChange > 0) {
						//						angleChange = angleChange + 0f;
						//					}