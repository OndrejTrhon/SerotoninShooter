using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {

    Destroy (gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll)
 
{
    if (coll.gameObject.tag == "enemy")
    {
        Destroy (coll.gameObject);
        Destroy (gameObject);
    }
}
}
