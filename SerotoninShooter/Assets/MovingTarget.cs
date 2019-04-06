using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingTarget : MonoBehaviour {

	public GameObject ObjectToSwitch;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
	if (coll.gameObject.tag == "Player") {
			GetComponent<Rigidbody2D>().velocity *= -1;
	}
}

}
