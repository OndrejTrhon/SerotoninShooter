using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision c)
 {
     
 
     // If the object we hit is the enemy
     if (c.gameObject.tag == "Player")
     {
        
		GetComponent<Rigidbody2D>().gravityScale = -1;   
     }
 }
}
