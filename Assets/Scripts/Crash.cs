using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour {

		Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if (rb.position.x > 8.0f) {
			SceneManager.LoadScene("End Game");
		}
		if (rb.position.x < -8.5f){
			SceneManager.LoadScene("End Game");
		}
	}

    void OnCollisionEnter(Collision RockSmash)
    {
		Debug.Log ("entered hit");

        if (RockSmash.collider.tag == "Rock"){
			Debug.Log ("hit rock");
            //Replace 'Game Over' with your game over scene's name.
            SceneManager.LoadScene("End Game");
        }
    }

	
}
