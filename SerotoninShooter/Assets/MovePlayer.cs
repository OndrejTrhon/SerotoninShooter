﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayer : MonoBehaviour {
	// Use this for initialization
	
     public float PlayerSpeed;
     
     
     void Start () {
          PlayerSpeed = 0.03f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow))

     {

          gameObject.transform.Translate (Vector3.left * PlayerSpeed);

     }

     if (Input.GetKey (KeyCode.RightArrow))

     {

          gameObject.transform.Translate (Vector3.right * PlayerSpeed);

     }

     Vector3 pos = transform.position;
     pos.x = Mathf.Clamp (pos.x, -3, 1);
     transform.position = pos;
	}
}
