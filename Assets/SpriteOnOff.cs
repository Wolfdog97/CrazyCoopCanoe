using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOnOff : MonoBehaviour {

	public KeyCode myOnOffKey;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().enabled = false;	
		gameObject.GetComponent<AudioSource>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(myOnOffKey)) {
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			gameObject.GetComponent<AudioSource>().enabled = true;
		} else { 	
			gameObject.GetComponent<AudioSource>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().enabled = false;	
	}
}
}