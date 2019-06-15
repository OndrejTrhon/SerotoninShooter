using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayer : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow))

     {

          gameObject.transform.Translate (Vector3.left * 0.05f);

     }

     if (Input.GetKey (KeyCode.RightArrow))

     {

          gameObject.transform.Translate (Vector3.right * 0.05f);

     }

	}
}
