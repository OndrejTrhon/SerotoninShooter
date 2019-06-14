using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingTarget : MonoBehaviour {

	public GameObject ObjectToSwitch;
	private bool hasEntered;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
	if (!hasEntered){
		hasEntered = true;
			var VelocityTemp = new Vector2(0,0);
			VelocityTemp = GetComponent<Rigidbody2D>().velocity;
			VelocityTemp = -VelocityTemp;
			GetComponent<Rigidbody2D>().velocity = VelocityTemp;
			Debug.Log("Collision triggered");
			
	}
}

}
